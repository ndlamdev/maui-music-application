using System.Net.Http.Headers;
using System.Text.Json;
using Android.Content.PM;
using Android.Util;
using maui_music_application.Configuration;
using maui_music_application.Dto;
using maui_music_application.Models;
using maui_music_application.Services.Api;
using Refit;

namespace maui_music_application.Services.impl;

public class ResourceService : IResourceService
{
    private readonly IResourceApi _resourceApi;
    private readonly ICloudinaryApi _cloudinaryApi;

    public ResourceService(IResourceApi api)
    {
        _resourceApi = api;
        var clientHandler = new LoggingHandler(new HttpClientHandler());
        var client = new HttpClient(clientHandler)
        {
            BaseAddress = new Uri(AppConstraint.BaseUrl)
        };

        _cloudinaryApi = RestService.For<ICloudinaryApi>(client);
    }

    public async Task CreateResource(ResourceApp resource)
    {
        Log.Info("ResourceService", $"Creating {resource.Name}, {resource.Tag}");
        try
        {
            APIResponse<ResponseSignature> response =
                await _resourceApi.GetSignature(new RequestSignature(resource.Name, resource.Tag));
            if (response.StatusCode == 200)
            {
                ResponseSignature data = response.Data;
                Log.Info("ResourceService",
                    $"Created {data.Timestamp}, {data.PublicId}, {data.Signature}, {data.ApiKey}, {data.Folder}");
                RequestCloudinaryUpload requestUpload = new RequestCloudinaryUpload(
                    resource.FilePath,
                    data.ApiKey,
                    data.Folder,
                    data.PublicId,
                    data.Timestamp,
                    data.Signature
                );
                await this.UploadResource(requestUpload);
            }

        }
        catch (Exception ex)
        {
            Log.Error("ResourceService", $"{ex.Message},{ex.StackTrace}");
        }
    }


    private async Task<ResponseCloudinaryUpload?> UploadResource(RequestCloudinaryUpload resource)
    {
        try
        {
            Log.Info("ResourceService", $"Uploading {resource.ToString()}");
            // var filePart = await GetFileStreamAsync(resource.FilePath);
            var fileStream = File.OpenRead(resource.FilePath);
            var filePart = new StreamPart(fileStream, fileStream.Name, "audio/mpeg");
            var response = await _cloudinaryApi.UploadFileAsync(
                filePart,
                folder: resource.Folder,
                publicId: resource.PublicId,
                timestamp: resource.Timestamp.ToString(),
                signature: resource.Signature,
                apiKey: resource.ApiKey
            );
            if (response.IsSuccessful)
            {
                Log.Info("ResourceService", "Data sent successfully.");

                return response.Content;
            }
            Log.Error("ResourceService", $"Error: {response.StatusCode}, {response.Error.Content}");
        }
        catch (Exception ex)
        {
            Log.Error("ResourceService", $"{ex.Message}\n{ex.StackTrace}");
        }
        return null;
    }

    public async Task<Stream> GetFileStreamAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Open a FileStream to read the file
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return fileStream;
        }

        return null; // Or handle file not found scenario
    }

    public async Task UploadFileToCloudinary(string filePath)
    {
        // Cloudinary upload URL
        var url = $"{AppConstraint.BaseUrl}/resource/upload"; // Replace with your Cloudinary URL
        Log.Info("ResourceService", $"Uploading to: {url}");

        // Create the HTTP client
        using var client = new HttpClient();

        // Create the MultipartFormDataContent
        var formData = new MultipartFormDataContent();

        // Open the file and prepare its content for upload
        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            var fileContent = new StreamContent(fileStream);
            // Optional: Set the Content-Type header (comment out if not required)
            // fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Add the file content to the form data (name 'file' is required by Cloudinary API)
            formData.Add(fileContent, "file");

            // Add other required parameters (make sure to replace them with your actual Cloudinary data)
            formData.Add(new StringContent("571775183462891"), "api_key"); // Your API key
            formData.Add(new StringContent("unsign"), "upload_preset"); // Your upload preset
            formData.Add(new StringContent("music-media/audio"), "folder"); // Folder name
            formData.Add(new StringContent("EZmusic - Breezy Copyright Free - EZmusic (youtube).mp3"), "public_id"); // Public ID

            try
            {
                // Send the POST request
                var response = await client.PostAsync(url, formData);

                // Check if the upload was successful
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Log.Info("ResourceService", $"Upload successful: {responseContent}");
                }
                else
                {
                    Log.Error("ResourceService", $"Upload failed: {response.ReasonPhrase}");
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Log.Error("ResourceService", $"Error content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Log.Error("ResourceService", $"Exception during upload: {ex.Message}");
            }
        }
    }

    public async Task UploadFileToBackend(Stream fileStream, string fileName)
    {
        var url = $"{AppConstraint.BaseUrl}/resource/upload"; // Your backend URL
        using (var client = new HttpClient())
        {
            // Create MultipartFormDataContent to hold the file
            var content = new MultipartFormDataContent();

            // Create StreamContent to represent the file as binary content
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Add file content to multipart form data
            content.Add(fileContent, "file", fileName);
            content.Add(new StringContent("571775183462891"), "api_key");
            content.Add(new StringContent("unsign"), "upload_preset"); // Your upload preset
            content.Add(new StringContent("music-media/audio"), "folder"); // Folder name
            content.Add(new StringContent("EZmusic - Breezy Copyright Free - EZmusic (youtube).mp3"), "public_id");
            try
            {
                // Send the request
                var response = await client.PostAsync(url, content);

                // Check if the upload was successful
                if (response.IsSuccessStatusCode)
                {
                    Log.Error("ResourceService", "File uploaded successfully!");
                }
                else
                {
                    Log.Error("ResourceService", $"Error uploading file: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Log.Error("ResourceService", $"Exception while uploading file: {ex.Message}");
            }
        }
    }

}
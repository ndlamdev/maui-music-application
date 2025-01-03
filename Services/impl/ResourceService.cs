using maui_music_application.Dto;
using maui_music_application.Helpers.Enum;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class ResourceService(IResourceApi api) : IResourceService
{
    public async ResponseSignature CreateResource(string nameFile, Tag tag)
    {
        try
        {
            APIResponse<ResponseSignature> responseSignature = await api.GetSignature(new RequestSignature(nameFile, tag));
            responseSignature.Data.Signature;
        }
    }


    private void UploadResource(
        File
        string apiKey,
        
        )
    {
        
    }
}
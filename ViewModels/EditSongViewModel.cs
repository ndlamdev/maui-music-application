// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:49 - 10/11/2024
// User: Lam Nguyen

using System.Collections.ObjectModel;
using Android.Util;
using CommunityToolkit.Maui.Views;
using maui_music_application.Attributes;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Components.Popup;
using Refit;

namespace maui_music_application.ViewModels;

public class EditSongViewModel : AObservableValidator
{
    private readonly IAdminService _service = ServiceHelper.GetService<IAdminService>();
    private INavigation Navigation { get; set; }
    private string _title = string.Empty;
    private string _fullPathThumbnail = string.Empty;
    private string _fullPathSource = string.Empty;
    private string _selectedArtist = string.Empty;
    private string _selectedAlbum = string.Empty;
    private string _selectedGenre = string.Empty;
    private ImageSource? _thumbnailPreview;
    private ImageSource? _sourcePreview;
    private const string DefaultUploadIcon = "upload_song.svg";
    private const string DefaultFileSuccessIcon = "check.svg";
    public ObservableCollection<string> ListArtist { get; set; } = new();
    public ObservableCollection<string> ListAlbum { get; set; } = new();
    public ObservableCollection<string> ListGenre { get; set; } = new();
    private MusicCard? _music;

    public EditSongViewModel(INavigation navigation) :
        base(true)
    {
        Navigation = navigation;
        ThumbnailPreview = ImageSource.FromFile(DefaultUploadIcon);
        SourcePreview = ImageSource.FromFile(DefaultUploadIcon);
        LoadDataAlbumAsync();
        LoadDataArtistAsync();
        LoadDataGenreAsync();
    }

    public EditSongViewModel(MusicCard music, INavigation navigation) : base(true)
    {
        Navigation = navigation;
        _music = music;
        ThumbnailPreview = _music.Cover;
        Title = _music.Title;
        SelectedArtist = _music.Artist;
        SelectedGenre = _music.Genre;
        LoadDataAlbumAsync();
        LoadDataArtistAsync();
        LoadDataGenreAsync();
    }

    [NotBlank(ErrorMessage = "Vui lòng nhập tên bài hát")]
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value, true);
    }

    [NotBlank(ErrorMessage = "Vui lòng chọn tác giả")]
    public string SelectedArtist
    {
        get => _selectedArtist;
        set
        {
            if (_selectedArtist != value)
            {
                _selectedArtist = value;
                OnPropertyChanged();
            }
        }
    }

    public string SelectedAlbum
    {
        get => _selectedAlbum;
        set
        {
            _selectedAlbum = value;
            OnPropertyChanged();
        }
    }

    [NotBlank(ErrorMessage = "Vui lòng chọn thể loại")]
    public string SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            if (_selectedGenre != value)
            {
                _selectedGenre = value;
                OnPropertyChanged();
            }
        }
    }

    [NotBlank(ErrorMessage = "Vui lòng chọn file ảnh nền ")]
    public string FilePickerThumbnail
    {
        get => _fullPathThumbnail;
        set => SetProperty(ref _fullPathThumbnail, value, true);
    }

    [NotBlank(ErrorMessage = "Vui lòng chọn file nhạc (mp3)")]
    public string FilePickerSource
    {
        get => _fullPathSource;
        set => SetProperty(ref _fullPathSource, value, true);
    }


    public ImageSource ThumbnailPreview
    {
        get => _thumbnailPreview;
        set => SetProperty(ref _thumbnailPreview, value);
    }

    public ImageSource SourcePreview
    {
        get => _sourcePreview;
        set => SetProperty(ref _sourcePreview, value);
    }

    public void OnSubmit(Page page)
    {
        ValidateAllProperties();
        Log.Info("AddNewSongViewModel",
            $"{_selectedArtist} {_selectedAlbum} {_title} {_fullPathSource} {_fullPathThumbnail}");
        if (HasErrors)
            return;
        if (_music == null)
            CreateSong(page);
        else
            UpateSong(page);
    }

    [Todo("Handle Create")]
    private async void CreateSong(Page page)
    {
        TodoAttribute.PrintTask<LoginWithPasswordViewModel>();
        var popup = LoadingPopup.GetInstance();
        try
        {
            page.ShowPopup(popup);

            var fileStreamSource = File.OpenRead(_fullPathSource);
            var filePartSource = new StreamPart(fileStreamSource, fileStreamSource.Name, "audio/mpeg");

            var fileStreamThumbnail = File.OpenRead(_fullPathThumbnail);
            var filePartThumbnail = new StreamPart(fileStreamThumbnail, fileStreamThumbnail.Name);


            await _service.CreateMusic(
                new RequestCreateSong(
                    title: _title,
                    artist: _selectedArtist,
                    album: _selectedAlbum,
                    genre: _selectedGenre,
                    fileThumbnail: filePartThumbnail,
                    fileSource: filePartSource
                ));
            ClearData();
            AndroidHelper.ShowToast("Tạo bài hát thành công!");
            page.ShowPopup(popup);
            await Navigation.PopAsync();
        }
        catch (Exception e)
        {
            Log.Error("AddNewSongViewModel", $"{e.Message} {e.StackTrace}");
            AndroidHelper.ShowToast(e.Message);
        }
        finally
        {
            popup.Close();
        }
    }

    [Todo("Handle update")]
    private async void UpateSong(Page page)
    {
        TodoAttribute.PrintTask<LoginWithPasswordViewModel>();
        var popup = LoadingPopup.GetInstance();
        try
        {
            page.ShowPopup(popup);

            var fileStreamSource = File.OpenRead(_fullPathSource);
            var filePartSource = new StreamPart(fileStreamSource, fileStreamSource.Name, "audio/mpeg");

            var fileStreamThumbnail = File.OpenRead(_fullPathThumbnail);
            var filePartThumbnail = new StreamPart(fileStreamThumbnail, fileStreamThumbnail.Name);


            await _service.CreateMusic(
                new RequestCreateSong(
                    title: _title,
                    artist: _selectedArtist,
                    album: _selectedAlbum,
                    genre: _selectedGenre,
                    fileThumbnail: filePartThumbnail,
                    fileSource: filePartSource
                ));
            ClearData();
            AndroidHelper.ShowToast("Tạo bài hát thành công!");
            page.ShowPopup(popup);
            await Navigation.PopAsync();
        }
        catch (Exception e)
        {
            Log.Error("AddNewSongViewModel", $"{e.Message} {e.StackTrace}");
            AndroidHelper.ShowToast(e.Message);
        }
        finally
        {
            popup.Close();
        }
    }

    private async void LoadDataArtistAsync()
    {
        List<string> items = await _service.GetAllArtists();
        Log.Info("AddNewSongViewModel", $"LoadDataArtistAsync {items.Count}");
        ListArtist.Clear();
        if (items.Count == 0)
        {
            items.Add(string.Empty);
        }
        else
        {
            foreach (var album in items)
            {
                ListArtist.Add(album);
            }
        }
    }

    private async void LoadDataAlbumAsync()
    {
        List<string> items = await _service.GetAllAlbums();
        Log.Info("AddNewSongViewModel", $"LoadDataAlbumAsync {items.Count}");
        ListAlbum.Clear();
        if (items.Count == 0)
        {
            items.Add(string.Empty);
        }
        else
        {
            foreach (var album in items)
            {
                ListAlbum.Add(album);
            }
        }
    }

    private async void LoadDataGenreAsync()
    {
        List<string> items = await _service.GetAllGenre();
        Log.Info("AddNewSongViewModel", $"LoadDataGenreAsync {items.Count}");
        ListGenre.Clear();
        if (items.Count == 0)
        {
            ListGenre.Add(string.Empty);
        }
        else
        {
            foreach (var album in items)
            {
                ListGenre.Add(album);
            }
        }
    }


    public async Task PickThumbnailAsync()
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a thumbnail",
                FileTypes = FilePickerFileType.Images // Example: Restrict to image files
            });

            if (result != null)
            {
                string fullPath = result.FullPath;

                FilePickerThumbnail = fullPath;

                ThumbnailPreview = ImageSource.FromFile(fullPath);
            }
            else
            {
                ThumbnailPreview = ImageSource.FromFile(DefaultUploadIcon);
            }
        }
        catch (Exception ex)
        {
            Log.Error("AddNewSongViewModel", $"{ex.Message} {ex.StackTrace}");
        }
    }

    public async Task PickSourceAsync()
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select MP3 Audio File",
                // FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                // {
                //     {
                //         DevicePlatform.Android, new[]
                //         {
                //             "audio/mp3"
                //         }
                //     },
                // }),
            });

            if (result != null)
            {
                string fullPath = result.FullPath;

                FilePickerSource = fullPath;

                SourcePreview = ImageSource.FromFile(DefaultFileSuccessIcon);
            }
            else
            {
                SourcePreview = ImageSource.FromFile(DefaultUploadIcon);
            }
        }
        catch (Exception ex)
        {
            Log.Error("AddNewSongViewModel", $"{ex.Message} {ex.StackTrace}");
        }
    }

    private void ClearData()
    {
        Title = string.Empty;
        SelectedArtist = string.Empty;
        SelectedAlbum = string.Empty;
        SelectedGenre = string.Empty;
        FilePickerThumbnail = string.Empty;
        FilePickerSource = string.Empty;
        ThumbnailPreview = ImageSource.FromFile(DefaultUploadIcon);
        SourcePreview = ImageSource.FromFile(DefaultUploadIcon);
    }
}
// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Data;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using Microsoft.Extensions.Logging;
using Exception = Java.Lang.Exception;
using TopMixes = maui_music_application.Models.TopMixes;

namespace maui_music_application.Views.Fragments;

public partial class HomePage
{
    private PlaylistDetail[] _playlistDetails = [];
    private TopMixes[] _topMixes = [];
    private RecentListen[] _recentListen = [];
    private IHomeService? _service;
    private readonly ILogger<HomePage> _logger;

    public HomePage()
    {
        InitializeComponent();
        BindingContext = this;
        Init();
    }

    private async Task GetPlaylists()
    {

        try
        {
            List<ResponsePlaylistCard> response = await _service.GetPlayList();
            if (response != null)
            {
                List<PlaylistDetail> playlists = new List<PlaylistDetail>();
                foreach (var item in response)
                {
                    playlists.Add(new PlaylistDetail(
                        item.Id + "",
                        item.Name,
                        item.CoverUrl,
                        null,
                        TimeSpan.Zero.ToString()
                    ));
                }
                _playlistDetails = playlists.ToArray();
            }
            Log.Info("Call Api Home Page", "GetPlaylists called {0} {1} ", this._playlistDetails.ToString(),
                this._playlistDetails.Length);
        }
        catch (Exception e)
        {
            AndroidHelper.ShowToast("Lấy playlist detail không thành công ");
            Log.Error("Call Api Home Page", e.Message);
        }
    }

    private async Task GetTopMixes()
    {
        try
        {
            List<ResponseAlbumCard> response = await _service.GetAlbumPopular();
            if (response != null)
            {
                List<TopMixes> topMixes = new List<TopMixes>();
                foreach (var item in response)
                {
                    topMixes.Add(new TopMixes(
                        item.Id,
                        item.Name,
                        item.Cover,
                        item.ReleaseDate.TimeOfDay
                    ));
                }
                this._topMixes = topMixes.ToArray();
            }
            Log.Info("Call Api Home Page", "GetAlbum called {0} ", _topMixes);
        }
        catch (Exception e)
        {
            AndroidHelper.ShowToast("Lấy top mixes không thành công ");
            Log.Error("Call Api Home Page", e.Message);
        }
    }

    private async Task GetRecentListen()
    {
        try
        {
            List<ResponseSongCard> response = await _service.GetRecentSong();
            if (response != null)
            {
                List<RecentListen> recentListen = new List<RecentListen>();
                foreach (var item in response)
                {
                    recentListen.Add(new RecentListen(
                        item.Id + "",
                        item.Cover
                    ));
                }
                this._recentListen = recentListen.ToArray();
            }
            Log.Info("Call Api Home Page", "GetAlbum called {0} ", _topMixes);
        }
        catch (Exception e)
        {
            AndroidHelper.ShowToast("Lấy recent listen không thành công ");
            Log.Error("Call Api Home Page", e.Message);
        }
    }


    private async void Init()
    {
        _service = ServiceHelper.GetService<IHomeService>();

        await GetPlaylists();
        PlaylistMusic.Adapter(new PlaylistMusicAdapter(_playlistDetails));


        await GetTopMixes();
        TopMixes.Adapter(new TopMixesAdapter(_topMixes));

        await GetRecentListen();
        RecentListen.Adapter(new RecentListenAdapter(_recentListen));

        Log.Info("Call Api Home Page", "Init called");
    }
}
// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:10:52 - 21/10/2024
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;

namespace maui_music_application.Data;

public class SongPageData
{
    public static readonly PlaylistDetail Playlist = new PlaylistDetail
    {
        Id = 1,
        CoverUrl = "playlist_thumbnail.png",
        Type = TypePlaylist.Playlist,
        Name = "My playlist",
        TotalSong = 11,
        // Name = "soft, chill, dreamy, lo-fi beats",
        Songs = new ApiPaging<MusicCard>
        {
            CurrentPage = 0,
            Size = 11,
            IsFirst = true,
            IsLast = true,
            TotalItems = 11,
            TotalPages = 1,
            Content =
            [
                new Music(1, "Bầu trời mới", "Dalab", "song_image.png",
                    "https://res.cloudinary.com/yourstyle/video/upload/sp_hd/music-media/audio/bau-troi-moi-dalab.m3u8",
                    ""),
                new Music(2, "Mùa mưa ấy", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/mua_mua_ay.mp3",
                    ""),
                new Music(3, "Những lời hứa bỏ quên", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/nhung_loi_hua_bo_quen.mp3",
                    ""),
                new Music(4, "Và em sẽ là người tôi yêu nhất", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/va_em_se_la_nguoi_toi_yeu_nhat.mp3",
                    ""),
                new Music(5, "Những chuyến bay", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/nhung_chuyen_bay.mp3",
                    ""),
                new Music(6, "Nếu những tiếc nuối", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/neu_nhung_tiec_nuoi.mp3",
                    ""),
                new Music(7, "Mây khóc vì điều gì", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/may_khoc_vi_dieu_gi.mp3",
                    ""),
                new Music(8, "Ngồi trong vấn vương", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/ngoi_cho_trong_van_vuong.mp3",
                    ""),
                new Music(9, "Danh hết xuân thì để chờ nhau", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/danh_het_xuan_thi_de_cho_nhau.mp3",
                    ""),
                new Music(10, "Không yêu em thì yêu ai", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/khong_yeu_em_thi_yeu_ai.mp3",
                    ""),
                new Music(11, "Bình yên", "Vũ", "song_image.png",
                    "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/binh_yen.mp3", ""),
            ]
        }
    };
}
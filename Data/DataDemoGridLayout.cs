// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:10:55 - 21/10/2024
// User: Lam Nguyen

using maui_music_application.Models;

namespace maui_music_application.Data;

public class DataDemoGridLayout
{
    public static readonly KindMusic[] Categories =
    [
        new("Kpop", "Kpop", "music_kpop.png"),
        new("Indie", "Indie", "music_kpop.png"),
        new("R&B", "R&B", "music_kpop.png"),
        new("Pop", "Pop", "music_kpop.png"),
        new("Pop2", "Pop 2", "music_kpop.png"),
    ];

    public static readonly PlaylistDetail[] PlaylistLarges =
    [
        SongPageData.Playlist,
    ];

    public static readonly FolderPlaylistMusic[] FolderPlaylist =
    [
        new("moods", "moods", []),
        new("blends", "blends", []),
        new("favs", "favs", []),
        new("random?", "random?", []),
    ];


    public static readonly MusicCardInTop[] MusicInTops =
    [
        new(1, "Dance Monkey 1", "Tones and I", "music_kpop.png", 1),
        new(2, "Dance Monkey 2", "Tones and I", "music_kpop.png", 2),
        new(3, "Dance Monkey 3", "Tones and I", "music_kpop.png", 3),
        new(4, "Dance Monkey 4", "Tones and I", "music_kpop.png", 4),
        new(5, "Dance Monkey 5", "Tones and I", "music_kpop.png", 5),
        new(6, "Dance Monkey 6", "Tones and I", "music_kpop.png", 6),
        new(7, "Dance Monkey 7", "Tones and I", "music_kpop.png", 7),
        new(8, "Dance Monkey 8", "Tones and I", "music_kpop.png", 8),
    ];

    public static readonly MusicCard[] MusicInPlaylists =
    [
        new(1, "Dance Monkey 1", "Tones and I", "music_kpop.png"),
        new(2, "Dance Monkey 2", "Tones and II", "music_kpop.png"),
        new(3, "Dance Monkey 3", "Tones and III", "music_kpop.png"),
        new(4, "Dance Monkey 4", "Tones and IV", "music_kpop.png"),
        new(5, "Dance Monkey 5", "Tones and V", "music_kpop.png"),
        new(6, "Dance Monkey 6", "Tones and VI", "music_kpop.png"),
        new(7, "Dance Monkey 7", "Tones and VII", "music_kpop.png"),
        new(8, "Dance Monkey 8", "Tones and VIII", "music_kpop.png"),
    ];

    public static readonly Artist[] Artists =
    [
        new(1, "music_kpop.png", "Conan Gray"),
        new(2, "music_kpop.png", "Chase Atlantic"),
        new(3, "music_kpop.png", "beabadoobee"),
        new(4, "music_kpop.png", "New Jeans"),
        new(5, "music_kpop.png", "keshi"),
        new(6, "music_kpop.png", "Conan Gray"),
        new(7, "music_kpop.png", "Chase Atlantic"),
        new(8, "music_kpop.png", "beabadoobee"),
        new(9, "music_kpop.png", "New Jeans"),
        new(10, "music_kpop.png", "keshi"),
    ];

    public static readonly Album[] Albums =
    [
        new(1, "Superache", "Conan Gray", "music_kpop.png"),
        new(2, "DAWN FM", "The Weekend", "music_kpop.png"),
        new(3, "Planet Her", "Doja Cat", "music_kpop.png"),
        new(4, "Wiped Out!", "The Neighbourhood", "music_kpop.png"),
        new(5, "Bloom", "Troye Sivan", "music_kpop.png"),
        new(6, "Superache", "Conan Gray", "music_kpop.png"),
        new(7, "DAWN FM", "The Weekend", "music_kpop.png"),
        new(8, "Planet Her", "Doja Cat", "music_kpop.png"),
        new(9, "Wiped Out!", "The Neighbourhood", "music_kpop.png"),
        new(10, "Bloom", "Troye Sivan", "music_kpop.png"),
    ];

    public static readonly PodcastAndShow[] PodcastsAndShows =
    [
        new("1", "Anything Goes", "Updated Aug 31 • Emma Chamberlain", "music_kpop.png"),
        new("2", "Ask Me Another", "Updated Aug 18 • NPR Studios", "music_kpop.png"),
        new("3", "Baking a Mystery", "Updated Aug 21• Stephanie Soo", "music_kpop.png"),
        new("4", "Extra Dynamic", "Updated Aug 10 • ur mom ashley", "music_kpop.png"),
        new("5", "Teenager Therapy", "Updated Aug 21• iHeart Studios", "music_kpop.png"),
        new("6", "Anything Goes", "Updated Aug 31 • Emma Chamberlain", "music_kpop.png"),
        new("7", "Ask Me Another", "Updated Aug 18 • NPR Studios", "music_kpop.png"),
        new("8", "Baking a Mystery", "Updated Aug 21• Stephanie Soo", "music_kpop.png"),
        new("9", "Extra Dynamic", "Updated Aug 10 • ur mom ashley", "music_kpop.png"),
        new("10", "Teenager Therapy", "Updated Aug 21• iHeart Studios", "music_kpop.png"),
    ];
}
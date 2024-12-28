namespace maui_music_application.Configuration;

public class AppConstraint
{
    public const string BaseUrl = "http://192.168.152.49:8081/api/v1";
    public const string User = "USER";
    public const string RefreshToken = "REFRESH_TOKEN";
    public const string AccessToken = "ACCESS_TOKEN";
    public static int Timeout = 5000;
    public static string DefaultAvatar = "https://i.pinimg.com/564x/29/6b/86/296b8682cc0e2c405a991a1d0cd5e9df.jpg";

    public static string DefaultCoverGenre = "https://i.scdn.co/image/ab67616d00001e027b7c31fa8f6fd3dd8dae2819";
}
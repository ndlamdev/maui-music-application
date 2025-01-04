namespace maui_music_application.Views.Components.Auth;

public partial class AuthView : ContentView
{
    public static readonly BindableProperty AllowedRolesProperty =
        BindableProperty.Create(nameof(AllowedRoles), typeof(IEnumerable<string>), typeof(AuthView), new List<string>());

    public static readonly BindableProperty UserRoleProperty =
        BindableProperty.Create(nameof(UserRole), typeof(string), typeof(AuthView), default(string));

    public static readonly BindableProperty ContentProperty =
        BindableProperty.Create(nameof(Content), typeof(View), typeof(AuthView));

    public static readonly BindableProperty FallbackContentProperty =
        BindableProperty.Create(nameof(FallbackContent), typeof(View), typeof(AuthView));

    public IEnumerable<string> AllowedRoles
    {
        get => (IEnumerable<string>)GetValue(AllowedRolesProperty);
        set => SetValue(AllowedRolesProperty, value);
    }

    public string UserRole
    {
        get => (string)GetValue(UserRoleProperty);
        set => SetValue(UserRoleProperty, value);
    }

    public View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public View FallbackContent
    {
        get => (View)GetValue(FallbackContentProperty);
        set => SetValue(FallbackContentProperty, value);
    }

    public bool IsAuthorized => AllowedRoles?.Contains(UserRole) == true;
    public bool IsUnauthorized => !IsAuthorized;

    public AuthView()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
# MAUI Music Application

This is a cross-platform music application built using .NET MAUI. The application is designed to run on Android, Windows, iOS, MacCatalyst, and Tizen platforms.

## Features

- Cross-platform support (Android, Windows, iOS, MacCatalyst, Tizen)
- Simple counter button to demonstrate basic functionality
- Semantic properties for accessibility

## Requirements

- .NET 8.0 SDK
- Visual Studio 2022 or later with .NET MAUI workload installed

## Getting Started

1. **Clone the repository:**
    ```sh
    git clone https://github.com/lamnguyen13052003/maui_music_application.git
    cd maui_music_application
    ```

2. **Open the project:**
    Open the `maui_music_application` folder in Visual Studio 2022 or JetBrains Rider.

3. **Restore dependencies:**
    ```sh
    dotnet restore
    ```

4. **Build and run the project:**
    Select the target platform (Android, Windows, etc.) and run the project from your IDE.

## Project Structure

- `MainPage.xaml` - The main UI layout of the application.
- `MainPage.xaml.cs` - The code-behind file for `MainPage.xaml` containing the logic for the counter button.
- `maui_music_application.csproj` - The project file containing configuration and dependencies.

## Usage

- **Counter Button:**
    - Click the "Click me" button to increment the counter.
    - The button text updates to show the number of times it has been clicked.
    - The screen reader announces the updated button text for accessibility.

## Dependencies

- `Microsoft.Maui.Controls`
- `Microsoft.Maui.Controls.Compatibility`
- `Microsoft.Extensions.Logging.Debug`

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
// Author: Lam Nguyễn
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 22:11:14 - 30/11/2024
// User: Lam Nguyen

using System.Runtime.CompilerServices;
using Android.Util;
using CommunityToolkit.Mvvm.ComponentModel;

namespace maui_music_application.Models;

public class AObservableValidator : ObservableValidator
{
    private bool _validateOnChanged;

    protected AObservableValidator(bool validateOnChanged)
    {
        SetValidateOnChanged(validateOnChanged);
    }

    public void SetValidateOnChanged(bool value)
    {
        if (_validateOnChanged) return;
        _validateOnChanged = value;
        if (value) ErrorsChanged += (_, args) => OnErrorChanged(args.PropertyName);
    }

    protected void OnErrorChanged([CallerMemberName] string? propertyName = null)
    {
        OnPropertyChanged($"ErrorChanged[{propertyName}]");
    }

    [IndexerName("ErrorChanged")]
    public ValidationStatus this[string propertyName]
    {
        get
        {
            var errors = GetErrors()
                .Where(e => e.MemberNames.Any()) // Đảm bảo có ít nhất 1 MemberName
                .GroupBy(e => e.MemberNames.First()) // Nhóm theo MemberName đầu tiên
                .ToDictionary(
                    g => g.Key,
                    g => g.First().ErrorMessage
                );

            var hasErrors = errors.TryGetValue(propertyName, out var error);
            Log.Error("AObservableValidator", $"Property: {propertyName} -> Error message: {error ?? string.Empty}");
            return new ValidationStatus(hasErrors, error ?? string.Empty);
        }
    }
}
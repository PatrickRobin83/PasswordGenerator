using System.Collections.ObjectModel;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MaterialDesignThemes.Wpf;

using PasswordGenerator.Models;
using PasswordGenerator.Services;

namespace PasswordGenerator.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel(ISnackbarMessageQueue messageQueue)
    {
        MessageQueue = messageQueue;
        LoadSettings();
        GeneratePassword();
    }
    
    private void GeneratePassword()
    {
      PasswordItems = CreatePasswordService.CreatePasswords(PasswordAmount, IsDigitUseChecked, IsCapitalUseChecked, IsNonCapitalUseChecked,
          IsSpecialCharacterUseChecked, PasswordLength);
    }

    [RelayCommand(CanExecute = nameof(CanCopyToClipBoard))]
    private void CopyToClipBoard()
    {
        if(SelectedPasswordItem != null)
        {
            Clipboard.SetText(SelectedPasswordItem.Password);
            MessageQueue.Enqueue($@"{SelectedPasswordItem} saved to Clipboard");
        }
        SelectedPasswordItem = null;
    }

    [RelayCommand]
    private void SaveSettings()
    {
        Properties.PasswordDefaultSettings.Default.IsDigitUseChecked = IsDigitUseChecked;
        Properties.PasswordDefaultSettings.Default.IsCapitalUseChecked = IsCapitalUseChecked;
        Properties.PasswordDefaultSettings.Default.IsNonCapitalUseChecked = IsNonCapitalUseChecked;
        Properties.PasswordDefaultSettings.Default.IsSpecialCharacterUseChecked = IsSpecialCharacterUseChecked;
        Properties.PasswordDefaultSettings.Default.PasswordLength = PasswordLength;
        Properties.PasswordDefaultSettings.Default.PasswordAmount = PasswordAmount;
        Properties.PasswordDefaultSettings.Default.IsSettingsSave = IsSettingsSave;
        Properties.PasswordDefaultSettings.Default.Save(); // Speichert die Einstellungen
    }

    private void LoadSettings()
    {
        IsDigitUseChecked = Properties.PasswordDefaultSettings.Default.IsDigitUseChecked;
        IsCapitalUseChecked = Properties.PasswordDefaultSettings.Default.IsCapitalUseChecked;
        IsNonCapitalUseChecked = Properties.PasswordDefaultSettings.Default.IsNonCapitalUseChecked;
        IsSpecialCharacterUseChecked = Properties.PasswordDefaultSettings.Default.IsSpecialCharacterUseChecked;
        PasswordLength = Properties.PasswordDefaultSettings.Default.PasswordLength;
        PasswordAmount = Properties.PasswordDefaultSettings.Default.PasswordAmount;
        IsSettingsSave = Properties.PasswordDefaultSettings.Default.IsSettingsSave;
    }

    private bool CanCopyToClipBoard()
    {
        if(SelectedPasswordItem != null)
        {
            IsItemSelected = true;
        }
        else
        {
            IsItemSelected = false;
        }

        return IsItemSelected;
    }
    
    partial void OnIsDigitUseCheckedChanged(bool value)
    {
        CheckDigits();
        GeneratePassword();
    }
    
    partial void OnIsCapitalUseCheckedChanged(bool value)
    {
        CheckDigits();
        GeneratePassword();
    }
    
    partial void OnIsNonCapitalUseCheckedChanged(bool value)
    {
        CheckDigits();
        GeneratePassword();
    }
    
    partial void OnIsSpecialCharacterUseCheckedChanged(bool value)
    {
        CheckDigits();
        GeneratePassword();
    }
    
    partial void OnPasswordLengthChanged(int value)
    {
        GeneratePassword();
    }

    partial void OnPasswordAmountChanged(int value)
    {
        GeneratePassword();
    }

    private void CheckDigits()
    {
        if(!IsNonCapitalUseChecked && !IsCapitalUseChecked && !IsSpecialCharacterUseChecked && !IsDigitUseChecked)
        {
            IsNonCapitalUseChecked = true;
            IsDigitUseChecked = true;
        }
    }

    partial void OnIsSettingsSaveChanged(bool value)
    {
        if (IsSettingsSave)
        {
            SaveSettings();
        }
    }



    [ObservableProperty]
    private int _passwordLength = 4;

    [ObservableProperty] 
    private int _passwordAmount = 5;

    [ObservableProperty] 
    private bool _isDigitUseChecked = true;

    [ObservableProperty] 
    private bool _isCapitalUseChecked = true;

    [ObservableProperty]
    private bool _isNonCapitalUseChecked = true;

    [ObservableProperty] 
    private bool _isSpecialCharacterUseChecked = true;
    
    [ObservableProperty]
    private ObservableCollection<PasswordItem> _passwordItems = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CopyToClipBoardCommand))]
    private PasswordItem? _selectedPasswordItem;

    [ObservableProperty] private bool _isItemSelected;

    [ObservableProperty] 
    private bool _isSettingsSave;

    public ISnackbarMessageQueue MessageQueue { get; }

}
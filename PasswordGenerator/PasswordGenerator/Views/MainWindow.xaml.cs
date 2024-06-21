using System.ComponentModel;
using System.Windows.Input;

using PasswordGenerator.ViewModels;

namespace PasswordGenerator.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        _viewModel = viewModel;
        DataContext = viewModel;
        InitializeComponent();

        CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClose));
    }

    #region Overrides of Window

    protected override void OnClosing(CancelEventArgs e)
    {
        if (_viewModel.IsSettingsSave)
        {
            _viewModel.SaveSettingsCommand.Execute(this);
        }

        base.OnClosing(e);
    }

    #endregion

    private void OnClose(object sender, ExecutedRoutedEventArgs e)
    {
        Close();
    }

    private MainWindowViewModel? _viewModel;
}
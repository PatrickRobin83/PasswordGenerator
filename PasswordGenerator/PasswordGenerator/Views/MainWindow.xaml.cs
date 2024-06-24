/*
 * -----------------------------------------------------------------------------
 *	 
 *   Filename		:   MainWindow.xaml.cs
 *   Date			:   2024-06-21
 *   All rights reserved
 * 
 * -----------------------------------------------------------------------------
 * @author Patrick Robin <support@rietrob.de>
 */

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
        DataContext = _viewModel;
        InitializeComponent();

        CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClose));
    }

    #region Overrides of Window

    protected override void OnClosing(CancelEventArgs e)
    {
        if (_viewModel != null && _viewModel.IsSettingsSave)
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

    private readonly MainWindowViewModel? _viewModel;
}
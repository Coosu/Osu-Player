using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Milki.OsuPlayer.ViewModels;

namespace Milki.OsuPlayer.UserControls
{
    public partial class PlayController : UserControl
    {
        public PlayController()
        {
            InitializeComponent();
            DataContext = PlayControllerViewModel.Shared;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ModeButton_Click(object? sender, RoutedEventArgs e)
        {
            PopMode.IsOpen = true;
        }

        private void VolumeButton_Click(object? sender, RoutedEventArgs e)
        {
            Pop.IsOpen = true;
        }

        private void PlayListButton_Click(object? sender, RoutedEventArgs e)
        {
            PopPlayList.IsOpen = true;
        }
    }
}

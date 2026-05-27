using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Milki.OsuPlayer.ViewModels;

namespace Milki.OsuPlayer.UserControls
{
    public partial class MiniPlayController : UserControl
    {
        public MiniPlayController()
        {
            InitializeComponent();
            DataContext = PlayControllerViewModel.Shared;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

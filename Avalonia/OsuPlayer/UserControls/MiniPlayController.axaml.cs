using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Milki.OsuPlayer.ViewModels;
using System;

namespace Milki.OsuPlayer.UserControls
{
    public partial class MiniPlayController : UserControl
    {
        private PlayControllerViewModel _viewModel;

        public MiniPlayController()
        {
            InitializeComponent();
            _viewModel = new PlayControllerViewModel();
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // 事件处理方法将在后续实现
        // 目前使用示例数据和基本功能
    }
}
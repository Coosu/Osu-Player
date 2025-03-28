using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace Milki.OsuPlayer.UserControls
{
    public partial class PlayController : UserControl
    {
        public PlayController()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // 这里将添加事件处理方法
        // 目前使用示例数据和基本功能，后续会完善
    }
}
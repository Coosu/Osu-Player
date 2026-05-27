using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Media;

namespace Milki.OsuPlayer.ViewModels;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private const double ExpandedNavigationWidth = 170;
    private const double CollapsedNavigationWidth = 48;

    private bool _isNavigationCollapsed;
    private object _currentPage;
    private string _currentPageTitle;

    public MainWindowViewModel()
    {
        CollapseCommand = new RelayCommand(ToggleNavigation);

        LibraryNavigationItems =
        [
            new NavigationItemViewModel("搜索", "Search", Geometry.Parse("M909.6 829.6 702.1 622.1C746.6 563.1 773 489.6 773 410 773 215.1 614.9 57 420 57S67 215.1 67 410s158.1 353 353 353c79.6 0 153.1-26.4 212.1-70.9l207.5 207.5c19.3 19.3 50.7 19.3 70 0s19.3-50.7 0-70zM420 674c-145.8 0-264-118.2-264-264s118.2-264 264-264 264 118.2 264 264-118.2 264-264 264z"), Navigate),
            new NavigationItemViewModel("故事版", "Storyboard", Geometry.Parse("M128 192h768v96H128v-96zm0 160h320v288H128V352zm384 0h384v96H512v-96zm0 128h384v96H512v-96zm0 128h256v64H512v-64z"), Navigate)
        ];

        MineNavigationItems =
        [
            new NavigationItemViewModel("最近播放", "Recent", Geometry.Parse("M512 96C282.2 96 96 282.2 96 512s186.2 416 416 416 416-186.2 416-416S741.8 96 512 96zm0 736c-176.7 0-320-143.3-320-320s143.3-320 320-320 320 143.3 320 320-143.3 320-320 320zm48-336V272h-96v272l224 134 48-80-176-102z"), Navigate),
            new NavigationItemViewModel("导出管理", "Export", Geometry.Parse("M512 96 288 320h144v288h160V320h144L512 96zM224 704h576v96H224v-96z"), Navigate)
        ];

        CollectionNavigationItems =
        [
            new NavigationItemViewModel("默认收藏", "Collection", Geometry.Parse("M512 864 438 797C176 560 96 488 96 338c0-122 96-218 218-218 69 0 135 32 178 82 43-50 109-82 178-82 122 0 218 96 218 218 0 150-80 222-342 459l-74 67z"), Navigate)
        ];

        _currentPageTitle = "主页";
        _currentPage = new HomePageViewModel();
        Navigate(LibraryNavigationItems[0]);
    }

    public ObservableCollection<NavigationItemViewModel> LibraryNavigationItems { get; }

    public ObservableCollection<NavigationItemViewModel> MineNavigationItems { get; }

    public ObservableCollection<NavigationItemViewModel> CollectionNavigationItems { get; }

    public RelayCommand CollapseCommand { get; }

    public bool IsNavigationCollapsed
    {
        get => _isNavigationCollapsed;
        private set
        {
            if (_isNavigationCollapsed == value) return;
            _isNavigationCollapsed = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNavigationExpanded));
            OnPropertyChanged(nameof(NavigationWidth));
            OnPropertyChanged(nameof(NavigationToggleToolTip));
            OnPropertyChanged(nameof(SectionHeaderHeight));
            OnPropertyChanged(nameof(SectionHeaderMargin));

            foreach (var item in LibraryNavigationItems) item.IsTextVisible = IsNavigationExpanded;
            foreach (var item in MineNavigationItems) item.IsTextVisible = IsNavigationExpanded;
            foreach (var item in CollectionNavigationItems) item.IsTextVisible = IsNavigationExpanded;
        }
    }

    public bool IsNavigationExpanded => !IsNavigationCollapsed;

    public double NavigationWidth => IsNavigationCollapsed ? CollapsedNavigationWidth : ExpandedNavigationWidth;

    public string NavigationToggleToolTip => IsNavigationCollapsed ? "展开导航栏" : "折叠导航栏";

    public double SectionHeaderHeight => IsNavigationCollapsed ? 0 : 30;

    public Thickness SectionHeaderMargin => IsNavigationCollapsed ? new Thickness(0) : new Thickness(0, 10, 0, 0);

    public object CurrentPage
    {
        get => _currentPage;
        private set
        {
            if (ReferenceEquals(_currentPage, value)) return;
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    public string CurrentPageTitle
    {
        get => _currentPageTitle;
        private set
        {
            if (_currentPageTitle == value) return;
            _currentPageTitle = value;
            OnPropertyChanged();
        }
    }

    private void ToggleNavigation()
    {
        IsNavigationCollapsed = !IsNavigationCollapsed;
    }

    public void ShowSystemPage(string title)
    {
        foreach (var navigationItem in LibraryNavigationItems) navigationItem.IsSelected = false;
        foreach (var navigationItem in MineNavigationItems) navigationItem.IsSelected = false;
        foreach (var navigationItem in CollectionNavigationItems) navigationItem.IsSelected = false;

        CurrentPageTitle = title;
        CurrentPage = new PlaceholderPageViewModel(title);
    }

    private void Navigate(NavigationItemViewModel item)
    {
        foreach (var navigationItem in LibraryNavigationItems) navigationItem.IsSelected = false;
        foreach (var navigationItem in MineNavigationItems) navigationItem.IsSelected = false;
        foreach (var navigationItem in CollectionNavigationItems) navigationItem.IsSelected = false;

        item.IsSelected = true;
        CurrentPageTitle = item.Title;
        CurrentPage = item.Key == "Search"
            ? new HomePageViewModel()
            : new PlaceholderPageViewModel(item.Title);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

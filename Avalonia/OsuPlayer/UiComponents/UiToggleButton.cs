using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;

namespace Milki.OsuPlayer.UiComponents;

public class UiToggleButton : ToggleButton
{
    #region Icons

    public UiToggleButton()
    {
        PseudoClasses.Set(":icon", IconTemplate is not null);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property == IconTemplateProperty)
        {
            PseudoClasses.Set(":icon", IconTemplate is not null);
        }

        base.OnPropertyChanged(e);
    }

    public static readonly StyledProperty<IBrush> IconColorProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(IconColor));

    public IBrush IconColor
    {
        get => GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public static readonly StyledProperty<Thickness> IconMarginProperty =
        AvaloniaProperty.Register<UiToggleButton, Thickness>(nameof(IconMargin), new Thickness(0, 0, 5, 0));

    public Thickness IconMargin
    {
        get => GetValue(IconMarginProperty);
        set => SetValue(IconMarginProperty, value);
    }

    public static readonly StyledProperty<Orientation> IconOrientationProperty =
        AvaloniaProperty.Register<UiToggleButton, Orientation>(nameof(IconOrientation));

    public Orientation IconOrientation
    {
        get => GetValue(IconOrientationProperty);
        set => SetValue(IconOrientationProperty, value);
    }

    public static readonly StyledProperty<double> IconSizeProperty =
        AvaloniaProperty.Register<UiToggleButton, double>(nameof(IconSize), 15d);

    public double IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }

    public static readonly StyledProperty<ControlTemplate?> IconTemplateProperty =
        AvaloniaProperty.Register<UiToggleButton, ControlTemplate?>(nameof(IconTemplate));

    public ControlTemplate? IconTemplate
    {
        get => GetValue(IconTemplateProperty);
        set => SetValue(IconTemplateProperty, value);
    }

    #endregion

    #region Brushes

    public static readonly StyledProperty<IBrush> MouseOverBackgroundProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(MouseOverBackground));

    public IBrush MouseOverBackground
    {
        get => GetValue(MouseOverBackgroundProperty);
        set => SetValue(MouseOverBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseOverForegroundProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(MouseOverForeground));

    public IBrush MouseOverForeground
    {
        get => GetValue(MouseOverForegroundProperty);
        set => SetValue(MouseOverForegroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseDownBackgroundProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(MouseDownBackground));

    public IBrush MouseDownBackground
    {
        get => GetValue(MouseDownBackgroundProperty);
        set => SetValue(MouseDownBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseDownForegroundProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(MouseDownForeground));

    public IBrush MouseDownForeground
    {
        get => GetValue(MouseDownForegroundProperty);
        set => SetValue(MouseDownForegroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> CheckedBackgroundProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(CheckedBackground));

    public IBrush CheckedBackground
    {
        get => GetValue(CheckedBackgroundProperty);
        set => SetValue(CheckedBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> CheckedForegroundProperty =
        AvaloniaProperty.Register<UiToggleButton, IBrush>(nameof(CheckedForeground));

    public IBrush CheckedForeground
    {
        get => GetValue(CheckedForegroundProperty);
        set => SetValue(CheckedForegroundProperty, value);
    }

    #endregion
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;

namespace Milki.OsuPlayer.UiComponents;

public class UiButton : Button
{
    #region Icons

    public UiButton()
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
        AvaloniaProperty.Register<UiButton, IBrush>(nameof(IconColor));

    public IBrush IconColor
    {
        get => GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public static readonly StyledProperty<Thickness> IconMarginProperty =
        AvaloniaProperty.Register<UiButton, Thickness>(nameof(IconMargin), new Thickness(0, 0, 5, 0));

    public Thickness IconMargin
    {
        get => GetValue(IconMarginProperty);
        set => SetValue(IconMarginProperty, value);
    }

    public static readonly StyledProperty<Orientation> IconOrientationProperty =
        AvaloniaProperty.Register<UiButton, Orientation>(nameof(IconOrientation));

    public Orientation IconOrientation
    {
        get => GetValue(IconOrientationProperty);
        set => SetValue(IconOrientationProperty, value);
    }

    public static readonly StyledProperty<double> IconSizeProperty =
        AvaloniaProperty.Register<UiButton, double>(nameof(IconSize), 15d);

    public double IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }

    public static readonly StyledProperty<ControlTemplate?> IconTemplateProperty =
        AvaloniaProperty.Register<UiButton, ControlTemplate?>(nameof(IconTemplate));

    public ControlTemplate? IconTemplate
    {
        get => GetValue(IconTemplateProperty);
        set => SetValue(IconTemplateProperty, value);
    }

    #endregion

    #region Brushes

    public static readonly StyledProperty<IBrush> MouseOverBackgroundProperty =
        AvaloniaProperty.Register<UiButton, IBrush>(nameof(MouseOverBackground));

    public IBrush MouseOverBackground
    {
        get => GetValue(MouseOverBackgroundProperty);
        set => SetValue(MouseOverBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseOverForegroundProperty =
        AvaloniaProperty.Register<UiButton, IBrush>(nameof(MouseOverForeground));

    public IBrush MouseOverForeground
    {
        get => GetValue(MouseOverForegroundProperty);
        set => SetValue(MouseOverForegroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseDownBackgroundProperty =
        AvaloniaProperty.Register<UiButton, IBrush>(nameof(MouseDownBackground));

    public IBrush MouseDownBackground
    {
        get => GetValue(MouseDownBackgroundProperty);
        set => SetValue(MouseDownBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseDownForegroundProperty =
        AvaloniaProperty.Register<UiButton, IBrush>(nameof(MouseDownForeground));

    public IBrush MouseDownForeground
    {
        get => GetValue(MouseDownForegroundProperty);
        set => SetValue(MouseDownForegroundProperty, value);
    }

    //public static readonly StyledProperty<IBrush> CheckedBackgroundProperty =
    //    AvaloniaProperty.Register<UiButton, IBrush>(nameof(CheckedBackground));

    //public IBrush CheckedBackground
    //{
    //    get => GetValue(CheckedBackgroundProperty);
    //    set => SetValue(CheckedBackgroundProperty, value);
    //}

    //public static readonly StyledProperty<IBrush> CheckedForegroundProperty =
    //    AvaloniaProperty.Register<UiButton, IBrush>(nameof(CheckedForeground));

    //public IBrush CheckedForeground
    //{
    //    get => GetValue(CheckedForegroundProperty);
    //    set => SetValue(CheckedForegroundProperty, value);
    //}

    #endregion
}
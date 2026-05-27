using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;

namespace Milki.OsuPlayer.UiComponents;

public class UiTextBox : TextBox
{
    #region Icons

    public static readonly StyledProperty<Thickness> IconMarginProperty =
        AvaloniaProperty.Register<UiTextBox, Thickness>(nameof(IconMargin), new Thickness(0, 0, 8, 0));

    public Thickness IconMargin
    {
        get => GetValue(IconMarginProperty);
        set => SetValue(IconMarginProperty, value);
    }

    public static readonly StyledProperty<double> IconSizeProperty =
        AvaloniaProperty.Register<UiTextBox, double>(nameof(IconSize), 24d);

    public double IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }

    public static readonly StyledProperty<ControlTemplate?> IconTemplateProperty =
        AvaloniaProperty.Register<UiTextBox, ControlTemplate?>(nameof(IconTemplate));

    public ControlTemplate? IconTemplate
    {
        get => GetValue(IconTemplateProperty);
        set => SetValue(IconTemplateProperty, value);
    }

    #endregion

    #region Brushes

    public static readonly StyledProperty<IBrush> MouseOverBackgroundProperty =
        AvaloniaProperty.Register<UiTextBox, IBrush>(nameof(MouseOverBackground));

    public IBrush MouseOverBackground
    {
        get => GetValue(MouseOverBackgroundProperty);
        set => SetValue(MouseOverBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseOverForegroundProperty =
        AvaloniaProperty.Register<UiTextBox, IBrush>(nameof(MouseOverForeground));

    public IBrush MouseOverForeground
    {
        get => GetValue(MouseOverForegroundProperty);
        set => SetValue(MouseOverForegroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseDownBackgroundProperty =
        AvaloniaProperty.Register<UiTextBox, IBrush>(nameof(MouseDownBackground));

    public IBrush MouseDownBackground
    {
        get => GetValue(MouseDownBackgroundProperty);
        set => SetValue(MouseDownBackgroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> MouseDownForegroundProperty =
        AvaloniaProperty.Register<UiTextBox, IBrush>(nameof(MouseDownForeground));

    public IBrush MouseDownForeground
    {
        get => GetValue(MouseDownForegroundProperty);
        set => SetValue(MouseDownForegroundProperty, value);
    }

    public static readonly StyledProperty<IBrush> FocusedBorderBrushProperty =
        AvaloniaProperty.Register<UiTextBox, IBrush>(nameof(FocusedBorderBrush));

    public IBrush FocusedBorderBrush
    {
        get => GetValue(FocusedBorderBrushProperty);
        set => SetValue(FocusedBorderBrushProperty, value);
    }

    #endregion

    #region Popups

    public static readonly StyledProperty<bool> IsPopupOpenedProperty =
        AvaloniaProperty.Register<UiTextBox, bool>(nameof(IsPopupOpened));

    public bool IsPopupOpened
    {
        get => GetValue(IsPopupOpenedProperty);
        set => SetValue(IsPopupOpenedProperty, value);
    }

    public static readonly StyledProperty<string> PopupTextProperty =
        AvaloniaProperty.Register<UiTextBox, string>(nameof(PopupText));

    public string PopupText
    {
        get => GetValue(PopupTextProperty);
        set => SetValue(PopupTextProperty, value);
    }

    #endregion

    public static readonly StyledProperty<bool> AcceptOnlyNumberAndEnglishProperty =
        AvaloniaProperty.Register<UiTextBox, bool>(nameof(AcceptOnlyNumberAndEnglish));

    public bool AcceptOnlyNumberAndEnglish
    {
        get => GetValue(AcceptOnlyNumberAndEnglishProperty);
        set => SetValue(AcceptOnlyNumberAndEnglishProperty, value);
    }

    public UiTextBox()
    {
        //https://docs.avaloniaui.net/docs/next/get-started/wpf/tunnelling-events
        AddHandler(InputElement.TextInputEvent, OnPreviewTextInput, RoutingStrategies.Tunnel);
    }

    private void OnPreviewTextInput(object? sender, TextInputEventArgs e)
    {
        if (AcceptOnlyNumberAndEnglish && e.Text is { } text && !IsNumberOrEnglish(text))
        {
            e.Handled = true;
        }
    }

    private static bool IsNumberOrEnglish(string str)
    {
        return MatchRegex.IsMatch(str);
    }

    private static readonly Regex MatchRegex = new(@"^[A-Za-z0-9]+$");
}

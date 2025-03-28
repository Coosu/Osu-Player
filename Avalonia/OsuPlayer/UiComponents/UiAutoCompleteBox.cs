using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using ReactiveUI;

namespace Milki.OsuPlayer.UiComponents;

[TemplatePart(ElementDropDownButton, typeof(Button))]
public class UiAutoCompleteBox : AutoCompleteBox
{
    private static readonly MethodInfo MethodPopulateDropDown;
    private static readonly MethodInfo MethodOpeningDropDown;
    private static readonly FieldInfo FieldIgnorePropertyChange;
    private static readonly PropertyInfo PropTextBox;

    private static readonly object[] MethodOpeningDropDownParameters;
    private readonly object?[] _methodPopulateDropDownParameters;

    static UiAutoCompleteBox()
    {
        var type = typeof(AutoCompleteBox);
        const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        MethodPopulateDropDown = type.GetMethod("PopulateDropDown", bindingFlags) ??
                                  throw new MissingMethodException("AutoCompleteBox", "PopulateDropDown");
        MethodOpeningDropDown = type.GetMethod("OpeningDropDown", bindingFlags) ??
                                 throw new MissingMethodException("AutoCompleteBox", "OpeningDropDown");
        MethodOpeningDropDownParameters = new object[] { false };
        FieldIgnorePropertyChange =
            typeof(AutoCompleteBox).GetField("_ignorePropertyChange", BindingFlags.NonPublic | BindingFlags.Instance) ??
            throw new MissingFieldException("AutoCompleteBox", "_ignorePropertyChange");
        PropTextBox = type.GetProperty("TextBox", BindingFlags.Instance | BindingFlags.NonPublic) ??
                       throw new MissingMethodException("AutoCompleteBox", "get_TextBox");
    }

    private bool _isDropDownBind;
    private const string ElementDropDownButton = "PART_DropDownButton";

    public UiAutoCompleteBox()
    {
        _methodPopulateDropDownParameters = new object?[] { this, EventArgs.Empty };
    }

    private Button? _dropDownButton;
    private TextBox? _textBox;

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _dropDownButton = e.NameScope.Find<Button>(ElementDropDownButton);
        _textBox = (TextBox?)PropTextBox?.GetValue(this);
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        KeyUp += OnKeyUp;
        DropDownOpening += OnDropDownOpening;
        GotFocus += OnGotFocus;
        PointerReleased += OnPointerReleased;
        Task.Delay(50).ContinueWith(_ => Dispatcher.UIThread.Invoke(() =>
        {
            CreateDropdownButton.Execute(null);
        }));
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);

        KeyUp -= OnKeyUp;
        DropDownOpening -= OnDropDownOpening;
        GotFocus -= OnGotFocus;
        PointerReleased -= OnPointerReleased;
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (e is { KeyModifiers: KeyModifiers.None, Key: Key.Down or Key.Enter or Key.Back })
        {
            if (string.IsNullOrEmpty(Text))
            {
                ShowDropdown.Execute(null);
            }
        }
    }

    private void OnDropDownOpening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        if (_textBox is not null && _textBox.IsReadOnly)
        {
            e.Cancel = true;
        }
    }

    private void OnGotFocus(object? sender, RoutedEventArgs e)
    {
        CreateDropdownButton.Execute(null);
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            ShowDropdown.Execute(null);
        }
    }

    private ICommand ShowDropdown => ReactiveCommand.Create(() =>
    {
        if (IsDropDownOpen) return;

        MethodPopulateDropDown?.Invoke(this, _methodPopulateDropDownParameters);
        MethodOpeningDropDown?.Invoke(this, MethodOpeningDropDownParameters);

        if (IsDropDownOpen) return;

        //We *must* set the field and not the property as we need to avoid the changed event being raised (which prevents the dropdown opening).
        if (FieldIgnorePropertyChange?.GetValue(this) is false)
        {
            FieldIgnorePropertyChange?.SetValue(this, true);
        }

        SetCurrentValue(IsDropDownOpenProperty, true);
    });

    private ICommand CreateDropdownButton => ReactiveCommand.Create(() =>
    {
        if (_isDropDownBind) return;

        if (_dropDownButton is not { } button) return;

        button.Click += (s, e) =>
        {
            if (_textBox != null)
            {
                _textBox.SelectAll();
                _textBox.Focus();
            }

            ShowDropdown.Execute(null);
        };

        _isDropDownBind = true;
    });
}
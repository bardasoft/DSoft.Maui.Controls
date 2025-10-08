namespace DSoft.Maui.Controls;

public abstract class SelectableContentView : ContentView
{
    #region ForegroundColor

    public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(nameof(ForegroundColor), typeof(Color), typeof(SelectableContentView), null, propertyChanged: OnForegroundColorChanged);

    /// <summary>
    /// Gets or sets the <see cref="Color"/> which will fill the foreground color for text. This is a bindable property.
    /// </summary>
    public Color ForegroundColor
    {
        get => (Color)GetValue(ForegroundColorProperty);
        set => SetValue(ForegroundColorProperty, value);
    }

    private static void OnForegroundColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
        var templateView = bindable as SelectableContentView;

        if (newValue is Color newColor)
        {
            templateView.UpdateForForegroundColorChange(newColor);
        }
    }

    protected abstract void UpdateForForegroundColorChange(Color color);

    #endregion

    #region Foreground Secondary Color

    public static readonly BindableProperty ForegroundSecondaryColorProperty = BindableProperty.Create(nameof(ForegroundSecondaryColor), typeof(Color), typeof(SelectableContentView), null, propertyChanged: OnForegroundSecondaryColorChanged);

    public Color ForegroundSecondaryColor
    {
        get => (Color)GetValue(ForegroundSecondaryColorProperty);
        set => SetValue(ForegroundSecondaryColorProperty, value);
    }

    static void OnForegroundSecondaryColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
        var templateView = bindable as SelectableContentView;

        if (newValue is Color newColor)
        {
            templateView.UpdateForForegroundSecondaryColorChange(newColor);
        }
    }


    protected abstract void UpdateForForegroundSecondaryColorChange(Color color);

    #endregion

    #region Highlight Color Changed

    public static readonly BindableProperty HighlightColorProperty = BindableProperty.Create(nameof(HighlightColor), typeof(Color), typeof(SelectableContentView), null, propertyChanged: OnHighlightColorChanged);

    public Color HighlightColor
    {
        get => (Color)GetValue(HighlightColorProperty);
        set => SetValue(HighlightColorProperty, value);
    }


    static void OnHighlightColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
        var templateView = bindable as SelectableContentView;

        if (newValue is Color newColor)
        {
            templateView.UpdateForHighlightColorChange(newColor);
        }
    }

    protected abstract void UpdateForHighlightColorChange(Color color);

    #endregion

    #region Selection Color

    public static readonly BindableProperty SelectionColorProperty = BindableProperty.Create(nameof(SelectionColor), typeof(Color), typeof(SelectableContentView), null, propertyChanged: OnSelectionColorChanged);

    public Color SelectionColor
    {
        get => (Color)GetValue(SelectionColorProperty);
        set => SetValue(SelectionColorProperty, value);
    }

    static void OnSelectionColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
        var templateView = bindable as SelectableContentView;

        if (newValue is Color newColor)
        {
            templateView.UpdateForSelectionColorChange(newColor);
        }
    }

    protected abstract void UpdateForSelectionColorChange(Color color);

    #endregion

    #region Hightlight Text Color

    public static readonly BindableProperty HighlightTextColorProperty = BindableProperty.Create(nameof(HighlightTextColor), typeof(Color), typeof(SelectableContentView), null, propertyChanged: OnHighlightTextColorChanged);

    public Color HighlightTextColor
    {
        get => (Color)GetValue(HighlightTextColorProperty);
        set => SetValue(HighlightTextColorProperty, value);
    }

    static void OnHighlightTextColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
        var templateView = bindable as SelectableContentView;

        if (newValue is Color newColor)
        {
            templateView.UpdateForHighlightTextColorChange(newColor);
        }
    }

    protected abstract void UpdateForHighlightTextColorChange(Color color);

    #endregion

    public SelectableContentView()
	{
		
	}
}
using DSoft.Maui.Controls.Events;
using System.Diagnostics;

// Based on: https://redth.codes/building-a-step-by-step-wizard-control-in-net-maui
// Some bindings Inspired by: https://github.com/InquisitorJax/MAUI-Controls/tree/main

namespace DSoft.Maui.Controls;

public class WizardView : Grid
{
    private bool _isBusy;

    public event EventHandler<StepChangedEventArgs> StepChanged;

    #region Enable Looping Property

    public static readonly BindableProperty EnableLoopingProperty = BindableProperty.Create(nameof(EnableLooping), typeof(bool), typeof(WizardView), false, BindingMode.OneWay);

    public bool EnableLooping
    {
        get { return (bool)GetValue(EnableLoopingProperty); }
        set { SetValue(EnableLoopingProperty, value); }
    }

    #endregion

    #region Position

    public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(int), typeof(WizardView), 0, BindingMode.TwoWay, propertyChanged: OnPositionChanged);

    private static async void OnPositionChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is WizardView view)
        {
            await view.MoveToPosition();
        }
    }

    public int Position
    {
        get { return (int)GetValue(PositionProperty); }
        set { SetValue(PositionProperty, value); }
    }

    #endregion

    #region Content Count

    public static readonly BindableProperty ChildCountProperty = BindableProperty.Create(nameof(ChildCount), typeof(int), typeof(WizardView), 0, BindingMode.OneWayToSource);

    public int ChildCount
    {
        get { return (int)GetValue(ChildCountProperty); }
        set { SetValue(ChildCountProperty, value); }
    }

    #endregion


    public int GetCurrentIndex()
    {
        for (var i = 0; i < Children.Count; i++)
        {
            if (Children[i] is VisualElement ve && ve.IsVisible)
                return i;
        }

        return -1;
    }

    protected override void OnChildAdded(Element child)
    {
        if (child is VisualElement ve)
        {
            ve.IsVisible = false;

            if (GetCurrentIndex() < 0)
            {
                ve.IsVisible = true;
            }
        }

        base.OnChildAdded(child);

        ChildCount = this.Children.Count;
    }

    public async Task Forward()
    {
        if (_isBusy)
            return;

        _isBusy = true;

        try
        {
            var c = GetCurrentIndex();

            var currentIndex = c;
            var nextIndex = c + 1;

            if (nextIndex >= Children.Count)
            {
                if (EnableLooping)
                {
                    nextIndex = 0;
                }
                else
                {
                    return;
                }
            }

            if (currentIndex == nextIndex)
                return;

            var currentView = Children[currentIndex] as VisualElement;
            var nextView = Children[nextIndex] as VisualElement;

            // Prepare the 'next' view to show, moving it out of 
            // view, by setting its x translation to the right of
            // our container (container's width)
            nextView.TranslationX = this.Width;
            // Make the 'next' view visible so we see it sliding in
            // now that it's translated outside of the container view and not 'seen'
            nextView.IsVisible = true;

            // Animate the translation of both the 'next' and 'current'
            // views so that we get a slide effect
            // The 'next' view slides in from the right and the
            // current view slides out of view to the right
            await Task.WhenAll(
                nextView.TranslateTo(0, 0, 500, Easing.CubicInOut),
                currentView.TranslateTo(-1 * this.Width, 0, 500, Easing.CubicInOut));

            // Reset the visibility and translation of the
            // current (now previous) view now that the animation is complete
            currentView.IsVisible = false;
            currentView.TranslationX = 0;

            // Invoke an event to know the step changed
            StepChanged?.Invoke(this, new StepChangedEventArgs(currentIndex, nextIndex));
            Position = nextIndex;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        finally 
        { 
            _isBusy = false; 
        }

    }

    public async Task Back()
    {
        if (_isBusy)
            return;

        _isBusy = true;

        try
        {
            var c = GetCurrentIndex();

            var currentIndex = c;
            var nextIndex = c - 1;

            if (nextIndex < 0)
            {
                if (EnableLooping)
                {
                    nextIndex = Children.Count - 1;
                }
                else
                {
                    return;
                }
            }

            if (currentIndex == nextIndex)
                return;

            var currentView = Children[currentIndex] as VisualElement;
            var nextView = Children[nextIndex] as VisualElement;

            // Prepare the 'next' view to show, moving it out of 
            // view, by setting its x translation to the right of
            // our container (container's width)
            nextView.TranslationX = -this.Width;
            // Make the 'next' view visible so we see it sliding in
            // now that it's translated outside of the container view and not 'seen'
            nextView.IsVisible = true;

            // Animate the translation of both the 'next' and 'current'
            // views so that we get a slide effect
            // The 'next' view slides in from the right and the
            // current view slides out of view to the right
            await Task.WhenAll(
                nextView.TranslateTo(0, 0, 500, Easing.CubicInOut),
                currentView.TranslateTo(this.Width, 0, 500, Easing.CubicInOut));

            // Reset the visibility and translation of the
            // current (now previous) view now that the animation is complete
            currentView.IsVisible = false;
            currentView.TranslationX = 0;

            // Invoke an event to know the step changed
            StepChanged?.Invoke(this, new StepChangedEventArgs(currentIndex, nextIndex));
            Position = nextIndex;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        finally
        {
            _isBusy = false;
        }


    }

    private async Task MoveToPosition()
    {
        var currentVisibleIndex = GetCurrentIndex();

        if (Position == currentVisibleIndex) 
            return;
        
        if (Position > currentVisibleIndex)
            await Forward();
        else
            await Back();
    }
}
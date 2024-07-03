using HandyControl.Data;
using HandyControl.Interactivity;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HandyControl.Controls;

[TemplatePart(Name = ElementContentPresenter, Type = typeof(ContentPresenter))]
[TemplatePart(Name = ElementSearchBar, Type = typeof(SearchBar))]
public class PropertyGrid : Control
{
    public static readonly DependencyProperty ColumnProperty = DependencyProperty.Register(nameof(Column), typeof(Column), typeof(PropertyGrid), new PropertyMetadata(Column.One));
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description), typeof(string), typeof(PropertyGrid), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty IsGroupProperty =
        DependencyProperty.Register("IsGroup", typeof(bool), typeof(PropertyGrid), new PropertyMetadata(true));

    public static readonly DependencyProperty MaxTitleWidthProperty = DependencyProperty.Register(
        nameof(MaxTitleWidth), typeof(double), typeof(PropertyGrid), new PropertyMetadata(ValueBoxes.Double0Box));

    public static readonly DependencyProperty MinTitleWidthProperty = DependencyProperty.Register(
        nameof(MinTitleWidth), typeof(double), typeof(PropertyGrid), new PropertyMetadata(ValueBoxes.Double0Box));

    public static readonly RoutedEvent SelectedObjectChangedEvent =
        EventManager.RegisterRoutedEvent("SelectedObjectChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<object>), typeof(PropertyGrid));

    //Dependency property
    public static readonly DependencyProperty SelectedObjectProperty = DependencyProperty.Register(
        nameof(SelectedObject), typeof(object), typeof(PropertyGrid), new PropertyMetadata(default, OnSelectedObjectChanged));

    public static readonly DependencyProperty ShowSortButtonProperty = DependencyProperty.Register(
        nameof(ShowSortButton), typeof(bool), typeof(PropertyGrid), new PropertyMetadata(ValueBoxes.TrueBox));

    private const string ElementContentPresenter = "PART_ContentPresenter";

    private const string ElementSearchBar = "PART_SearchBar";

    private ICollectionView _dataView;
    private SearchBar _searchBar;
    private string _searchKey;
    private ContentPresenter control;
    public PropertyGrid()
    {
        CommandBindings.Add(new CommandBinding(ControlCommands.SortByCategory, SortByCategory, (s, e) => e.CanExecute = ShowSortButton));
        CommandBindings.Add(new CommandBinding(ControlCommands.SortByName, SortByName, (s, e) => e.CanExecute = ShowSortButton));
    }

    public event RoutedPropertyChangedEventHandler<object> SelectedObjectChanged
    {
        add => AddHandler(SelectedObjectChangedEvent, value);
        remove => RemoveHandler(SelectedObjectChangedEvent, value);
    }

    public Column Column
    {
        get => (Column)GetValue(ColumnProperty);
        set => SetValue(ColumnProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public bool IsGroup
    {
        get { return (bool)GetValue(IsGroupProperty); }
        set { SetValue(IsGroupProperty, value); }
    }

    public double MaxTitleWidth
    {
        get => (double)GetValue(MaxTitleWidthProperty);
        set => SetValue(MaxTitleWidthProperty, value);
    }

    public double MinTitleWidth
    {
        get => (double)GetValue(MinTitleWidthProperty);
        set => SetValue(MinTitleWidthProperty, value);
    }

    public virtual PropertyResolver PropertyResolver { get; } = new();
    public object SelectedObject
    {
        get => GetValue(SelectedObjectProperty);
        set => SetValue(SelectedObjectProperty, value);
    }

    public bool ShowSortButton
    {
        get => (bool)GetValue(ShowSortButtonProperty);
        set => SetValue(ShowSortButtonProperty, ValueBoxes.BooleanBox(value));
    }

    //logic
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        control = Template.FindName(ElementContentPresenter, this) as ContentPresenter;

        UpdateItems(SelectedObject);
    }

    protected virtual PropertyItem CreatePropertyItem(PropertyDescriptor propertyDescriptor) => new()
    {
        Category = PropertyResolver.ResolveCategory(propertyDescriptor),
        DisplayName = PropertyResolver.ResolveDisplayName(propertyDescriptor),
        Description = PropertyResolver.ResolveDescription(propertyDescriptor),
        IsReadOnly = PropertyResolver.ResolveIsReadOnly(propertyDescriptor),
        DefaultValue = PropertyResolver.ResolveDefaultValue(propertyDescriptor),
        Editor = PropertyResolver.ResolveEditor(propertyDescriptor),
        Value = SelectedObject,
        PropertyName = propertyDescriptor.Name,
        PropertyType = propertyDescriptor.PropertyType,
        PropertyTypeName = $"{propertyDescriptor.PropertyType.Namespace}.{propertyDescriptor.PropertyType.Name}"
    };

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        TitleElement.SetTitleWidth(this, new GridLength(Math.Max(MinTitleWidth, Math.Min(MaxTitleWidth, ActualWidth / 3))));
    }

    protected virtual void OnSelectedObjectChanged(object oldValue, object newValue)
    {
        UpdateItems(newValue);
        RaiseEvent(new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, SelectedObjectChangedEvent));
    }

    private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var ctl = (PropertyGrid)d;
        ctl.OnSelectedObjectChanged(e.OldValue, e.NewValue);
    }
    private FrameworkElement CreateLabelForNameProperty(PropertyItem propertyInfo)
    {
        TextBlock textBlock = new()
        {
            Text = propertyInfo.DisplayName,
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
        };
        return textBlock;
    }

    private FrameworkElement CreateStackPanel(PropertyItem property)
    {
        StackPanel stackPanel = new()
        {
            Orientation = Orientation.Vertical
        };
        var label = CreateLabelForNameProperty(property);
        var inputControl = property.InitElement();
        stackPanel.Children.Add(label);
        stackPanel.Children.Add(inputControl);
        return stackPanel;
    }

    private void DefaultComlumn(List<PropertyItem> properties, GridLength gridLength, ContentPresenter content)
    {
        Grid grid = new()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };
        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });
        var labels = new List<FrameworkElement>();
        var inputControls = new List<FrameworkElement>();
        int count = 0;
        foreach (var property in properties)
        {
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            inputControls.Add(property.InitElement());
            labels.Add(CreateLabelForNameProperty(property));
            Grid.SetColumn(labels[count], 0);
            Grid.SetColumn(inputControls[count], 1);
            Grid.SetRow(labels[count], count);
            Grid.SetRow(inputControls[count], count);
            count++;
        }
        foreach (var label in labels)
        {
            grid.Children.Add(label);
        }
        foreach (var inputControl in inputControls)
        {
            grid.Children.Add(inputControl);
        }
        if (content == null)
        {
            return;
        }
        ScrollViewer scrollViewer = new ScrollViewer();
        scrollViewer.Content = grid;
        content.Content = scrollViewer;
    }

    // generate ui
    private void GenerateEditor(ContentPresenter content, List<PropertyItem> properties)
    {
        content.Content = null;
        var col = 2;
        if (SelectedObject == null)
        {
            return;
        }
        GridLength widthType = new();
        if (Column == Column.Default)
        {
            widthType = new GridLength(3, GridUnitType.Star);
            DefaultComlumn(properties, widthType, content);
            return;
        }
        if (Column == Column.One)
        {
            widthType = new GridLength(9, GridUnitType.Star);
            OneColumn(properties, widthType, content);
            return;
        }
        widthType = new GridLength(3, GridUnitType.Star);
        TwoColumn(properties, col, widthType, content);
        _dataView = CollectionViewSource.GetDefaultView(content);
    }

    private void OneColumn(List<PropertyItem> properties, GridLength gridLength, ContentPresenter content)
    {
        Grid grid = new()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };
        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
        var labels = new List<FrameworkElement>();
        var inputControls = new List<FrameworkElement>();
        int count = 0;
        int propertyIndex = 0;
        for (int i = 0; i < properties.Count * 2; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
        }
        foreach (var property in properties)
        {
            inputControls.Add(property.InitElement());
            labels.Add(CreateLabelForNameProperty(property));
            Grid.SetColumn(labels[propertyIndex], 0);
            Grid.SetColumn(inputControls[propertyIndex], 0);
            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    Grid.SetRow(labels[propertyIndex], count);
                    count++;
                    continue;
                }
                Grid.SetRow(inputControls[propertyIndex], count);
                count++;
            }
            propertyIndex++;
        }
        foreach (var label in labels)
        {
            grid.Children.Add(label);
        }
        foreach (var inputControl in inputControls)
        {
            grid.Children.Add(inputControl);
        }
        if (content == null)
        {
            return;
        }
        ScrollViewer scrollViewer = new ScrollViewer();
        scrollViewer.Content = grid;
        content.Content = scrollViewer;
    }

    private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
    {
        //TO DO
    }

    private void SetGrid(List<FrameworkElement> stackPanels, PropertyItem property, int row, int col)
    {
        var stackPanel = CreateStackPanel(property);
        stackPanels.Add(stackPanel);
        Grid.SetColumn(stackPanel, col);
        Grid.SetRow(stackPanel, row);
    }

    private void SortByCategory(object sender, ExecutedRoutedEventArgs e)
    {
        //TO DO
    }

    private void SortByName(object sender, ExecutedRoutedEventArgs e)
    {
        //TO DO
    }

    private void TwoColumn(List<PropertyItem> properties, int col, GridLength gridLength, ContentPresenter content)
    {
        Grid grid = new()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };
        for (int i = 0; i < col * 2; i++)
        {
            if (i == 0 || i == 3)
            {
                var width = new GridLength(2, GridUnitType.Star);
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = width });
                continue;
            }
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLength });
        }
        int mid = properties.Count / 2;
        var residual = properties.Count % 2; // phần dư != 0 thì lẻ 1 property
        var stackPanels = new List<FrameworkElement>();
        int count = 0;
        int row = 0;
        // init rowdefination
        for (int i = 0; i < mid + 1; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
        }
        // set grid
        foreach (var property in properties)
        {
            if (residual == 0)
            {
                if (count < mid)
                {
                    SetGrid(stackPanels, property, row, 1);
                    count++;
                    row++;
                    continue;
                }
                if (count == mid)
                {
                    row = 0;
                }
                SetGrid(stackPanels, property, row, 2);
                count++;
                row++;
                continue;
            }
            if (count <= mid)
            {
                SetGrid(stackPanels, property, row, 1);
                count++;
                row++;
                continue;
            }
            if (count == mid + 1)
            {
                row = 0;
            }
            SetGrid(stackPanels, property, row, 2);
            count++;
            row++;
        }
        foreach (var stackpanel in stackPanels)
        {
            grid.Children.Add(stackpanel);
        }
        if (content == null)
        {
            return;
        }
        ScrollViewer scrollViewer = new ScrollViewer();
        scrollViewer.Content = grid;
        content.Content = scrollViewer;
    }

    private void UpdateItems(object obj)
    {
        if (obj == null || control == null) return;
        //get all property
        var properties = TypeDescriptor.GetProperties(obj.GetType()).OfType<PropertyDescriptor>().Where(item => PropertyResolver.ResolveIsBrowsable(item)).Select(CreatePropertyItem).ToList();

        if (IsGroup)
        {
            SortByCategory(null, null);
        }
        GenerateEditor(control, properties);
    }
}

public enum Column
{
    One,
    Two,
    Default
}
﻿using HandyControl.Controls;
using System.Windows;

namespace Management.UI.CustomControls.PropertyGrid.Editors
{
    public abstract class BaseEditor : PropertyEditorBase
    {
        public abstract override FrameworkElement CreateElement(PropertyItem propertyItem);

        public abstract override DependencyProperty GetDependencyProperty();
    }
}
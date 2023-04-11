// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PieChart_GroupedDataLabel
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
    }

    public class DataLabelXValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ChartDataLabel pieAdornment = value as ChartDataLabel;
            if(pieAdornment.Item is List<object>)
            {
                return "Others";
            }
            else if ((pieAdornment.Item as Model).Product != null)
            {

                return string.Format((pieAdornment.Item as Model).Product.ToString());

            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class DataLabelYValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ChartDataLabel pieAdornment = value as ChartDataLabel;
            if (pieAdornment.Item is List<object>)
            {
                var data = pieAdornment.Item as List<object>;
                var yValue = data.Sum(item => (item as Model).SalesPercentage);
                return yValue.ToString("P0");
            }
            else if (!double.IsNaN((pieAdornment.Item as Model).SalesPercentage))
            {

                return (pieAdornment.Item as Model).SalesPercentage.ToString("P0");

            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

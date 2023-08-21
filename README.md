# How to show the "Others” category values in WinUI Pie Chart data label
This sample demonstrates how to show the pie chart data label to “Others” category values in WinUI (SfCircularChart).
<br><br>
The ContentTemplate property can be used to customize the data label of the pie chart by using the Context property with an IValueConverter. To show the data label in the "Others" category, we can use the GroupTo and GroupMode properties in the CircularSeries. The following code example demonstrates how to bind the data label of the pie chart to the "Others" category in the SfCircularChart.

**[XAML]**
```
<Grid>
…
        <Grid.Resources>
            <local:DataLabelXValueConverter x:Key="dataLabelXValue"/>
            <local:DataLabelYValueConverter x:Key="dataLabelYValue" />
            <DataTemplate x:Key="dataLabelTemplate">
                <StackPanel BorderBrush="Black" BorderThickness="1" 
                                        CornerRadius="2"         Orientation="Horizontal">
                    <TextBlock Foreground="Black" FontWeight="Bold" 
                                         Text="{Binding Converter={StaticResource dataLabelXValue}}" />
                    <TextBlock Text=":  " Foreground="Black" FontWeight="Bold"/>
                    <TextBlock Foreground="Black" FontWeight="Bold" 
                                         Text="{Binding Converter={StaticResource dataLabelYValue}}"  />
                </StackPanel>
            </DataTemplate>
         <chart:SfCircularChart >
            <chart:PieSeries XBindingPath="Product"  ShowDataLabels="True" Radius="0.7"
                             GroupTo="10" GroupMode="Percentage" YBindingPath="SalesPercentage"
                             ItemsSource="{Binding Data}" >
                <chart:PieSeries.DataLabelSettings>   
                    <chart:CircularDataLabelSettings ShowConnectorLine="True" Context="DataLabelItem" 
                                                 Position="OutsideExtended"    UseSeriesPalette="True" 
                                                 ContentTemplate="{StaticResource dataLabelTemplate}" />
                </chart:PieSeries.DataLabelSettings>
            </chart:PieSeries>
        </chart:SfCircularChart>
    </Grid>

```

**[C#]**
```
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

```

**Output**

<img width="746" alt="Output" src="https://user-images.githubusercontent.com/105482474/231132237-e9c674a4-bb4c-487f-adc5-e7cb7dfe1e8f.png">

**See also**

* [Data template in WinUI Circular chart](https://help.syncfusion.com/winui/circular-charts/datalabels#template).


using System.Collections.ObjectModel;

namespace PieChart_GroupedDataLabel
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model("Coffee",0.27),
                new Model("Biscuits",0.13),
                new Model("Tea", 0.26),
                new Model("Vegetables",0.25),
                new Model("Fruits",0.03),
                new Model("chips",0.05),
                new Model("Drinks",0.01)
            };
        }
    }
}

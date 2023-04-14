namespace PieChart_GroupedDataLabel
{
    public class Model
    {
        public string Product { get; set; }
        public double SalesPercentage { get; set; }

        public Model(string product, double salesPercentage) 
        {
            Product = product;
            SalesPercentage = salesPercentage;
        }
    }
}

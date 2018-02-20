namespace Gijima.Hulamin.Core.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public byte? UnitsInStock { get; set; }
        public byte? UnitsOnOrder { get; set; }
        public byte? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}

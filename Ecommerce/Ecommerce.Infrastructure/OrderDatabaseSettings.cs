namespace Ecommerce.Infrastructure
{
    public class OrderDatabaseSettings : IOrderDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
namespace Ecommerce.Infrastructure
{
    public interface IOrderDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

namespace BulletAPI.Models
{
    public interface IBulletToDoDatabase
    {
        string BulletCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class BulletToDoDatabase : IBulletToDoDatabase
    {
        public string BulletCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
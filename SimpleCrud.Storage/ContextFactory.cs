using SimpleCrud.Infrastructure.Configuration;
using SimpleCrud.Storage.Models;

namespace SimpleCrud.Storage
{
    public static class ContextFactory
    {
        public static EascahireDbContext Create()
        {
            return new EascahireDbContext(ConfigProvider.ConnectionString);
        }
    }
}

using System.Data.Entity;
using Model.Entities;

namespace Model
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
            : base("erp")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

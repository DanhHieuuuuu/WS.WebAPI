using Microsoft.EntityFrameworkCore;
using WS.Order.Domain;
using WS.Product.Domain;

namespace WS.Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        public DbSet<OrderCart> OrderCarts  { get; set; }
        public DbSet<OrderOrder> OrderOrders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.OrderId);
            base.OnModelCreating(modelBuilder);
        }

    }
}

using Microsoft.EntityFrameworkCore;

namespace Test4.Models
{
    public class CFContext:DbContext
    {
        public CFContext(
                DbContextOptions<CFContext> options) : base(options) { }

        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
    }
}

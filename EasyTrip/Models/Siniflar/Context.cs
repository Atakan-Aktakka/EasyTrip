using EasyTrip.Data;
using Microsoft.EntityFrameworkCore;
namespace EasyTrip.Models.Siniflar
{//T Buranın ne olacağı belli değil ama sınıf oluşturulurklen sana söyleyeceğim.
	//List<Admin> 
	//List<T> 
	public class Context:DbContext
	{
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
		public DbSet<AdresBlog> AdresBlogs { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Hakkimizda> Hakkimizdas { get; set; }
		public DbSet<iletisim> iletisims { get; set; }
		public DbSet<Yorumlar> Yorumlars { get; set; }
	}
}

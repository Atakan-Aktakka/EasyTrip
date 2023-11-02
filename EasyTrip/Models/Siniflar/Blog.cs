using System.ComponentModel.DataAnnotations;

namespace EasyTrip.Models.Siniflar
{
	public class Blog
	{
		[Key]
        public int ID { get; set; }
		public string Baslik { get; set; }
		public DateTime Tarih { get; set; }
		public string Aciklma { get; set; }
		public string BlogImage { get; set; }
		public ICollection<Yorumlar> Yorumlars { get; set; }
	}
}

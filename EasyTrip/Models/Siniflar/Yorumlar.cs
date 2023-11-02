using System.ComponentModel.DataAnnotations;

namespace EasyTrip.Models.Siniflar
{
	public class Yorumlar
	{
        [Key]
        public int ID { get; set; }
        public string KullniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int Blogid { get; set; }
        public virtual Blog Blog { get; set; }
    }
}

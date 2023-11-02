using System.ComponentModel.DataAnnotations;

namespace EasyTrip.Models.Siniflar
{
	public class Anasayfa
	{
		[Key]
		public int ID {  get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
    }
}

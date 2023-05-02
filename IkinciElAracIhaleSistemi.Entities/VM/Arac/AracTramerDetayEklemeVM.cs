namespace IkinciElAracIhaleSistemi.Entities.VM.Arac
{
	public class AracTramerDetayEklemeVM
	{
		public int AracId { get; set; }
		public decimal Fiyat { get; set; }
		public AracTramerDetayChildVM[] Children { get; set; }
	}

	public class AracTramerDetayChildVM
	{
		public int ParcaId { get; set; }
		public int TramerId { get; set; }
	}

	public class AracTramerDetayGoruntulemeVM
	{
		public int AracId { get; set; }
		public int ParcaId { get; set; }
		public string ParcaAdi { get; set; }
		public decimal ToplamFiyat { get; set; } // eklediğimiz property
		public AracTramerDetayChildGoruntulemeVM[] Children { get; set; }
	}


	public class AracTramerDetayChildGoruntulemeVM
	{
		public int ParcaId { get; set; }
		public int TramerId { get; set; }
		public string ParcaAdi { get; set; }
		public string DurumAdi { get; set; }
	}
}

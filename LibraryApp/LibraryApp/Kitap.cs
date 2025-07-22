namespace library
{
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }

        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }
    }
}
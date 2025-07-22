namespace library
{
    public class UserVerify
    {
        public string Kullanici { get; set; }
        public string Sifre { get; set; }

        public UserVerify(string kullanici, string sifre)
        {
            Kullanici = kullanici;
            Sifre = sifre;
        }
    }
}
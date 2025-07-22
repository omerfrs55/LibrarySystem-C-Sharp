
namespace library
{
    public class AdminVerify
    {
        public string Admin { get; set; }
        public string Sifre { get; set; }

        public AdminVerify(string admin, string sifre)
        {
            Admin = admin;
            Sifre = sifre;
        }
    }
}
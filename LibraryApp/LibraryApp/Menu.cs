using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace library
{

    public class Menu
    {
        private static List<Kitap> kitaplar = new List<Kitap>
        {
            new Kitap("Kürk Mantolu Madonna", "Sabahattin Ali"),
            new Kitap("Suç ve Ceza", "Fyodor Dostoyevski"),
            new Kitap("Sefiller", "Victor Hugo"),
            new Kitap("1984", "George Orwell"),
            new Kitap("Simyacı", "Paulo Coelho")
        };

        private static List<UserVerify> kullaniciListesi = new List<UserVerify>
        {
            new UserVerify("kullanici1", "sifre1"),
            new UserVerify("kullanici2", "sifre2")
        };
        private static List<AdminVerify> adminListesi = new List<AdminVerify>
        {
            new AdminVerify("admin1", "adminSifre1"),
            new AdminVerify("admin2", "adminSifre2")
        };

        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nKütüphane Menüsüne Hoş geldiniz.");
                Console.WriteLine("1 - Kütüphaneci Girişi");
                Console.WriteLine("2 - Admin Girişi");
                Console.WriteLine("3 - Exit");
                Console.Write("Seçiminiz: ");
                string input = Console.ReadLine();
                int secim;
                if (!int.TryParse(input, out secim))
                {
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    continue;
                }

                if (secim == 1)
                {
                    Console.Write("Kullanıcı adı giriniz: ");
                    string kullanici = Console.ReadLine();
                    Console.Write("Şifre giriniz: ");
                    string sifre = Console.ReadLine();

                    // Kullanıcı doğrulama
                    var user = kullaniciListesi.FirstOrDefault(u => u.Kullanici == kullanici && u.Sifre == sifre);
                    if (user == null)
                    {
                        Console.WriteLine("Kullanıcı adı veya şifre hatalı!");
                        Beklet.beklet(null);
                        continue;
                    }

                    Console.WriteLine($"{kullanici} olarak giriş yapıldı. Hoş geldiniz!");
                    while (true)
                    {
                        Console.WriteLine("1 - Kitap Ekle");
                        Console.WriteLine("2 - Kitap Sil");
                        Console.WriteLine("3 - Kitap Listele");
                        Console.WriteLine("4 - Çıkış");
                        Console.Write("Seçiminiz: ");
                        string kitapSecimInput = Console.ReadLine();
                        int kitapSecim;
                        if (!int.TryParse(kitapSecimInput, out kitapSecim))
                        {
                            Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                            Beklet.beklet(null);
                            continue;
                        }
                        if (kitapSecim == 1)
                        {
                            Console.WriteLine($"{kullanici} lütfen kitap ekleme işlemi için gerekli bilgileri giriniz.");
                            Console.Write("Kitap adı: ");
                            string kitapAdi = Console.ReadLine();
                            if (string.IsNullOrEmpty(kitapAdi) || kitapAdi.Any(char.IsDigit))
                            {
                                Console.WriteLine("Kitap adı boş bırakılamaz veya sayı içeremez.");
                                Beklet.beklet(null);
                                continue;
                            }
                            Console.Write("Yazar adı: ");
                            string yazarAdi = Console.ReadLine();
                            if (string.IsNullOrEmpty(yazarAdi) || yazarAdi.Any(char.IsDigit))
                            {
                                Console.WriteLine("Yazar adı boş bırakılamaz veya sayı içeremez.");
                                Beklet.beklet(null);
                                continue;
                            }
                            kitaplar.Add(new Kitap(kitapAdi, yazarAdi));
                            Console.WriteLine($"Kitap '{kitapAdi}' yazarı '{yazarAdi}' olarak eklendi.");
                            Console.WriteLine("Kitap ekleme işlemi başarılı.");
                            Beklet.beklet(null);
                        }
                        else if (kitapSecim == 2)
                        {
                            Console.Write("Silmek istediğiniz kitabın adını giriniz: ");
                            string silinecekKitap = Console.ReadLine();
                            if (string.IsNullOrEmpty(silinecekKitap))
                            {
                                Console.WriteLine("Kitap adı boş bırakılamaz.");
                                Beklet.beklet(null);
                                continue;
                            }
                            Console.Write("Silmek istediğiniz kitabın yazar adını giriniz: ");
                            string silinecekYazar = Console.ReadLine();
                            if (string.IsNullOrEmpty(silinecekYazar))
                            {
                                Console.WriteLine("Yazar adı boş bırakılamaz.");
                                Beklet.beklet(null);
                                continue;
                            }
                            var kitap = kitaplar.Find(k => k.Ad.Equals(silinecekKitap, StringComparison.OrdinalIgnoreCase)
                                                        && k.Yazar.Equals(silinecekYazar, StringComparison.OrdinalIgnoreCase));
                            if (kitap != null)
                            {
                                kitaplar.Remove(kitap);
                                Console.WriteLine($"'{silinecekKitap}' kitabı '{silinecekYazar}' yazarı ile silindi.");
                                Console.WriteLine("Silme işlemi başarılı.");
                            }
                            else
                            {
                                Console.WriteLine("Belirtilen kitap bulunamadı.");
                                Beklet.beklet(null);
                            }
                            Beklet.beklet(null);
                        }
                        else if (kitapSecim == 3)
                        {
                            Console.WriteLine("Kitaplar listeleniyor...");
                            if (kitaplar.Count == 0)
                            {
                                Console.WriteLine("Kütüphanede hiç kitap yok.");
                            }
                            else
                            {
                                int i = 1;
                                foreach (var kitap in kitaplar)
                                {
                                    Console.WriteLine($"{i++}. {kitap.Ad} - {kitap.Yazar}");
                                }
                            }
                            Beklet.beklet(null);
                        }
                        else if (kitapSecim == 4)
                        {
                            Console.WriteLine("Çıkılıyor...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                            Beklet.beklet(null);
                        }
                    }
                }
                else if (secim == 2)
                {
                    Console.Write("Admin kullanıcı adını giriniz: ");
                    string admin = Console.ReadLine();
                    Console.Write("Şifre giriniz: ");
                    string sifre = Console.ReadLine();

                    // Admin doğrulama
                    var adminUser = adminListesi.FirstOrDefault(a => a.Admin == admin && a.Sifre == sifre);
                    if (adminUser == null)
                    {
                        Console.WriteLine("Admin adı veya şifre hatalı!");
                        Beklet.beklet(null);
                        continue;
                    }

                    Console.WriteLine($"{admin} olarak giriş yapıldı. Hoş geldiniz!");
                    while (true)
                    {
                        Console.WriteLine("1 - Kullanıcı Ekle");
                        Console.WriteLine("2 - Kullanıcı Sil");
                        Console.WriteLine("3 - Kullanıcı Listele");
                        Console.WriteLine("4 - Çıkış");
                        Console.Write("Seçiminiz: ");
                        string adminSecimInput = Console.ReadLine();
                        int adminSecim;
                        if (!int.TryParse(adminSecimInput, out adminSecim))
                        {
                            Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                            Beklet.beklet(null);
                            continue;
                        }
                        if (adminSecim == 1)
                        {
                            Console.Write("Yeni kullanıcı adı: ");
                            string yeniKullanici = Console.ReadLine();
                            Console.Write("Yeni kullanıcı şifresi: ");
                            string yeniSifre = Console.ReadLine();
                            kullaniciListesi.Add(new UserVerify(yeniKullanici, yeniSifre));
                            Console.WriteLine("Kullanıcı eklendi.");
                            Beklet.beklet(null);
                        }
                        else if (adminSecim == 2)
                        {
                            Console.Write("Silinecek kullanıcı adı: ");
                            string silKullanici = Console.ReadLine();
                            var user = kullaniciListesi.FirstOrDefault(u => u.Kullanici == silKullanici);
                            if (user != null)
                            {
                                kullaniciListesi.Remove(user);
                                Console.WriteLine("Kullanıcı silindi.");
                            }
                            else
                            {
                                Console.WriteLine("Kullanıcı bulunamadı.");
                            }
                            Beklet.beklet(null);
                        }
                        else if (adminSecim == 3)
                        {
                            Console.WriteLine("Kullanıcılar:");
                            foreach (var user in kullaniciListesi)
                            {
                                Console.WriteLine($"- {user.Kullanici}");
                            }
                            Beklet.beklet(null);
                        }
                        else if (adminSecim == 4)
                        {
                            Console.WriteLine("Çıkılıyor...");
                            Beklet.beklet(null);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                            Beklet.beklet(null);
                        }
                    }
                }
                else if (secim == 3)
                {
                    Console.WriteLine("Çıkılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    Beklet.beklet(null);
                }
            }
        }
    }


}
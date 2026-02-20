using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Database db = new Database();

        while (true)
        {
            Console.WriteLine("\n1- Kitap Ekle");
            Console.WriteLine("2- Kitapları Listele");
            Console.WriteLine("3- Kitap Sil");
            Console.WriteLine("0- Çıkış");
            Console.Write("Seçim: ");

            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Write("Kitap adı: ");
                string ad = Console.ReadLine();

                Console.Write("Yazar: ");
                string yazar = Console.ReadLine();

                Console.Write("Sayfa sayısı: ");
                int sayfa = int.Parse(Console.ReadLine());

                db.KitapEkle(ad, yazar, sayfa);

                Console.WriteLine("Kitap eklendi.");
            }
            else if (secim == "2")
            {
                List<Kitap> liste = db.KitaplariGetir();

                foreach (var kitap in liste)
                {
                    Console.WriteLine($"{kitap.Id} - {kitap.Ad} - {kitap.Yazar} - {kitap.SayfaSayisi}");
                }

                if (liste.Count == 0)
                    Console.WriteLine("Kayıt bulunamadı.");
            }
            else if(secim == "3")
            {
              Console.Write("Silinecek kitap Id: ");
              int id = int.Parse(Console.ReadLine());
              db.KitapSil(id);
              Console.WriteLine("Kitap silindi.");
            }
            else if (secim == "0")
            {
                break;
            }
        }
    }
}

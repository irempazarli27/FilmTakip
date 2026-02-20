using System;
using System.Collections.Generic;

class Program
{
  static void Main()
    {
        Database db = new Database();

        while(true)
        {
            Console.WriteLine("\n1- Film Ekle");
            Console.WriteLine("2- Filmlri Listele");
            Console.WriteLine("3- Film Sil");
            Console.WriteLine("0- Çıkış");
            Console.Write("Seçim: ");

            string secim = Console.ReadLine();

            if(secim == "1")
            {
                Console.Write("Film adı: ");
                string ad = Console.ReadLine();

                Console.Write("Yönetmen: ");
                string yonetmen = Console.ReadLine();

                Console.Write("Film süresi: ");
                int sure = int.Parse(Console.ReadLine());

                db.FilmEkle(ad, yonetmen, sure);

                Console.WriteLine("Film eklendi.");
            }
            else if (secim == "2")
            {
                List<Film> liste = db.FilmleriGetir();

                foreach (var film in liste)
                {
                    Console.WriteLine($"{film.Id} - {film.Ad} - {film.Yonetmen} - {film.Sure}");
                }
                if(liste.Count == 0)
                   Console.WriteLine("Kyıt bulunamadı.");
            }
            else if(secim == "3")
            {
                Console.Write("Silinecek film Id: ");
                int id = int.Parse (Console.ReadLine());
                db.FilmSil(id);
                Console.WriteLine("Film silindi.");
            }
            else if (secim == "0")
            {
                break;
            }
        }
        
    }  
}
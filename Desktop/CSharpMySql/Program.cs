using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {Logger.LogYaz("Program başladı");

        
        Database db = new Database();

        while (true)
        {
Console.WriteLine("\n1- Öğrenci Ekle");
Console.WriteLine("2- Öğrencileri Listele");
Console.WriteLine("3- Öğrenci Sil");
Console.WriteLine("4- Öğrenci Güncelle");
Console.WriteLine("5- Öğrenci Ara");
Console.WriteLine("0- Çıkış");


            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Write("İsim gir: ");
                string isim = Console.ReadLine();
                db.OgrenciEkle(isim);
                Console.WriteLine("Eklendi.");
            }
            else if (secim == "2")
            {
                List<Ogrenci> ogrenciler = db.OgrencileriGetir();

                foreach (var ogr in ogrenciler)
                {
                    Console.WriteLine(ogr.Id + " - " + ogr.Ad);
                }
            }
            else if (secim == "3")
            {
                Console.Write("Silinecek Id: ");
                int id = int.Parse(Console.ReadLine());
                db.OgrenciSil(id);
                Console.WriteLine("Silindi.");
            }
            else if (secim == "4")
{
    Console.Write("Güncellenecek Id: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Yeni isim: ");
    string yeniIsim = Console.ReadLine();

    db.OgrenciGuncelle(id, yeniIsim);
    Console.WriteLine("Güncellendi.");
}
else if (secim == "5")
{
    Console.Write("Aranacak isim: ");
    string isim = Console.ReadLine();

    var sonuc = db.OgrenciAra(isim);

    foreach (var ogr in sonuc)
    {
        Console.WriteLine(ogr.Id + " - " + ogr.Ad);
    }

    if (sonuc.Count == 0)
        Console.WriteLine("Kayıt bulunamadı.");
}

            else if (secim == "0")
            {
                break;
            }
        }
        Logger.LogYaz("Program kapandı");

    }
}

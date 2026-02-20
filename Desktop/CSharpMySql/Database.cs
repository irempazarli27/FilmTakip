using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

class Database
{
    private string connectionString =
        "Server=localhost;Database=OkulDB;Uid=root;Pwd=;";

    public void OgrenciEkle(string isim)
    {
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "INSERT INTO Ogrenciler (Ad) VALUES (@ad)";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", isim);
                komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Öğrenci eklenirken hata oluştu!");
            Logger.LogYaz(ex.Message);
        }
    }

    public List<Ogrenci> OgrencileriGetir()
    {
        List<Ogrenci> liste = new List<Ogrenci>();

        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM Ogrenciler";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                MySqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Ogrenci
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString()
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Listeleme sırasında hata oluştu!");
            Logger.LogYaz(ex.Message);
        }

        return liste;
    }

    public void OgrenciSil(int id)
    {
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "DELETE FROM Ogrenciler WHERE Id=@id";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Silme sırasında hata oluştu!");
            Logger.LogYaz(ex.Message);
        }
    }
        public void OgrenciGuncelle(int id, string yeniIsim)
{
    try
    {
        using (MySqlConnection baglanti = new MySqlConnection(connectionString))
        {
            baglanti.Open();

            string sorgu = "UPDATE Ogrenciler SET Ad=@ad WHERE Id=@id";
            MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", yeniIsim);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Güncelleme sırasında hata oluştu!");
        Logger.LogYaz(ex.Message);
    }
}
public List<Ogrenci> OgrenciAra(string isim)
{
    List<Ogrenci> liste = new List<Ogrenci>();

    try
    {
        using (MySqlConnection baglanti = new MySqlConnection(connectionString))
        {
            baglanti.Open();

            string sorgu;

            if (string.IsNullOrWhiteSpace(isim))
            {
                // boşsa hepsini getir
                sorgu = "SELECT * FROM Ogrenciler ORDER BY Ad";
            }
            else
            {
                // isim girilmişse filtrele
                sorgu = "SELECT * FROM Ogrenciler " +
                         "WHERE LOWER(Ad) LIKE LOWER(@ad) " +
                         "ORDER BY Ad";
            }

            MySqlCommand komut = new MySqlCommand(sorgu, baglanti);

            if (!string.IsNullOrWhiteSpace(isim))
                komut.Parameters.AddWithValue("@ad", "%" + isim + "%");

            MySqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                liste.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Ad = reader["Ad"].ToString()
                });
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Arama sırasında hata oluştu!");
        Logger.LogYaz(ex.Message);
    }

    return liste;
}


}

    

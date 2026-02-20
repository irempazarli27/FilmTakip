using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class Database
{
    private string connectionString =
        "Server=localhost;Database=kitaptakipsistemi;Uid=root;Pwd=;";

    public void KitapEkle(string ad, string yazar, int sayfa)
    {
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu =
                    "INSERT INTO Kitaplar (Ad, Yazar, SayfaSayisi) VALUES (@ad, @yazar, @sayfa)";

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@yazar", yazar);
                komut.Parameters.AddWithValue("@sayfa", sayfa);

                komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata oluştu: " + ex.Message);
        }
    }

    public List<Kitap> KitaplariGetir()
    {
        List<Kitap> liste = new List<Kitap>();

        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM Kitaplar";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                MySqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    liste.Add(new Kitap
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Yazar = reader["Yazar"].ToString(),
                        SayfaSayisi = Convert.ToInt32(reader["SayfaSayisi"])
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata oluştu: " + ex.Message);
        }       
         return liste;
    }

public void KitapSil(int id)
{
    try
    {
        using (MySqlConnection baglanti = new MySqlConnection(connectionString))
        {
            baglanti.Open();

            string sorgu = "DELETE FROM Kitaplar WHERE Id=@id";
            MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", id);

            komut.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Silme sırasında hata oluştu: " + ex.Message);
    }
}


    }

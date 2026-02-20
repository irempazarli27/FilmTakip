using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using MySql.Data.MySqlClient;

public class Database
{
    
    private string connectionString =
       "Server=localhost;Database=filmtakip;Uid=root;Pwd=;";

    public void FilmEkle(string ad, string yonetmen, int sure)
    {
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = 
                  "INSERT INTO Filmler(ad, yonetmen, sure) VALUES (@ad, @yonetmen, @sure)";
            
            MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", ad);
            komut.Parameters.AddWithValue("@yonetmen", yonetmen);
            komut.Parameters.AddWithValue("@sure", sure);
            
            komut.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata oluştu: " + ex.Message);
        }
    }
    public List<Film> FilmleriGetir()
    {
        List<Film> liste = new List<Film>();
        try
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM Filmler";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                MySqlDataReader reader = komut.ExecuteReader();

                while(reader.Read())
                {
                    liste.Add(new Film
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Yonetmen = reader["Yonetmen"].ToString(),
                        Sure = Convert.ToInt32(reader["Sure"])
                    
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
    public void FilmSil(int id)
    {
        try
        {
            using(MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();

                string sorgu = "DELETE FROM Filmler WHERE Id=@id";
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
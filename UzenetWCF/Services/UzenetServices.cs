using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzenetWCF.DatabaseManager;
using UzenetWCF.Interface;
using UzenetWCF.Models;

namespace UzenetWCF.Services
{
    internal class UzenetServices : ICRUD
    {
        public List<Tablazat> Read()
        {
            List<Tablazat> tablazatok = new List<Tablazat>();
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "SELECT * FROM uzenet";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Uzenet uzenet = new Uzenet();
                        uzenet.Id = reader.GetInt32("Id");
                        uzenet.Szoveg = reader.GetString("Szoveg");
                        uzenet.KüldesiIdo = reader.GetDateTime("KüldesiIdo");
                        uzenet.UzenetTipus = reader.GetString("UzenetTipus");
                        if (!reader.IsDBNull(reader.GetOrdinal("Telefon")))
                        {
                            uzenet.Telefon = reader.GetString("Telefon");
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                        {
                            uzenet.Email = reader.GetString("Email");
                        }
                        tablazatok.Add(uzenet);
                    }
                }
                return tablazatok;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az adatok lekérdezése során: " + ex.Message);
                return tablazatok;
            }
        }

        public string Create(Tablazat tablazat)
        {
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "INSERT INTO uzenet (Szoveg, KüldesiIdo, UzenetTipus, Telefon, Email) " +
                        "VALUES (@szoveg, @kuldesiido, @uzenettipus, @telefon, @email)";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);
                    cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Uzenet).KüldesiIdo);
                    cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Uzenet).UzenetTipus);
                    cmd.Parameters.AddWithValue("@telefon", (tablazat as Uzenet).Telefon);
                    cmd.Parameters.AddWithValue("@email", (tablazat as Uzenet).Email);
                    int eredmeny = cmd.ExecuteNonQuery();

                    if (eredmeny > 0)
                    {
                        return "Sikeres beszúrás";
                    }
                    else
                    {
                        return "Sikertelen beszúrás";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok beszúrása során: " +
                    ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "DELETE FROM uzenet WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);

                    int eredmeny = cmd.ExecuteNonQuery();

                    if (eredmeny > 0)
                    {
                        return "Sikeres törlés";
                    }
                    else
                    {
                        return "Sikertelen törlés";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok törlése során: " +
                    ex.Message;
            }
        }

        public string Update(Tablazat tablazat)
        {
            try
            {
                using (MySqlConnection conn = new DBManager().OpenDB())
                {
                    string sql = "UPDATE uzenet SET Szoveg = @szoveg, KüldesiIdo = @kuldesiido, " +
                        "UzenetTipus = @uzenettipus, Telefon = @telefon, Email = @email WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);
                    cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Uzenet).KüldesiIdo);
                    cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Uzenet).UzenetTipus);
                    cmd.Parameters.AddWithValue("@telefon", (tablazat as Uzenet).Telefon);
                    cmd.Parameters.AddWithValue("@email", (tablazat as Uzenet).Email);
                    cmd.Parameters.AddWithValue("@id", (tablazat as Uzenet).Id);
                    int eredmeny = cmd.ExecuteNonQuery();

                    if (eredmeny > 0)
                    {
                        return "Sikeres módosítás";
                    }
                    else
                    {
                        return "Sikertelen módosítás";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok módosítása során: " +
                    ex.Message;
            }
        }
    }
}

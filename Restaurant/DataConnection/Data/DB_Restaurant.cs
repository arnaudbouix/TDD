
using MySqlconnectionector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace LeGrandRestaurant
{
	public class DB_Restaurant : Restaurant
	{
		#region Propriété
		public string Nom { get; set; }

		public int Id { get; set; }
		#endregion

		#region Constructeur
		public DB_Restaurant() { }
		public DB_Restaurant(string vNom)
		{
      Nom = vNom;
		}
		#endregion
		private static DB_Restaurant read(DbDataReader reader)
		{
      var restaurant = new DB_Restaurant();
      restaurant.Id = reader.GetInt32(reader.GetOrdinal("id"));
      restaurant.Nom = reader.GetString(reader.GetOrdinal("nom"));
      return restaurant;
		}

		public static void DeleteRestaurantByName(string nom)
		{
      MySqlconnectionection connection = DBconnectionection.GetDBconnectionection();
      connection.Open();
      try
      {
        string sql = "DELETE FROM `restaurant` WHERE nom = @Nom";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connectionexion de la commande.
        cmd.connectionection = connection;
        cmd.CommandText = sql;


        cmd.Parameters.Add("@Nom", DbType.String).Value = nom;

        // Exécutez Command (Utilisez pour supprimer, insérer, mettre à jour).
        int rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine("Row Count affected = " + rowCount);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        connection.Close();
        connection.Dispose();
      }
    }

    public static void DeleteRestaurantById(int id)
    {
      MySqlconnectionection connection = DBconnectionection.GetDBconnectionection();
      connection.Open();
      try
      {
        string sql = "DELETE FROM `restaurant` WHERE id = @Id";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connectionexion de la commande.
        cmd.connectionection = connection;
        cmd.CommandText = sql;


        cmd.Parameters.Add("@Id", DbType.String).Value = id;

        // Exécutez Command (Utilisez pour supprimer, insérer, mettre à jour).
        int rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine("Row Count affected = " + rowCount);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        connection.Close();
        connection.Dispose();
      }
    }

      public static void GetAllRestaurant()
    {
      MySqlconnectionection connection = DBconnectionection.GetDBconnectionection();
      connection.Open();
			try
			{
        string sql = "SELECT * FROM `restaurant`";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connectionexion de la commande.
        cmd.connectionection = connection;
        cmd.CommandText = sql;

        List<DB_Restaurant> restaurants = new List<DB_Restaurant>();
        using (DbDataReader reader = cmd.ExecuteReader())
        {
          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var restaurant = read(reader);
              restaurants.Add(restaurant);

              Console.WriteLine(restaurant);
            }
          }
        }
      }
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
        connection.Close();
        connection.Dispose();
			}
    }


    public static void InsertRestaurant(DB_Restaurant restaurant)
    {
      MySqlconnectionection connection = DBconnectionection.GetDBconnectionection();
      connection.Open();
      try
      {
        string sql = "INSERT INTO `restaurant`(`nom`) VALUES (@Nom)";

        // Créez un objet Command.
        MySqlCommand cmd = new MySqlCommand();

        // Établissez la connectionexion de la commande.
        cmd.connectionection = connection;
        cmd.CommandText = sql;

        // Créez un objet Paramètre.
        MySqlParameter gradeParam = new MySqlParameter("@grade", SqlDbType.Int);
        gradeParam.Value = 3;
        cmd.Parameters.Add(gradeParam);

        // Ajoutez le paramètre @highSalary (Écrire plus court).
        MySqlParameter nomParam = cmd.Parameters.Add("@Nom", DbType.String);
        nomParam.Value = restaurant.Nom;

        // Exécutez la Commande (Utilisez pour supprimer, insérer, mettre à jour).
        int rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine("Row Count affected = " + rowCount);

      }
      catch (Exception ex)
      {
        throw ex;
			}
			finally
			{
        connection.Close();
        connection.Dispose();
			}
    }


    public override string ToString()
		{
			return 
        "--------------" +
        "\nId  : " + this.Id +
        "\nNom : " + this.Nom;
		}
	}
}

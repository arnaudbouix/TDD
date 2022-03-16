using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace LeGrandRestaurant
{
	public class DB_Serveur 
	{
		#region Propriété
		private string prenom;

		public string Prenom
		{
			get { return prenom; }
			set { prenom = value; }
		}

		private string nom;

		public string Nom
		{
			get { return nom; }
			set { nom = value; }
		}

		private int id;

		public int Id
		{
			get { return id; }
			private set { id = value; }
		}

		public IList<Commande> Commandes { get; set; }
		#endregion

		#region Constructeur
		public DB_Serveur()
		{
		}

		public DB_Serveur(string vprenom, string vnom)
		{
			this.prenom = vprenom;
			this.nom = vnom;
		}
		#endregion

		#region Private Method
		private static DB_Serveur read(DbDataReader reader)
		{
			var serveur = new DB_Serveur();
			serveur.Id = reader.GetInt32(reader.GetOrdinal("id"));
			serveur.Prenom = reader.GetString(reader.GetOrdinal("prenom"));
			serveur.Nom = reader.GetString(reader.GetOrdinal("nom"));
			return serveur;
		}
		#endregion

		#region Interface
		public double getChiffreAffaire()
		{
			double? montant = 0;
			MySqlConnection conn = DBConnection.GetDBConnection();
			conn.Open();
			try
			{
				string sql = "SELECT SUM(montant) as allMontant FROM `commande` WHERE idServeur = @IdServeur";

				// Créez un objet Command.
				MySqlCommand cmd = new MySqlCommand();

				// Établissez la connexion de la commande.
				cmd.Connection = conn;
				cmd.CommandText = sql;

				// Ajoutez le paramètre @highSalary (Écrire plus court).
				MySqlParameter prenomParam = cmd.Parameters.Add("@IdServeur", DbType.Int32);
				prenomParam.Value = Id;

				// Exécutez la Commande (Utilisez pour supprimer, insérer, mettre à jour).
				int rowCount = cmd.ExecuteNonQuery();

				using (DbDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();
						if(!reader.IsDBNull(reader.GetOrdinal("allMontant")))
							montant = reader.GetDouble(reader.GetOrdinal("allMontant"));
						Console.WriteLine(montant);
					} else
					{
						throw new Exception("Aucune ligne lu.");
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}


			return montant.Value;


		}



		public void PrendCommande(DB_Commande commande)
		{
			commande.IdServeur = this.Id; // On ajoute l'id du serveur qui prend la commande.
			DB_Commande.InsertCommande(commande);
		}

		public IList<Commande> GetCommandes()
		{
			throw new NotImplementedException();
		}
		#endregion


		#region CRUD

		public static void DeleteServeurByName(string nom)
		{
			MySqlConnection conn = DBConnection.GetDBConnection();
			conn.Open();
			try
			{
				string sql = "DELETE FROM `serveur` WHERE nom = @Nom";

				// Créez un objet Command.
				MySqlCommand cmd = new MySqlCommand();

				// Établissez la connexion de la commande.
				cmd.Connection = conn;
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
				conn.Close();
				conn.Dispose();
			}
		}

		public static void DeleteServeurById(int id)
		{
			MySqlConnection conn = DBConnection.GetDBConnection();
			conn.Open();
			try
			{
				string sql = "DELETE FROM `serveur` WHERE id = @id";

				// Créez un objet Command.
				MySqlCommand cmd = new MySqlCommand();

				// Établissez la connexion de la commande.
				cmd.Connection = conn;
				cmd.CommandText = sql;


				cmd.Parameters.Add("@id", DbType.Int32).Value = id;

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
				conn.Close();
				conn.Dispose();
			}
		}

		public static void GetAllServeur()
		{
			MySqlConnection conn = DBConnection.GetDBConnection();
			conn.Open();
			try
			{
				string sql = "SELECT * FROM `serveur`";

				// Créez un objet Command.
				MySqlCommand cmd = new MySqlCommand();

				// Établissez la connexion de la commande.
				cmd.Connection = conn;
				cmd.CommandText = sql;

				List<DB_Serveur> serveurs = new List<DB_Serveur>();
				using (DbDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							var serveur = read(reader);
							serveurs.Add(serveur);

							Console.WriteLine(serveur);
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
				conn.Close();
				conn.Dispose();
			}
		}


		public static DB_Serveur InsertServeur(DB_Serveur serveur)
		{
			MySqlConnection conn = DBConnection.GetDBConnection();
			conn.Open();
			try
			{
				string sql = "INSERT INTO `serveur`(`nom`,`prenom`) VALUES (@Nom, @prenom)";

				// Créez un objet Command.
				MySqlCommand cmd = new MySqlCommand();

				// Établissez la connexion de la commande.
				cmd.Connection = conn;
				cmd.CommandText = sql;

				// Ajoutez le paramètre @highSalary (Écrire plus court).
				MySqlParameter prenomParam = cmd.Parameters.Add("@Prenom", DbType.String);
				prenomParam.Value = serveur.Prenom;

				// Ajoutez le paramètre @highSalary (Écrire plus court).
				MySqlParameter nomParam = cmd.Parameters.Add("@Nom", DbType.String);
				nomParam.Value = serveur.Nom;

				// Exécutez la Commande (Utilisez pour supprimer, insérer, mettre à jour).
				int rowCount = cmd.ExecuteNonQuery();
				serveur.Id = (int)cmd.LastInsertedId;

				Console.WriteLine("Row Count affected = " + rowCount);

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
			if (serveur.Id != null)
				return serveur;
			else
				return serveur;

		}

		public override string ToString()
		{
			return
				"--------------" +
				"\nId  : " + this.Id +
				"\nNom : " + this.Prenom;
		}

		#endregion

	}
}


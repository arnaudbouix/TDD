using System.Collections.Generic;

namespace LeGrandRestaurant
{
	public class Serveur : IServeur
	{
		public IList<Commande> Commandes { get; set; }

		public Serveur()
		{
			this.Commandes = new List<Commande>();
		}

		public Serveur(IList<Commande> commandes)
		{
			this.Commandes = commandes;
		}

		public double getChiffreAffaire()
		{
			double chiffreDaffaire = 0;
			foreach (var commande in Commandes)
			{
				chiffreDaffaire = chiffreDaffaire + commande.getMontant();
			}
			return chiffreDaffaire;
		}

		public void PrendCommande(Commande commande)
		{
			this.Commandes.Add(commande);
		}

		public IList<Commande> GetCommandes()
		{
			return Commandes;
		}
	}
}

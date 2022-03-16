using System.Collections.Generic;

namespace LeGrandRestaurant
{
	public class Commande : ICommande
	{
		public double Montant { get; set; }
		public IList<Plat> ListePlat { get; set; }

		public Commande(double montant)
		{
			this.Montant = montant;
		}

		public double getMontant()
		{
			return this.Montant;
		}
		public void setListPLat(IList<Plat> plats)
		{
			this.ListePlat = plats;
		}
		public IList<Plat> getListePlats()
		{
			return this.ListePlat;
		}
	}
}

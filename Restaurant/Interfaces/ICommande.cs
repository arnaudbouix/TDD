using System.Collections.Generic;

namespace LeGrandRestaurant
{
	public interface ICommande
	{
		public double Montant { get; set; }
		public IList<Plat> ListePlat { get; set; }

		public double getMontant();
		public void setListPLat(IList<Plat> plats);
		public IList<Plat> getListePlats();

	}
}
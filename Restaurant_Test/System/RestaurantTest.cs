using NUnit.Framework;
using LeGrandRestaurant;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
	[TestFixture]
    class RestaurantTest
    {
		[TestCase(0, 0)]
		[TestCase(1, 0)]
		[TestCase(2, 0)]
		[TestCase(100, 0)]
		[TestCase(0, 1.0)]
		public void CheckChiffreAffaire_IsEqualToMontantTimesServeurs(int nombreSeveurs, double montant){
			// ÉTANT DONNÉ un restaurant ayant X serveurs
			var restaurant = new Restaurant();
			for(int i = 0; i < nombreSeveurs; i++)
            {
				var serveur = new ServeurBuilder().Build();
				restaurant.addServeur(serveur);
            }
			var franchise = new Franchise(new List<Restaurant>() { restaurant });

			// QUAND tous les serveurs prennent une commande d'un montant Y
			foreach(var serveur in restaurant.getServeurs())
            {
				serveur.PrendCommande(new Commande(montant));
            }

			// ALORS le chiffre d'affaires de la franchise est X * Y
			Assert.That(franchise.getChiffreAffaire(), Is.EqualTo(nombreSeveurs * montant));
		}
    }
}

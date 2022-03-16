using NUnit.Framework;
using LeGrandRestaurant;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    class FranchiseTest
    {
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0)]
        public void CheckChiffreDAffaireFranchise(int nbRestaurants, int nbServeurs, int montant)
        {
            // ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacun
            var restaurants = new List<Restaurant>();
            for(int i = 0; i < nbRestaurants; i++)
            {
                var restaurant = new Restaurant();
                for (int j = 0; j < nbServeurs; j++)
                {
                    var s = new ServeurBuilder().Build();
                    restaurant.addServeur(s);
                }
                restaurants.Add(restaurant);
            }
            var franchise = new Franchise(restaurants);

            // QUAND tous les serveurs prennent une commande d'un montant Z
            foreach (Restaurant restaurant in franchise.getRestaurants())
            {
                foreach (Serveur serveur in restaurant.getServeurs())
                {
                    serveur.PrendCommande(new Commande(montant));
                }
            }

            // ALORS le chiffre d'affaires de la franchise est X * Y * Z
            Assert.That(franchise.getChiffreAffaire(), Is.EqualTo(nbRestaurants * nbServeurs * montant));
        }
    }
}

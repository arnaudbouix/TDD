using System.Collections.Generic;
using LeGrandRestaurant;
using Xunit;
using FluentAssertions;

namespace LeGrandRestaurantTest
{
    public class RestaurantTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1.0)]
        [InlineData(1, 0)]
        [InlineData(100, 0)]
        [InlineData(2, 0)]
        
        

        public void CheckChiffreAffaire_IsEqualToMontantTimesServeurs(int nombreServeur, int price)
        {
            // ÉTANT DONNÉ un restaurant ayant X serveurs
            var restaurant = new Restaurant();
            for (int i = 0; i < nombreServeur; i++)
            {
                var serveur = new Serveur();
                restaurant.addServeur(serveur);
            }
            var franchise = new Franchise(new List<Restaurant>() { restaurant });

            // QUAND tous les serveurs prennent une commande d'un montant Y
            foreach (var serveur in restaurant.getServeurs())
            {
                serveur.prendCommande(new Commande(price));
            }

            // ALORS le chiffre d'affaires de la franchise est X * Y
            franchise.getChiffreAffaire().Should().Be( * price);
        }
    }
}

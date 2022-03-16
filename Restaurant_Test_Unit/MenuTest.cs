using LeGrandRestaurant;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace LeGrandRestaurantTest
{
    public class MenuTest
    {
        [Fact]
        public void CarteFranchise()
        {
            // ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise
            var restaurant = new Restaurant();
            var franchise = new Franchise(new List<Restaurant> { restaurant });

            // QUAND la franchise modifie le prix du plat
            var plat = new Plat();
            var prix = new decimal(9.99);
            franchise.fixerPrix(plat, prix);

            // ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            var nouveauPrix = restaurant.getPrix(plat);
            nouveauPrix.Should().Be(prix);
        }

        [Fact]
        public void ConflitRestaurantFranchise()
        {
            //ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var restaurant = new Restaurant();
            var franchise = new Franchise(new List<Restaurant>() { restaurant });
            var plat = new Plat();
            var prixPlat = new decimal(14.18);
            restaurant.fixerPrix(plat, prixPlat);

            //QUAND la franchise modifie le prix du plat
            var nouveauPrixPlat = new decimal(14.18);
            franchise.fixerPrix(plat, nouveauPrixPlat);

            //ALORS le prix du plat dans le menu du restaurant reste inchangé
            var prixPlatActuel = restaurant.getPrix(plat);
            prixPlatActuel.Should().Be(prixPlat);
        }

        public void PlatsIdentiquesFranchiseRestaurant()
        {
            // ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var restaurant = new Restaurant();
            var franchise = new Franchise(new List<Restaurant>() { restaurant });
            var platRestaurant = new Plat();
            var prixPlatRestaurant = new decimal(14.18);
            restaurant.fixerPrix(platRestaurant, prixPlatRestaurant);

            // QUAND la franchise ajoute un nouveau plat
            var platFranchise = new Plat();
            var prixPlatFranchise = new decimal(22.21);
            franchise.fixerPrix(platFranchise, prixPlatFranchise);

            //ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise
            var prixRestaurantFinal = restaurant.getPrix(platRestaurant);
            var prixFranchiseFinal = restaurant.getPrix(platFranchise);
            
            prixPlatRestaurant.Should().Be(prixRestaurantFinal);
            prixPlatFranchise.Should().Be(prixFranchiseFinal);
            prixRestaurantFinal.Should().Be(prixFranchiseFinal);
        }
    }
}

using LeGrandRestaurant;
using NUnit.Framework;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    public partial class ServeurTest
    {
        [Test]
        public void PrendCommandeAjouteCommandeAServeur()
        {
            var serveur = new ServeurBuilder().Build();
            var commande = new Commande(12.0);
            serveur.PrendCommande(commande);

            ICollection<Commande> commandesPrises = serveur.GetCommandes();
            Assert.Contains(commande, (System.Collections.ICollection)commandesPrises);
        }

        [Test]
        public void getChiffreAffaireReturnsCorrectAmount()
        {
            var serveur = new ServeurBuilder().Build();
            var commande1 = new Commande(10);
            serveur.PrendCommande(commande1);

            var commande2 = new Commande(20);
            serveur.PrendCommande(commande2);

            var sommeCommandes = commande1.getMontant() + commande2.getMontant();
            Assert.That(serveur.getChiffreAffaire(), Is.EqualTo(sommeCommandes));
        }
    }
}

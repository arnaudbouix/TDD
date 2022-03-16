using LeGrandRestaurant;
using NUnit.Framework;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    public partial class ServeurTest
    {

        [Test]
        public void GetServeurChiffreDAffaire_ReturnsZero()
        {
            // etant donné un nouveau serveur
            var serveur = new ServeurBuilder().Build();

            // quand on récupère son chiffre d'affaire
            var chiffreAffaire = serveur.getChiffreAffaire();

            // alors celui ci est a 0
            Assert.That(chiffreAffaire, Is.EqualTo(0));
        }

        [Test]
        public void ServeurGetCommande_getChiffreAffaireReturnsCommande()
        {
            // etant donné un nouveau serveur
            var serveur = new ServeurBuilder().Build();

            // quand il prend une commande 
            var commande = new Commande(20);
            serveur.PrendCommande(commande);

            // alors son chiffre d'affaire est le montant de celle-ci
            Assert.That(serveur.getChiffreAffaire(), Is.EqualTo(commande.getMontant()));
        }
    }
}

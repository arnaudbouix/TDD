using LeGrandRestaurant;
using NUnit.Framework;
using System.Linq;

namespace LeGrandRestaurantTest
{
    [TestFixture]
    public partial class ServeurTest
    {
        /*
            On a 3 serveur dans un restaurant avec 3 tables
            Le service commence
            Un client arrive dans le restaurant, il va sur la table 1
            Le serveur 1 prend la commande de la table 1
            La table 2 se rempli
            Le serveur 2 prend la commande de la deuxième table
            La table 1 se libère, puis se re remplie
            Le serveur 2 prend la commande de la table 1
            La table 3 se remplie 
            Le serveur 3 prend la commande de la table 3
            Le chiffre d’affaires du serveur 1 est égal à l’addition des montants des commandes de la table 1 et 3 (commande 1 et 4)
        */
        [Test]
        public void SimulationService()
        {
            var serveur1 = new ServeurBuilder().Build();
            var serveur2 = new ServeurBuilder().Build();
            var serveur3 = new ServeurBuilder().Build();
            var tables = new TableGenerator().Generate(3).ToArray();
            var restaurant = new Restaurant(tables);

            // commande 1
            restaurant.debuterService();
            tables[0].installerClient();
            var commande1 = new Commande(12);
            serveur1.PrendCommande(commande1);

            // commande 2
            tables[1].installerClient();
            var commande2 = new Commande(25);
            serveur2.PrendCommande(commande2);

            // la table 1 se libère, et de nouveaux clients arrivent
            tables[0].liberer();
            tables[0].installerClient();
            var commande3 = new Commande(8.5);
            serveur2.PrendCommande(commande3);

            // commande 4
            tables[2].installerClient();
            var commande4 = new Commande(25);
            serveur3.PrendCommande(commande4);

            var montantTotal = commande1.getMontant() + commande4.getMontant();
            Assert.AreEqual(serveur1.getChiffreAffaire(), montantTotal);
        }

    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTest.Unit
{
	using global::LeGrandRestaurantTest;
	using LeGrandRestaurant;
  using NUnit.Framework;
  using System.Linq;

  namespace LeGrandRestaurantTest
  {
    [TestFixture]
    public partial class ServeurTest
    {

      [Test]
      public void GetServeurChiffreDAffaire_ReturnsZero()
      {
        // etant donné un nouveau serveur
        var serveur = new DB_Serveur("tprenom","tnom");
        var serveurInserted = DB_Serveur.InsertServeur(serveur);


        // quand on récupère son chiffre d'affaire
        var chiffreAffaire = serveur.getChiffreAffaire();

        // alors celui ci est a 0
        Assert.That(chiffreAffaire, Is.EqualTo(0));

        // Fin du programme
        DB_Serveur.DeleteServeurById(serveur.Id);
      }

      [Test]
      public void ServeurGetCommande_getChiffreAffaireReturnsCommande()
      {
        // etant donné un nouveau serveur et une commande
        var serveur = new DB_Serveur("tprenom", "tnom");
        var serveurInserted = DB_Serveur.InsertServeur(serveur);



        // quand il prend une commande 
        DB_Commande commande = new DB_Commande() { Montant = 30, IdTable = 0 };
        serveur.PrendCommande(commande);
        

        // alors son chiffre d'affaire est le montant de celle-ci
        Assert.That(serveur.getChiffreAffaire(), Is.EqualTo(commande.getMontant()));

        // Fin du programme
        DB_Serveur.DeleteServeurById(serveur.Id);
        DB_Commande.DeleteAllCommandeByIdServeur(serveur.Id);
      }

    }
  }

}

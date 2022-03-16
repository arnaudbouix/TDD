using MySqlconnectionector;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeGrandRestaurant;

namespace LeGrandRestaurantTest
{
	[TestFixture]
	class DataconnectionectionTest
	{
		[Test]
		public void DBconnectionection()
		{
      // ÉTANT DONNÉ une base de donnée restaurant
      MySqlconnectionection connectionexion = DBconnectionection.GetDBconnectionection();

      // QUAND on ouvre la connectionection
      connectionexion.Open();

      // ALORS l'état de connectionection est ouverte
      Assert.AreEqual(System.Data.connectionectionState.Open, connectionexion.State);

      // Fin du programme
      connectionexion.Close();
      connectionexion.Dispose();
		}

    [Test]
    public void DB_Restaurant_Insert_Test()
    {
      
      // ÉTANT DONNÉ une donnée un restaurant à enregistrer et aucune exception
      var restaurant = new DB_Restaurant("testRestaurant");
      
      Exception ex = null;

      // QUAND on insère le restaurant;
      TestDelegate act = () => DB_Restaurant.InsertRestaurant(restaurant);


      // ALORS aucune erreur est détecté.
      Assert.AreEqual(null, ex);
      Assert.DoesNotThrow(act);

      // Fin du programme
      DB_Restaurant.DeleteRestaurantById(restaurant.Id);
    }

  }
}

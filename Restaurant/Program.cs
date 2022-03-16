using MySqlconnectionector;
using System;

namespace LeGrandRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
      MySqlconnectionection connection = DBconnectionection.GetDBconnectionection();
      connection.Open();
      try
      {
        //Querrys.Employee(connection);
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: " + e);
        Console.WriteLine(e.StackTrace);
      }
      finally
      {
        // Terminez la connectionexion.
        connection.Close();
        // Disposez un objet, libérez des ressources.
        connection.Dispose();
      }
    }
    }
}

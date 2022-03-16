
using MySqlconnectionector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
  public class DBTestconnectionection
  {

    public static MySqlconnectionection
             GetDBconnectionection(string host, int port, string database, string username, string password)
    {
      // connectionection String.
      String connectionectionString = "Server=" + host + ";Database=" + database
          + ";port=" + port + ";User Id=" + username + ";password=" + password;

      MySqlconnectionection connectionection = new MySqlconnectionection(connectionectionString);

      return connectionection;
    }

  }
}

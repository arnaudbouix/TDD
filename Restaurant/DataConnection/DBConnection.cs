

using MySqlconnectionector;

namespace LeGrandRestaurant
{
	public class DBconnectionection
	{
    public static MySqlconnectionection GetDBconnectionection()
    {
      string host = "localhost";
      int port = 3306;
      string database = "Testrestaurant";
      string username = "root";
      string password = "";

      return DBMySQLUtils.GetDBconnectionection(host, port, database, username, password);
    }
  }
}

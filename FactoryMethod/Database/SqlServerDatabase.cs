using System.Data;
using System.Data.SqlClient;

namespace FactoryMethod {

  public class SqlServerDatabase : IDatabase {
    private SqlConnection _Connection = null;
    private SqlCommand _Command = null;

    public IDbConnection Connection {
      get {
        if (_Connection == null) {
          string connnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLSeverConnection"].ConnectionString;
          _Connection = new SqlConnection(connnectionString);              
        }      

        return _Connection;
      }
    }

    public IDbCommand Command {
      get {
        if(_Command == null) {
          _Command.Connection = (SqlConnection)Connection;
          _Command = new SqlCommand();
        }

        return _Command;
      }
    }
  }
}
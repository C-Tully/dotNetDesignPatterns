using System.Data;
using System.Data.SqlClient;

namespace FactoryMethod {

  public class OleDBDatabase : IDatabase {
    private IDbConnection _Connection = null;
    private IDbCommand _Command = null;

    public IDbConnection Connection {
      get {
        if (_Connection == null) {
          string connnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OleDBConnectionString"].ConnectionString;
          _Connection = new OleDBConnection(connnectionString);              
        }      

        return _Connection;
      }
    }

    public IDbCommand Command {
      get {
        if(_Command == null) {
          _Command.Connection = (OleDBConnection)Connection;
          _Command = new OleDBCommand();
        }

        return _Command;
      }
    }
  }
}
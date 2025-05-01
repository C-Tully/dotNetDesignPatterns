using System;
using System.Text;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;

//Special Note: I'm working on a Mac and OLEDB is windows specific 

namespace AbstractFactory {
    public class SqlServerDatabase : Database {
      private System.Data.Common.DbConnection _Connection = null;
      private System.Data.Common.DbCommand _Command = null;

      public override System.Data.Common.DbConnection Connection {
        //Lazy loading example, we don't create the connection until we need it.
        get {
            if (_Connection == null) {
              string connectionString = ConfigurationManager.ConnectionStrings["SQLSeverConnection"].ConnectionString;

              _Connection = new SqlConnection(connnectionString);              
            }
            //The return type will be of DbConnection, since as the SQLConnection inherits this.
            return _Connection;
        }

        set {
          _Connection = value;
        }
      }

      public override System.Data.Common.DbCommand Command {

        get {
          if(_Command == null) {
            _Command = new SqlCommand();
            _Command.Connection = Connection;
          }

          return _Command;
        }

        set {

        }
      }

    }
}

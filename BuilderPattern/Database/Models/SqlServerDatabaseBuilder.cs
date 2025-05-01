using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder {
  class SqlServerDatabaseBuilder  : IDatabaseBuilder {

    private Database _Database;

    public SqlServerDatabaseBuilder() {
      _Database = new SqlServerDatabase();
    }
    public void BuildConnection() {
      //SqlServerConnectionString comes from the app.config file where you set it up.
      //System.ConfigurationManager comes from a system reference added via the dotNet terminal command "dotnet add package System.Configuration.ConfigurationManager;"
      //At which point VS code may complain.
      string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLSeverConnectionString"].ConnectionString;
      _Database.Connection = new SqlConnection(connectionString);
    }

    public void BuildCommand() {
      _Database.Command = new SqlCommand();
      _Database.Command.Connection = _Database.Connection;
    }

    public void SetSettings() {
      _Database.Command.CommandTimeout = 360;
      _Database.Command.CommandType = CommandType.Text;
    }
    public Database Database {
      get { return _Database; }
      set { _Database = value; }
    }
  }
}


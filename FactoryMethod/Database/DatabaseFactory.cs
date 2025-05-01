using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod {
  class DatabaseFactory {
    public static IDatabase CreateDatabase(DatabaseType DatabaseType) {
      //Using a builder pattern at this point could help to create more complex
      //objects / logic
    
      switch(DatabaseType) {
        case FactoryMethod.DatabaseType.OleDb:
          return new OleDbDatabase();
        case FactoryMethod.DatabaseType.sqlServer:
        default:
          return new SqlServerDatabase();
      }
    }
  }
}
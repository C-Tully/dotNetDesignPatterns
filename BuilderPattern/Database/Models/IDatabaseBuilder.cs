
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder {
  //Take note that as a interface, thereby the methods must be implemented.
  public interface IDatabaseBuilder {
    void BuildConnection();
    void BuildCommand();
    void SetSettings();   
    
    //Note this is read only, therefore only a getter.
    Database Database { get;}
  }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;

namespace Builder {
  public abstract class Database {
    public virtual DbConnection Connection {get; set;}
    public virtual DbCommand Command {get; set;}
  }

}
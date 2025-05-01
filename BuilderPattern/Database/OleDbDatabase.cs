namespace Builder {

  public class OleDbDatabase : Database { 
    private System.Data.Common.DbConnection _Connection = null;
    private System.Data.Common.DbCommand _Command = null;
    public override System.Data.Common.DbConnection Connection {
      get {
        return _Connection;
      }

      set {
        _Connection = value;
      }
    }
  

  public override System.Data.Common.DbCommand Command {
    get {
      return _Command;
    }

    set {
      _Command = value;
    }
  }

  }
}
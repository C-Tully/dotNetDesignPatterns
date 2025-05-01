using System.Data;

namespace FactoryMethod {

  public interface IDatabase {
    IDbConnection Connection { get; }
    IDbCommand Command {get; }
  }
}

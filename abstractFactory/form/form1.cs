using System.Data.Common;
//TODO:: Basic form which includes two radio buttons and a submit button to switch between database types.
namespace AbstractFactory {
  public partial class Form1 : Form {
      public Form1() {
        InitalizeComponent();
      }

    //Note the use of the abstract database that is set. This allows for the pattern to shine
      private void btnGetDataBase_Click(object sender, EventArgs e) {
        Database database;

        if(radUseSqlServer.Checked) {
          database = new SqlServerDatabase();

        } else {
          database = new OleDBDatabase();
        }

        DbCommand command = database.Command;
        //With the abstract DB here, we can now add in data requests
        //command.CommandType = CommandType.Text;
        //command.CommantText = "Select * from Customers"; No best practices on this FYI.
        //command.Connection.Open();
        //DbDataReader reader = command.ExecuteReader();

        //Do data work here.


        //cleanup
        //reader.Close()
        //reader.Connection.close();
      }
  }
}


//To summarize what's going on here. Using the AbstractFactory pattern we are able to minimize the additional work needed
// if we wanted to add a new dataSource (E.G Sql -> Oracle) into the mix. This helps us to reduce rework for other
// existing data types, or even chain onto them. This factory method helps us reduce some rework and keeps the setup
// in a flexible state
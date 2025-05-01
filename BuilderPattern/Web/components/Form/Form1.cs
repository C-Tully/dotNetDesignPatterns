using System.Data.Common;
//TODO:: Basic form which includes two Radio buttons and a submit button to switch between database types.
namespace Builder {
  public partial class Form1 : Form {
      public Form1() {
        InitializeComponent();
      }

    //Note the use of the abstract database that is set. This allows for the pattern to shine
      private void btnGetDataBase_Click(object sender, EventArgs e) {
        Director director = new Director();
        IDatabaseBuilder builder;
        //What radio button was checked here..
        if(radUseSqlServer.Cheked) {
          builder = new SqlServerDatabaseBuilder();
        } else {
          builder = new OleDbDataBaseBuilder();
        }

        director.Build(builder);
        Database database = builder.Database;


        //Note the code belowe doesn't know anything regarding 
        //Databases etc. This has cleaned up the application code 
        //and kept more complicated construction away from the applicaiton code.
        
        DbCommand command = database.Command;        
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
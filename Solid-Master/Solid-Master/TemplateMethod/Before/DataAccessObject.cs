using System;
using System.Data;
using System.Data.OleDb;

namespace Solid_Master.TemplateMethod.Before
{
    class DataAccessObject
    {
        public void Process()
        {
            string connectionString = "<<Put connection string here>>";
            ProcessEmployees(connectionString);
            ProcessAccounts(connectionString);
        }

        private void ProcessEmployees(string connectionString)
        {
            //Select
            var sql = "select Name from Employee";
            var dataAdapter = new OleDbDataAdapter(
                sql, connectionString);

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Employees");

            //Process
            Console.WriteLine("Employees ---- ");

            DataTable dataTable = dataSet.Tables["Employee"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            Console.WriteLine();

            //Close
            dataSet.Clear();
        }

        private void ProcessAccounts(string connectionString)
        {
            //Select
            string sql = "select Name from Account";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
                sql, connectionString);

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "AccountDataAccessObject");

            //Process
            Console.WriteLine("AccountDataAccessObject ---- ");

            DataTable dataTable = dataSet.Tables["Account"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            Console.WriteLine();

            //Close
            dataSet.Clear();
        }

   }

    public static class TemplateMethodMain
    {
        public static void Main()
        {
            DataAccessObject dataAccess = new DataAccessObject();
            dataAccess.Process();
            Console.ReadLine();
        }
    }
}

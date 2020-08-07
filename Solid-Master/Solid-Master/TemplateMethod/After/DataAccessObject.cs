using System;
using System.Data;
using System.Data.OleDb;

namespace Solid_Master.TemplateMethod.After
{
    abstract class DataAccessObject
    {
        protected string _connectionString;
        protected DataSet _dataSet;

        protected DataAccessObject(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected abstract void Connect();
        protected abstract void Select();
        protected abstract void Process();
        protected virtual void Disconnect()
        {
            _connectionString = string.Empty;
            _dataSet.Clear();
        }

        // The 'Template Method' 
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }

    class EmployeeDataAccessObject : DataAccessObject
    {
        protected override void Connect()
        {}

        protected override void Select()
        {
            string sql = "select Name from Employee";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
                sql, _connectionString);

            _dataSet = new DataSet();
            dataAdapter.Fill(_dataSet, "Employees");
        }

        protected override void Process()
        {
            Console.WriteLine("Employees ---- ");

            DataTable dataTable = _dataSet.Tables["Employee"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            Console.WriteLine();
        }

        public EmployeeDataAccessObject(string connectionString) : base(connectionString)
        {
        }
    }

    class AccountDataAccessObject : DataAccessObject
    {
        protected override void Connect()
        {
        }

        protected override void Select()
        {
            string sql = "select Name from AccountDataAccessObject";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
                sql, _connectionString);

            _dataSet = new DataSet();
            dataAdapter.Fill(_dataSet, "AccountDataAccessObject");
        }

        protected override void Process()
        {
            Console.WriteLine("AccountDataAccessObject ---- ");
            DataTable dataTable = _dataSet.Tables["AccountDataAccessObject"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            Console.WriteLine();
        }

        public AccountDataAccessObject(string connectionString) : base(connectionString)
        {
        }

    }

    public static class TemplateMethodMain
    {
        public static void Main()
        {
            DataAccessObject accountDataAccessObject = new AccountDataAccessObject("<<Insert Connection string >>");
            accountDataAccessObject.Run();
            
            DataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject("<<Insert Connection string >>");
            employeeDataAccessObject.Run();

            Console.ReadLine();
        }
    }
}
 


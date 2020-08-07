namespace Solid_Master.AbstractFactory.After
{
    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(string firstName, string lastName);
        IEmployeeIdentity CreateIdentity();
    }

    public interface IEmployee
    {
        void SetIdentity(IEmployeeIdentity identity);
    }

    public interface IEmployeeIdentity
    {
        string Id { get; set; }
    }

    class ParentCompanyEmployeeFactory : IEmployeeFactory
    {
        public IEmployee CreateEmployee(string firstName, string lastName)
        {
            var employee = new ParentCompanyEmployee();
            employee.SetIdentity(CreateIdentity());
            return employee;
        }

        public IEmployeeIdentity CreateIdentity()
        {
            return new ParentCompanyIdentity();
        }
    }

    public class ParentCompanyEmployee: IEmployee
    {
        private IEmployeeIdentity _identity;

        public void SetIdentity(IEmployeeIdentity identity)
        {
            _identity = identity;
        }
    }

    class ParentCompanyIdentity : IEmployeeIdentity
    {
        /// <summary>
        /// Store SSN
        /// </summary>
        public string Id { get; set; }
    }


    class ChildCompanyEmployeeFactory : IEmployeeFactory
    {
        public IEmployee CreateEmployee(string firstName, string lastName)
        {
            var employee = new ChildCompanyEmployee();
            employee.SetIdentity(CreateIdentity());
            return employee;
        }

        public IEmployeeIdentity CreateIdentity()
        {
            return new ChildCompanyIdentity() ;
        }
    }

    public class ChildCompanyEmployee : IEmployee
    {
        private IEmployeeIdentity _identity;

        public void SetIdentity(IEmployeeIdentity identity)
        {
            _identity = identity;
        }
    }

    class ChildCompanyIdentity : IEmployeeIdentity
    {
        /// <summary>
        ///  This represents passport number;
        /// </summary>
        public string Id { get; set; }
    }

}

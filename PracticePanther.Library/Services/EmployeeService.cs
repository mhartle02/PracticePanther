
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class EmployeeService
    {
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        private List<Employee> employees;

        private static EmployeeService? instance;

        public static EmployeeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return instance;
            }
        }
        private EmployeeService()
        {
            employees = new List<Employee>
            {


                new Employee { Id = 1, Name = "Employee 1"},
                new Employee { Id = 2, Name = "Employee 2"},
                new Employee { Id = 3, Name = "Employee 3"},
                new Employee { Id = 4, Name = "Employee 4"},
                new Employee { Id = 5, Name = "Employee 5"},
                new Employee { Id = 6, Name = "Employee 6"},
            };
        }

        public void Delete(int id)
        {
            var employeeToDelete = Employees.FirstOrDefault(c => c.Id == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
        }

        public void Add(Employee e)
        {
            if (e.Id == 0)
            {
                //add
                e.Id = LastId + 1;
            }

            Employees.Add(e);
        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.Id).Max() : 0;
            }
        }


        public List<Employee> Search(string query)
        {


            return Employees.Where(e => e.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
    }
}

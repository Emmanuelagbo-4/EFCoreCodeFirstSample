using EFCoreCodeFirstSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeManager(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public void Add(Employee entity)
        {
            _employeeContext.Employee.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _employeeContext.Employee.Remove(entity);
            _employeeContext.SaveChanges();
        }

        public Employee Get(long id)
        {
             return _employeeContext.Employee
                .FirstOrDefault(c => c.EmployeeId == id);
            
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employee.ToList();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.PhoneNumber = entity.PhoneNumber;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;

            _employeeContext.SaveChanges();
        }
    }
}

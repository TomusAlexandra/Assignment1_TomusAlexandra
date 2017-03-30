using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Furniture.DAL;
using Furniture.Models;
using System.Configuration;
using BankCredit.DAL;

namespace Furniture.BL
{
    public class UserOperations
    {
        public User Login(string userName, string password)
        {
            DataAccess dal = new DataAccess();
            User user = dal.GetUser(userName);
            if (user!=null)
            {
                Security secure = new Security();
                if(secure.VerifyHash(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            Security secure = new Security();
            user.Password = secure.HashSHA1(user.Password);

            DataAccess dal = new DataAccess();
            dal.AddUser(user);
        }

        public IList<Account> GetAccountsForUser(int userId)
        {
            DataAccess dal = new DataAccess();
            return dal.GetAccountsForUser(userId);
        }

        public void AddEmployee(Employee employee)
        {
            Security secure = new Security();
            employee.Password = secure.HashSHA1(employee.Password);

            DataAccessEmployee dal = new DataAccessEmployee();
            dal.AddEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Security secure = new Security();
            employee.Password = secure.HashSHA1(employee.Password);

            DataAccessEmployee dal = new DataAccessEmployee();
            dal.DeleteEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Security secure = new Security();
            employee.Password = secure.HashSHA1(employee.Password);

            DataAccessEmployee dal = new DataAccessEmployee();
            dal.UpdateEmployee(employee);
        }

        public IList<Employee> RetrieveEmployeeList()
        {
            DataAccessEmployee dal = new DataAccessEmployee();
            return dal.RetrieveEmployee();
        }






    }
}

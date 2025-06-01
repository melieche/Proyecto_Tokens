using Proyecto_Tokens.Models;

namespace Proyecto_Tokens.Constants
{
    public class EmployeeConstans
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel() {FistName = "Tomas", LastName = "Perez", Email = "perez@gmail.com"},
            new EmployeeModel() {FistName = "Melissa", LastName = "Echeverri", Email = "meche@gmail.com"},
        };
    }
}

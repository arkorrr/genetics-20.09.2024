public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public string CorporateEmail { get; set; }
}

public class EmployeeManager
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }
    public void RemoveEmployee(string email)
    {
        var employee = employees.FirstOrDefault(e => e.CorporateEmail == email);
        if (employee != null)
        {
            employees.Remove(employee);
        }
    }
    public void UpdateEmployee(string email, Employee updatedEmployee)
    {
        var employee = employees.First(e => e.CorporateEmail == email);
        if (employee != null)
        {
            employee.FullName = updatedEmployee.FullName;
            employee.Position = updatedEmployee.Position;
            employee.Salary = updatedEmployee.Salary;
            employee.CorporateEmail = updatedEmployee.CorporateEmail;
        }
    }
    public Employee SearchEmployee(string email)
    {
        return employees.First(e => e.CorporateEmail == email);
    }

    public List<Employee> SortEmployeesBy(Func<Employee, object> keySelector)
    {
        return employees.OrderBy(keySelector).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManager manager = new EmployeeManager();
        manager.AddEmployee(new Employee { FullName = "Богдан", Position = "Менеджер", Salary = 50000, CorporateEmail = "bogdan@example.com" });
        manager.AddEmployee(new Employee { FullName = "Богдан", Position = "Разработчик", Salary = 60000, CorporateEmail = "bogdan@example.com" });

        var employee = manager.SearchEmployee("bogdan@example.com");
        Console.WriteLine($"Найден сотрудник: {employee.FullName}, {employee.Position}");

        manager.UpdateEmployee("bogdan@example.com", new Employee { FullName = "Богдан", Position = "Старший менеджер", Salary = 70000, CorporateEmail = "bogdan@example.com" });

        var sortedEmployees = manager.SortEmployeesBy(e => e.Salary);
        foreach (var emp in sortedEmployees)
        {
            Console.WriteLine($"{emp.FullName}, {emp.Position}, {emp.Salary}");
        }
        manager.RemoveEmployee("bogdan@example.com");
    }
}
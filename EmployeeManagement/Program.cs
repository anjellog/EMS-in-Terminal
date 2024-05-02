using System;
using System.Collections.Generic;

public class Employee // Class declaration
{
    // Data storage: Properties
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }

    // Constructor
    public Employee(int employeeId, string name, string department)
    {
        EmployeeId = employeeId;
        Name = name;
        Department = department;
    }

    // Virtual method for polymorphism
    public virtual double CalculateMonthlySalary()
    {
        return 0;
    }

    // Method to generate pay stub
    public virtual void GeneratePayStub(int hoursWorked)
    {
        double salary = CalculateMonthlySalary();
        Console.WriteLine($"Pay Stub for: {Name}");
        Console.WriteLine($"Employee ID: {EmployeeId}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Hours Worked: {hoursWorked}");
        Console.WriteLine($"Monthly Salary: Php {salary:N2}");
    }
}

// Derived class for Hourly Employee
public class HourlyEmployee : Employee // Inheritance
{
    // Data storage: Property
    public double HourlyRate { get; set; }

    // Constructor
    public HourlyEmployee(int employeeId, string name, string department, double hourlyRate)
        : base(employeeId, name, department)
    {
        HourlyRate = hourlyRate;
    }

    // Override method to calculate monthly salary
    public override double CalculateMonthlySalary()
    {
        return HourlyRate * 160; // change number for number of hours worked in a month
    }
}

// Derived class for Salaried Employee
public class SalariedEmployee : Employee // Inheritance
{
    // Data storage: Property
    public double MonthlySalary { get; set; }

    // Constructor
    public SalariedEmployee(int employeeId, string name, string department, double monthlySalary)
        : base(employeeId, name, department)
    {
        MonthlySalary = monthlySalary;
    }

    // Override method to calculate monthly salary
    public override double CalculateMonthlySalary()
    {
        return MonthlySalary;
    }
}

class Program // Class declaration
{
    // Data storage: List
    static List<Employee> employees = new List<Employee>();

    // Main method
    static void Main(string[] args)
    {
        // Menu-driven interface for the user
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("1. Add Hourly Employee");
            Console.WriteLine("2. Add Salaried Employee");
            Console.WriteLine("3. Generate Pay Stubs");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice)
            {
                case "1":
                    AddHourlyEmployee();
                    break;
                case "2":
                    AddSalariedEmployee();
                    break;
                case "3":
                    GeneratePayStubs();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("");
                    break;
            }
        }
    }

    // Method to add hourly employee
    static void AddHourlyEmployee()
    {
        Console.WriteLine("Adding Hourly Employee");
        Console.Write("Enter Employee ID: ");
        int employeeId = int.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Department: ");
        string department = Console.ReadLine();
        Console.Write("Enter Hourly Rate: ");
        double hourlyRate = double.Parse(Console.ReadLine());

        employees.Add(new HourlyEmployee(employeeId, name, department, hourlyRate));
        Console.WriteLine("");
        Console.WriteLine("Hourly Employee added successfully!");
        Console.WriteLine("");
    }

    // Method to add salaried employee
    static void AddSalariedEmployee()
    {
        Console.WriteLine("Adding Salaried Employee");
        Console.Write("Enter Employee ID: ");
        int employeeId = int.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Department: ");
        string department = Console.ReadLine();
        Console.Write("Enter Monthly Salary: ");
        double monthlySalary = double.Parse(Console.ReadLine());

        employees.Add(new SalariedEmployee(employeeId, name, department, monthlySalary));
        Console.WriteLine("");
        Console.WriteLine("Salaried Employee added successfully!");
        Console.WriteLine("");
    }

    // Method to generate pay stubs
    static void GeneratePayStubs()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees to generate pay stubs for.");
            Console.WriteLine("");
            return;
        }

        Console.WriteLine("Generate Pay Stub");
        Console.WriteLine("1. Generate Pay Stubs for All Employees");
        Console.WriteLine("2. Generate Pay Stub for Hourly Employee");
        Console.WriteLine("3. Generate Pay Stub for Salaried Employee");
        Console.WriteLine("4. Generate Pay Stub for Individual using Employee ID");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();
        Console.WriteLine("");

        switch (choice)
        {
            case "1":
                GeneratePayStubsForAll();
                break;
            case "2":
                GeneratePayStubsForHourly();
                break;
            case "3":
                GeneratePayStubsForSalaried();
                break;
            case "4":
                GeneratePayStubForIndividual();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("");
                break;
        }
    }

    // Method to generate pay stubs for all employees
    static void GeneratePayStubsForAll()
    {
        Console.WriteLine("Generating Pay Stubs for All Employees");
        Console.WriteLine();

        foreach (var emp in employees)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            emp.GeneratePayStub(160); // change number for number of hours worked in a month
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }
    }

    // Method to generate pay stubs for hourly employees
    static void GeneratePayStubsForHourly()
    {
        Console.WriteLine("Generating Pay Stubs for Hourly Employees");
        Console.WriteLine();

        foreach (var emp in employees)
        {
            if (emp is HourlyEmployee)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                emp.GeneratePayStub(160); // change number for number of hours worked in a month
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }

    // Method to generate pay stubs for salaried employees
    static void GeneratePayStubsForSalaried()
    {
        Console.WriteLine("Generating Pay Stubs for Salaried Employees");
        Console.WriteLine();

        foreach (var emp in employees)
        {
            if (emp is SalariedEmployee)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                emp.GeneratePayStub(160); // change number for number of hours worked in a month
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }

    // Method to generate pay stub for an individual employee
    static void GeneratePayStubForIndividual()
    {
        Console.Write("Enter Employee ID: ");
        int employeeId = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Employee emp = employees.Find(e => e.EmployeeId == employeeId);
        if (emp != null)
        {
            Console.WriteLine("Generating Pay Stub for Individual");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            emp.GeneratePayStub(160); // change number for number of hours worked in a month
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Employee not found.");
            Console.WriteLine();
        }
    }
}

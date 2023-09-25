using System;

public class Person
{
    public enum PersonType
    {
        Person,
        Employee,
        Administrator
    }

    public PersonType Type { get; set; }
    public string sName { get; set; }
    public string LastName { get; set; }

    public Person() { }

    public Person(PersonType type, string firstName, string lastName)
    {
        Type = type;
        sName = firstName;
        LastName = lastName;
    }

    public class Employee
    {
        public string ContractNumber { get; set; }
        public Person Person { get; set; }

        public Employee() { }

        public Employee(string contractNumber, Person person)
        {
            ContractNumber = contractNumber;
            Person = person;
        }
    }

    public class Administrator
    {
        public string AuthToken { get; set; }
        public Employee Employee { get; set; }

        public Administrator() { }

        public Administrator(string authToken, Employee employee)
        {
            AuthToken = authToken;
            Employee = employee;
        }
    }
}

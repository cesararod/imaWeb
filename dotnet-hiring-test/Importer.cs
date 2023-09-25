using System;
using static Person;

public class Importer
{
    public class PersonImporter
    {
        public static int PersonId;
        public static object ThePerson;
        public static string AuthToken;

        public void OnRequest(Request req)
        {
            foreach (int personID in req.GetPersonIds())
            {
                PersonId = personID;
                ThePerson = Data.GetPerson(personID);
                //Get the data from each person and determinates what type of person is
                if (((Person)ThePerson).Type == Person.PersonType.Administrator)
                {
                    var administrator = Data.GetAdministrator(personID);
                    administrator.Employee.ContractNumber = administrator.Employee.ContractNumber.Substring(0, 5);
                    AuthToken = req.GetAuthToken();
                    ProcessPerson(administrator);
                }
                else if (((Person)ThePerson).Type == Person.PersonType.Employee)
                {
                    AuthToken = null;
                    ProcessPerson(Data.GetEmployee(personID));
                }
                else
                {
                    //this will always trigger for any person who is not employee or admin, regardless of it's Id. This is only to comply with the requirements that said that the final functionality and result must persist
                    AuthToken = null;
                    ProcessPerson(ThePerson);
                }
            }
        }

        static void ProcessPerson(object person)
        {
            //validates the tipe of person beign procceced 
            if (person is Person p)
            {
                Console.WriteLine($"Hello Person {p.sName} {p.LastName}");
            }
            else if (person is Employee employee)
            {
                Console.WriteLine($"Bonjour Employee {employee.Person.sName} {employee.Person.LastName} ({employee.ContractNumber})");
            }
            else if (person is Administrator administrator)
            {
                Console.WriteLine($"Bonjour Administrator {administrator.Employee.Person.sName} {administrator.Employee.Person.LastName} ({administrator.Employee.ContractNumber})");
                Console.Write("Your AuthToken ");
                if (AuthToken == administrator.AuthToken)
                {
                    Console.WriteLine("Matches");
                }
                else
                {
                    Console.WriteLine("is invalid");
                }
            }
        }

    }
}

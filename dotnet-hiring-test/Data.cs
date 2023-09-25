// MOCK CLASS: This file should NOT be edited.
public static class Data {
	public static Person GetPerson(int id) {
		if (id == 10500) return new Person() { sName = "Arsene", LastName = "Lupin", Type = Person.PersonType.Employee };
		if (id == 10800) return new Person() { sName = "Maurice", LastName = "LeBlanc", Type = Person.PersonType.Administrator };

		return new Person() { sName = "Marius", LastName = "Jacob", Type = Person.PersonType.Person };
	}

	public static Person.Employee GetEmployee(int id) {
		return new Person.Employee() { ContractNumber = "444-777-866", Person = new Person() { sName = "Arsene", LastName = "Lupin", Type = Person.PersonType.Employee } };
	}

	public static Person.Administrator GetAdministrator(int id) {
		return new Person.Administrator() { AuthToken = "1234ABC", Employee = new Person.Employee() { ContractNumber = "000-123-456", Person = new Person() { sName = "Maurice", LastName = "LeBlanc", Type = Person.PersonType.Administrator } } };
	}
}
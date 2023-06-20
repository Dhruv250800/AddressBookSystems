internal class AddressBook
{
    List<Contact> con = new List<Contact>();
    public void AddContact()
    {
        Contact contact = new Contact();

        Console.WriteLine("Enter FirstName : ");
        contact.Firstname = Console.ReadLine();
        Console.WriteLine("Enter LastName : ");
        contact.Lastname = Console.ReadLine();
        Console.WriteLine("Enter Address : ");
        contact.Address = Console.ReadLine();
        Console.WriteLine("Enter City : ");
        contact.City = Console.ReadLine();
        Console.WriteLine("Enter State : ");
        contact.State = Console.ReadLine();
        Console.WriteLine("Enter Zip : ");
        contact.Zip = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter PhoneNumber : ");
        contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Enter E-mail : ");
        contact.Email = Console.ReadLine();

        con.Add(contact);
    }

    public void Display()
    {
        foreach (Contact contact in con)
        {
            Console.WriteLine("FirstName - " + contact.Firstname);
            Console.WriteLine("LastName - " + contact.Lastname);
            Console.WriteLine("Address - " + contact.Address);
            Console.WriteLine("City - " + contact.City);
            Console.WriteLine("State - " + contact.State);
            Console.WriteLine("Zip - " + contact.Zip);
            Console.WriteLine("PhoneNumber - " + contact.PhoneNumber);
            Console.WriteLine("E-mail - " + contact.Email);
        }
    }
}
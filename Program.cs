﻿class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of Address Book you want : ");
        int numBook = Convert.ToInt32(Console.ReadLine());
        int numberBook = 0;
        List<string> BookNames = new List<string>();
        while (numberBook < numBook)
        {
            Console.WriteLine("Enter name of address book");
            string book = Console.ReadLine();
            BookNames.Add(book);
            AddressBook address = new AddressBook();
            while (true)
            {
                Console.WriteLine("Enter Option \n1) Add Contact \n2) Display Contact \n3) Edit Contact \n4) Delete Contact \n5) Save And Exit \n6) Save In CSV");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        address.AddContact();
                        break;
                    case 2:
                        address.Display();
                        break;
                    case 3:
                        address.EditContact();
                        break;
                    case 4:
                        address.DeleteContact();
                        break;
                    case 5:
                        SaveDataToFile(AddressBook.con, book);
                        Console.WriteLine("Data saved to file successfully.");
                        ReadDataFromFile();
                        return;
                    case 6:
                        CsvSerialise(AddressBook.con, book);
                        Console.WriteLine("Data Saved in CSV file");
                        CsvDeserialise();
                        return;
                    case 7:
                        AddressBook.SearchCity();
                        break;
                    case 8:
                        AddressBook.SearchState();
                        break;
                    case 9:
                        address.ViewByCityOrStateName();
                        break;
                    case 10:
                        address.CountByCityOrStateName();
                        break;
                    case 11:
                        address.SortByName(AddressBook.con);
                        break;
                    case 12:
                        address.SortByChoice(AddressBook.con);
                        break;
                }

            }
            AddressBook.AddTo(book);
            numberBook++;
        }
    }
    static void SaveDataToFile(List<Contact> addressBook, string bookName)
    {
        string path = @"C:\Users\HP\source\repos\AddressBookSystems\AddressBookSystem.txt";

        using (StreamWriter writer = new StreamWriter(path, true))
        {
            foreach (var contact in addressBook)
            {
                writer.WriteLine("Book Name - " + bookName);
                writer.WriteLine("FirstName - " + contact.Firstname);
                writer.WriteLine("LastName - " + contact.Lastname);
                writer.WriteLine("Address - " + contact.Address);
                writer.WriteLine("City - " + contact.City);
                writer.WriteLine("State - " + contact.State);
                writer.WriteLine("Zip - " + contact.Zip);
                writer.WriteLine("PhoneNumber - " + contact.PhoneNumber);
                writer.WriteLine("E-mail - " + contact.Email);
                writer.WriteLine();
            }
        }
    }
    static void ReadDataFromFile()
    {
        string path = @"C:\Users\HP\source\repos\AddressBookSystems\AddressBookSystem.txt";
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);

            Console.WriteLine("Data read from file:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    static void CsvSerialise(List<Contact> addressBook, string bookName)
    {
        try
        {
            string csvPath = @"C:\Users\HP\source\repos\AddressBookSystems\AddressBookSystem.txt";
            var writer = File.AppendText(csvPath);

            foreach (var contact in addressBook)
            {
                writer.WriteLine(contact.Firstname + ", " + contact.Lastname + ", " + contact.PhoneNumber + ", " + contact.Email + ", " + contact.City + ", " + contact.State + ", " + contact.Zip + ".");

            }
            writer.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    static void CsvDeserialise()
    {
        string csvPath = @"C:\Users\HP\source\repos\AddressBookSystems\AddressBookSystem.txt";
        using (var reader = new StreamReader(csvPath))

        {
            string s = " ";
            while ((s = reader.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }

        }


    }
}
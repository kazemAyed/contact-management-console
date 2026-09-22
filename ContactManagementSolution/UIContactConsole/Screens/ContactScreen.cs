using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;

namespace UIContactConsole.Screens
{
    public class ContactScreen
    {
 
        private readonly BusinessLogicLayer.Services.Contact _contactService 
            = new Contact();

        public void Show()
        {
            while (true)
            {

                string choice = ShowMenu();

                switch (choice)
                {
                    case "1":
                        ListContacts();
                        break;

                    case "2":
                        AddContact();
                        break;

                    case "3":
                        UpdateContact();
                        break;

                    case "4":
                        DeleteContact();
                        break;

                    case "5":
                        FindContactByID();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private BusinessLogicLayer.DTOs.DtoContact GetContactById(int contactId)
        {
            
            BusinessLogicLayer.DTOs.DtoContact contact = _contactService.GetById(contactId);

            if (contact == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"\n  ✗ Contact with ID {contactId} was not found.");
                Console.ResetColor();

                return null;
            }

            return contact;
        }

        private void FindContactByID()
        {
            Console.Clear();

            // Header
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║          FIND CONTACT BY ID           ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            // Read Contact ID
            int contactId = ReadInt("  ➤ Contact ID: ");

            // Find contact
            BusinessLogicLayer.DTOs.DtoContact contact = GetContactById(contactId);

            Console.WriteLine();

            if (contact == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("  ✗ Contact not found.");
                Console.WriteLine($"    No contact exists with ID {contactId}.");

                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("  Press any key to continue...");
                Console.ReadKey();

                return;
            }

            // Contact found
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ✓ Contact found!");
            Console.ResetColor();

            Console.WriteLine();

            ShowContactInfo(contact);

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowContactInfo(BusinessLogicLayer.DTOs.DtoContact contact)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║             CONTACT DETAILS             ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine($"║  ID        : {contact.ContactID,-27}║");
            Console.WriteLine($"║  FirstName : {contact.FirstName,-27}║");
            Console.WriteLine($"║  LastName  : {contact.LastName,-27}║");
            Console.WriteLine($"║  Email     : {contact.Email,-27}║");
            Console.WriteLine($"║  Phone     : {contact.Phone,-27}║");
            Console.WriteLine($"║  Address   : {contact.Address,-27}║");
            Console.WriteLine($"║  Country   : {contact.CountryID,-27}║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════════════════════════╝");

            Console.ResetColor();

        }

        private void ListContacts()
        {
            var contacts = _contactService.GetAll();

            Console.Clear();

            Console.WriteLine("CONTACTS");
            Console.WriteLine(new string('-', 100));

            Console.WriteLine(
                "ID".PadRight(8) +
                "First Name".PadRight(20) +
                "Last Name".PadRight(20) +
                "Email".PadRight(35) +
                "Phone".PadRight(20));

            Console.WriteLine(new string('-', 100));

            foreach (var contact in contacts)
            {
                Console.WriteLine(
                    contact.ContactID.ToString().PadRight(8) +
                    contact.FirstName.PadRight(20) +
                    contact.LastName.PadRight(20) +
                    contact.Email.PadRight(35) +
                    contact.Phone.PadRight(20));
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddContact()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║             ADD NEW CONTACT            ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            Console.Write("  First Name : ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("  Last Name  : ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("  Email      : ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("  Phone      : ");
            string phone = Console.ReadLine() ?? string.Empty;

            Console.Write("  Address    : ");
            string address = Console.ReadLine() ?? string.Empty;

            int countryId = ReadCountryId();

            var contact = new BusinessLogicLayer.DTOs.DtoContact 
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address,
                CountryID = countryId
            };

            int newContactId = _contactService.Add(contact);

            Console.WriteLine();

            if (newContactId > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  ✓ Contact added successfully with ID {newContactId}!");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Failed to add contact.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        private int ReadCountryId()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  Select Country:");
            Console.ResetColor();

            Console.WriteLine("  [1] United States");
            Console.WriteLine("  [2] United Kingdom");
            Console.WriteLine("  [3] Canada");
            Console.WriteLine("  [4] Australia");
            Console.WriteLine("  [5] Germany");

            while (true)
            {
                Console.Write("\n  ➤ Choose Country: ");

                if (int.TryParse(Console.ReadLine(), out int countryId) &&
                    countryId >= 1 &&
                    countryId <= 5)
                {
                    return countryId;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Please enter a valid Country ID (1-5).");
                Console.ResetColor();
            }
        }

        private void UpdateContact()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║            UPDATE CONTACT              ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            // Get Contact ID
            int contactId = ReadInt("  Contact ID : ");

            Console.WriteLine();

            // Read contact information
            Console.Write("  First Name : ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("  Last Name  : ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("  Email      : ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("  Phone      : ");
            string phone = Console.ReadLine() ?? string.Empty;

            Console.Write("  Address    : ");
            string address = Console.ReadLine() ?? string.Empty;

            // Select country
            int countryId = ReadCountryId();

            // Create DTO
            var contact = new BusinessLogicLayer.DTOs.DtoContact
            {
                ContactID = contactId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address,
                CountryID = countryId
            };

            // Update contact
            bool result = _contactService.Update(contact);

            Console.WriteLine();

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"  ✓ Contact with ID {contactId} updated successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"  ✗ Failed to update contact with ID {contactId}.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        private int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value) &&
                    value > 0)
                {
                    return value;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Please enter a valid number.");
                Console.ResetColor();
            }
        }

        private void DeleteContact()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║            DELETE CONTACT              ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            // Get Contact ID
            int contactId = ReadInt("  Contact ID : ");

            Console.WriteLine();

            // Confirm deletion
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  ⚠ Are you sure you want to delete contact {contactId}? (Y/N): ");
            Console.ResetColor();

            string confirmation = Console.ReadLine() ?? string.Empty;

            if (!confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  → Delete operation cancelled.");
                Console.ResetColor();

                Console.WriteLine("\n  Press any key to continue...");
                Console.ReadKey();

                return;
            }

            // Delete contact
            bool result = _contactService.Delete(contactId);

            Console.WriteLine();

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"  ✓ Contact with ID {contactId} deleted successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"  ✗ Contact with ID {contactId} was not found.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        private string ShowMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("║           CONTACT MANAGEMENT            ║");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.WriteLine("║                                         ║");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("║     [1]    List Contacts                ║");
            Console.WriteLine("║     [2]    Add Contact                  ║");
            Console.WriteLine("║     [3]    Update Contact               ║");
            Console.WriteLine("║     [4]    Delete Contact               ║");
            Console.WriteLine("║     [5]    Find Contact By ID           ║");
            Console.WriteLine("║     [6]    Exit                         ║");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("║                                         ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  ➤ Choose an option: ");

            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine() ?? string.Empty;

            Console.ResetColor();

            return choice;
        }

    }

}

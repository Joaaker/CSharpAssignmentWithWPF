using System.Diagnostics;
using System.Text.RegularExpressions;
using Shared.Interface;
using Shared.Models;

namespace Shared.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    public List<ContactObjects> Contacts { get; private set; } = [];

    public bool AddContact(ContactObjects contact)
    {
        try
        {
            if (contact == null)
            {
                Debug.WriteLine("Contact cannot be null");
                return false;
            }

            var contactList = contactRepository.GetContacts() ?? [];
            if (contactList.Any(c => c.Id == contact.Id))
            {
                Debug.WriteLine($"Contact with ID {contact.Id} already exists.");
                return false;
            }

            Contacts.Add(contact);
            contactRepository.SaveContacts(Contacts);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public ContactObjects GetContactById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentNullException(nameof(id), "ID cannot be null or empty");

        try
        {
            var contactList = contactRepository.GetContacts() ?? [];
            var contact = contactList.FirstOrDefault(u => u.Id == id);
            return contact ?? throw new ArgumentException("A contact with that ID was not found.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw new ApplicationException("An unexpected error occurred while retrieving the contact.", ex);
        }
    }

    public IEnumerable<ContactObjects>? GetAllContacts()
    {
        try
        {
            Contacts = contactRepository.GetContacts() ?? [];
            return Contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public bool UpdateContact(ContactObjects contact)
    {
        try
        {
            if (contact == null)
            {
                Debug.WriteLine("Contact cannot be null");
                return false;
            }
            var contactList = contactRepository.GetContacts() ?? [];
            var contactToUpdate = contactList.FirstOrDefault(c => c.Id == contact.Id);
            if (contactToUpdate == null)
            {
                Debug.WriteLine("Contact was not found.");
                return false;
            }

            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.Address = contact.Address;
            contactToUpdate.ZipCode = contact.ZipCode;
            contactToUpdate.City = contact.City;

            contactRepository.SaveContacts(contactList);
            return true;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }

    }

    public bool DeleteContact(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                Debug.WriteLine("ID cannot be null or empty");
                return false;
            }

            var contactList = contactRepository.GetContacts() ?? [];
            var contactToDelete = contactList.FirstOrDefault(c => c.Id == id);
            if (contactToDelete == null)
            {
                Debug.WriteLine($"No contact with ID {id} was found.");
                return false;
            }

            contactList.Remove(contactToDelete);
            contactRepository.SaveContacts(contactList);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
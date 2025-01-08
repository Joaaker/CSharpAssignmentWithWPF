using Shared.Models;

namespace Shared.Interface;

public interface IContactService
{
    bool AddContact(ContactObjects contact);
    ContactObjects GetContactById(string id);
    IEnumerable<ContactObjects>? GetAllContacts();
    bool UpdateContact(ContactObjects contact);
    bool DeleteContact(string id);
}
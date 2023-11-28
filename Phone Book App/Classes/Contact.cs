
using Phone_Book_App.Classes.Enums;

namespace Phone_Book_App.Classes
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public long  PhineNumber { get; set; }
        public Preferences Preferences { get; set; }
        public Contact(string name, string surename, long phoneNumber) 
        {
            Name = name; Surename = surename; PhineNumber = phoneNumber;
        }


    }
}

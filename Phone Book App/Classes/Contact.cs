
using Phone_Book_App.Classes.Enums;
using Phone_Book_App.Classes.Utilities;

namespace Phone_Book_App.Classes
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public long  PhoneNumber { get; set; }
        public Preferences Preferences { get; set; } = Preferences.Normal;

        public Contact(string name, string surename, long phoneNumber) 
        {
            Name = name; Surename = surename; PhoneNumber = phoneNumber;
        }

		static public Preferences EditPreference()
		{
			var x = Inputs.OptionInput(new List<string> { "Favorit", "Normalan", "Blokiran" });
			switch (x)
			{
				case 1:
					return Preferences.Favourite;
					break;
				case 2:
					return Preferences.Normal;
					break;
				case 3:
					return Preferences.Blocked;
					break;
			}
			return Preferences.Normal;
		}
		static public void WriteContact(Contact contact)
		{
			Console.WriteLine(contact.Name + " " + contact.Surename + ": " + contact.PhoneNumber);
		}
		static public void WriteContactDictionary(Dictionary<Contact, List<Call>> dict)
		{
			foreach (var item in dict.Keys)
			{
				WriteContact(item);
			}
		}
		static public Contact AddContact()
		{
			var newContact = new Contact(Inputs.StringInput("Unesi ime kontakta: "), Inputs.StringInput("Unesi prezime kontakta"), Inputs.LongInput("Unesi Broj kontakta"));
			return newContact;
		}
		static public Contact FindContact(Dictionary<Contact, List<Call>> dict)
		{
			int x = Inputs.OptionInput(new List<string> { "1 - Pronađi kontakt po imenu i prezimenu", "2 - Pronađi po broju" });
			if (x == 1)
			{
				return FindContactByName(dict);
			}
			else if (x == 2)
			{
				return FindContactByNumber(dict);
			}
			return new Contact("", "", 0);

		}
		static private Contact FindContactByName(Dictionary<Contact, List<Call>> dict)
		{
			var name = Inputs.StringInput("Unesi ime kontakta");
			var surename = Inputs.StringInput("Unesi prezime kontakta");
			var contacts = new List<Contact>();
			foreach (var item in dict.Keys)
			{
				if (item.Name == name && item.Surename == surename)
				{
					contacts.Add(item);
				}
			}
			if (contacts.Count() > 1)
			{
				var i = 0;
				foreach (var item in contacts)
				{
					Console.WriteLine("Za ovaj kontakt daberi - " + i);
					Contact.WriteContact(item);
					i++;
				}
				var x = Inputs.RangeElementInput(1, i, "");
				return contacts[x - 1];
			}
			else if (contacts.Count() == 0)
			{
				Console.WriteLine("Kontakt nije pronađen");
			}
			return new Contact("", "", 0);
		}
		static public Contact FindContactByNumber(Dictionary<Contact, List<Call>> dict)
		{
			var phoneNumber = Inputs.LongInput("Unesi broj mobitela");
			foreach (var item in dict.Keys)
			{
				if (item.PhoneNumber == phoneNumber)
				{
					return item;
				}
			}
			return new Contact("", "", 0);
		}

	}
}

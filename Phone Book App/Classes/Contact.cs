
using Phone_Book_App.Classes.Enums;
using Phone_Book_App.Classes.Utilities;

namespace Phone_Book_App.Classes
{
    public class Contact
    {
        public string Name { get; set; }
		public string Surename { get; set; }
		public string  PhoneNumber { get; set; }
        public Preferences Preferences { get; set; } = Preferences.Normal;

        public Contact(string name, string surename, string phoneNumber) 
        {
            Name = name; Surename = surename; PhoneNumber = phoneNumber;
        }

		public Contact()
		{
			Name = ""; Surename = ""; PhoneNumber = "";
		}

		//+ +
		static public void WriteContact(Contact contact)
		{
			Console.WriteLine(contact.Name + " " + contact.Surename + ": " + contact.PhoneNumber);
		}
		//+ +
		static public void WriteContactDictionary(Dictionary<Contact, List<Call>> dict)
		{
			foreach (var item in dict.Keys)
			{
				WriteContact(item);
			}
		}
		//+ + +
		static public Contact AddContact(Dictionary<Contact, List<Call>> dict)
		{
			var name = Inputs.StringInput("Unesi ime kontakta: ");
			var surename = Inputs.StringInput("Unesi prezime kontakta: ");
			var phoneNumber = Inputs.PhoneNumberInput();
			while (CheckIfNumberIsTaken(dict,phoneNumber))
			{
                Console.WriteLine("Broj je već u imeniku, unesi novi broj: ");
                phoneNumber = Inputs.PhoneNumberInput();
			}
			var newContact = new Contact(name, surename, phoneNumber);
			return newContact;
		}
		//+ +
		static public Preferences EditPreference()
		{
			var x = Inputs.OptionInput(new List<string> { "1 - Favorit", "2 - Normalan", "3 - Blokiran" });
			switch (x)
			{
				case 1:
					return Preferences.Favourite;
				case 2:
					return Preferences.Normal;
				case 3:
					return Preferences.Blocked;
			}
			return Preferences.Normal;
		}
		//+ +
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
			return new Contact();

		}
		//+ +
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
				var i = 1;
				foreach (var item in contacts)
				{
					Console.WriteLine("Za ovaj kontakt daberi - " + i);
					Contact.WriteContact(item);
					i++;
				}
				var x = Inputs.RangeElementInput(1, i, "");
				return contacts[x - 1];
			}
			else if (contacts.Count() == 1)
			{	
				return contacts[0];

			}
			else { 
				Inputs.Wait("Kontakt nije pronađen");
				return new Contact();
			}
		}
		//+ +
		static private Contact FindContactByNumber(Dictionary<Contact, List<Call>> dict)
		{
			var numberFound = false;
			var phoneNumber = Inputs.PhoneNumberInput();
			foreach (var item in dict.Keys)
			{
				if (item.PhoneNumber == phoneNumber)
				{
					numberFound = true;
					return item;
				}
			}
			if (!numberFound)
			{
				Inputs.Wait("Broj nije pronađen");
			}
			return new Contact();

		}
		//+ +
		static private bool CheckIfNumberIsTaken(Dictionary<Contact, List<Call>> dict, string phoneNumber)
		{
			foreach (var item in dict.Keys)
			{
				if (item.PhoneNumber == phoneNumber)
				{
					return true;
				}
			}
			return false;
		}
	}
}

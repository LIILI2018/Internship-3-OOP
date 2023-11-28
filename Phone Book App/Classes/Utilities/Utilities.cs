using Phone_Book_App.Classes.Enums;

namespace Phone_Book_App.Classes.Utilities
{
	static public class Utilities
	{ 
		//+ +
		static public void WriteContact(Contact contact)
		{
            Console.WriteLine(contact.Name + " " + contact.Surename + ": " + contact.PhineNumber );
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
			var newContact = new Contact(Inputs.StringInput("Unesi ime kontakta: "),Inputs.StringInput("Unesi prezime kontakta"),Inputs.LongInput("Unesi Broj kontakta"));
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
		static public Contact FindContactByName(Dictionary<Contact, List<Call>> dict)
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
					Utilities.WriteContact(item);
					i++;
				}
				var x = Inputs.RangeElementInput(1, i, "");
				return contacts[x - 1];
			}
			else if (contacts.Count() == 0)
			{
				Console.WriteLine("Kontakt nije pronađen");
			}
			return new Contact("","",0);
		}
		static public Contact FindContactByNumber(Dictionary<Contact, List<Call>> dict)
		{
			var phoneNumber = Inputs.LongInput("Unesi broj mobitela");
			foreach (var item in dict.Keys)
			{
				if (item.PhineNumber == phoneNumber)
				{
					return item;
				}
			}
			return new Contact("", "", 0);
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
		static public List<Call> SortCallsByDate(List<Call> calls)
		{
			var listOfAllDates = new List<DateTime>();
			var sortedList = new List<Call>();
			foreach (var item in calls)
			{
				listOfAllDates.Add(item.CallStart);
			}
			listOfAllDates.Sort();
			foreach (var date in listOfAllDates)
			{
				foreach (var call in calls)
				{
					if (date == call.CallStart)
					{
						sortedList.Add(call);
						sortedList.Remove(call);
						break;
					}
				}
			}
			return sortedList;
		}
		static public void WriteCallsByDate(List<Call> calls)
		{
			var sortedCalls = SortCallsByDate(calls);
			foreach (var item in sortedCalls)
			{
				WriteCall(item);
			}
		}
	}
}

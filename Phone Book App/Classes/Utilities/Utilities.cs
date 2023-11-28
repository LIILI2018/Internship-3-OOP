using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book_App.Classes.Utilities
{
	static public class Utilities
	{
		static public void WriteContact(Contact contact)
		{
            Console.WriteLine(contact.Name + " " + contact.Surename + ": " + contact.PhineNumber );
        }
		static public void WriteContactDictionary(Dictionary<Contact, List<Contact>> dict)
		{
			foreach (var item in dict)
			{
				WriteContact(item.Key);
			}
		}
		static public Contact AddContact() 
		{
			var newContact = new Contact(Inputs.StringInput("Unesi ime kontakta: "),Inputs.StringInput("Unesi prezime kontakta"),Inputs.LongInput("Unesi Broj kontakta"));
			return newContact;
		}
		static public Contact FindContact(Dictionary<Contact, List<Contact>> dict)
		{
			int x = Inputs.OptionInput(new List<string> { "1 - Pronađi kontakt po imenu i prezimenu", "2 - Pronađi po broju" });
			if (x == 1)
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
						Console.WriteLine("Odaberi" + i);
						Utilities.WriteContact(item);
						i++;
					}
					x = Inputs.OptionInput(new List<string>());
					return contacts[x - 1];
				}
				else if (x == 0)
				{
				    Console.WriteLine("Kontakt nije pronađen");
					return new Contact("","", 0 );	
				}
				else
				{
					return contacts[0];
				}
			}
		}
	}
}

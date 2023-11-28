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
	}
}

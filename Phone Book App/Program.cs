using Phone_Book_App.Classes;
using Phone_Book_App.Classes.Utilities;


var defaultContacts = new List<Contact>() 
{
	new Contact("Luko","Paljetak",0913630556),
	new Contact("Jean","Marquis",1234567890),
	new Contact("Petar","Stijena",0987654321),
	new Contact("Ivan","Leptirić",1639653474),
	new Contact("Dušan","Stijena",1493273434),
	new Contact("Kapetan Ivan","Slavuj",0253744854),
	new Contact("Max","Verstapen",9999999999)

};
var DefaultCalls = new List<Call>
{
	new Call(DateTime.Now.AddDays(-100)),
	new Call(DateTime.Now.AddDays(-2)),
	new Call(DateTime.Now.AddDays(-3)),
	new Call(DateTime.Now.AddDays(-2)),
	new Call(DateTime.Now.AddDays(-5)),
};
var ContactDictionary = new Dictionary<Contact, List<Contact>>()
{
	{defaultContacts[0],new List<Contact>(){defaultContacts[1],defaultContacts[2],defaultContacts[3]}},
	{defaultContacts[1],new List<Contact>(){defaultContacts[2],defaultContacts[3],defaultContacts[5]}},
	{defaultContacts[2],new List<Contact>(){defaultContacts[1],defaultContacts[4],defaultContacts[3]}},
	{defaultContacts[3],new List<Contact>(){defaultContacts[2],defaultContacts[5],defaultContacts[3]}},
	{defaultContacts[4],new List<Contact>(){defaultContacts[4],defaultContacts[2],defaultContacts[6]}},
	{defaultContacts[5],new List<Contact>(){defaultContacts[1],defaultContacts[5],defaultContacts[3]}},
	{defaultContacts[6],new List<Contact>(){defaultContacts[2],defaultContacts[1],defaultContacts[6]}}
};

int x;
x = Inputs.OptionInput(new List<string> { " 1 - Ispiši sve kontakte", "2 - Dodaj novi kontakt u imenik", "3 - Brisanje kontakata iz imenika", "4 - Editiranje preferenca kontakta", "5 - Upravljanje kontaktom" });

switch (x)
{
	case 1:
		Utilities.WriteContactDictionary(ContactDictionary);
		break;

	case 2:
		ContactDictionary.Add(Utilities.AddContact(), new List<Contact>());
		break;

	case 3:
		var contact = Utilities.FindContact(ContactDictionary);
		ContactDictionary.Remove(contact);
        break;

	case 4:
		var Contact = Utilities.FindContact(ContactDictionary);
		Contact.Preferences = Utilities.EditPreference();
		break;
	case 5:
		OpenSubmenu();
		break;
	case 6:
		break;
}

void OpenSubmenu()
{
	x = Inputs.OptionInput(new List<string> { " 1 - Ispiši sve pozive", "2 - Kreirej novi poziv"});
	switch (x)
	{
		case 1:
			Utilities.WriteContactDictionary(ContactDictionary);
			break;

		case 2:
			ContactDictionary.Add(Utilities.AddContact(), new List<Contact>());
			break;

	}
}
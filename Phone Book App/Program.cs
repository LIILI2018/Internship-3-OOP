using Phone_Book_App.Classes;
using Phone_Book_App.Classes.Utilities;

var defaultContacts = new List<Contact>() 
{
	new Contact("Luko","Paljetak","0913630551"),
	new Contact("Luko","Paljetak","0913630555"),
	new Contact("Jean","Marquis","1234567890"),
	new Contact("Petar","Stijena","0987654321"),
	new Contact("Ivan","Leptirić","1639653474"),
	new Contact("Dušan","Stijena","1493273434"),
	new Contact("Kapetan Ivan","Slavuj","1"),
};
var DefaultCalls = new List<Call>
{
	new Call(DateTime.Now.AddDays(-100)),
	new Call(DateTime.Now.AddDays(-2)),
	new Call(DateTime.Now.AddDays(-3)),
	new Call(DateTime.Now.AddDays(-2)),
	new Call(DateTime.Now.AddDays(-5)),
};
var ContactDictionary = new Dictionary<Contact, List<Call>>()
{
	{defaultContacts[0],new List<Call>(DefaultCalls)},
	{defaultContacts[1],new List<Call>(DefaultCalls)},
	{defaultContacts[2],new List<Call>(DefaultCalls)},
	{defaultContacts[3],new List<Call>(DefaultCalls)},
	{defaultContacts[4],new List < Call >(DefaultCalls)},
	{defaultContacts[5],new List < Call >(DefaultCalls)},
	{defaultContacts[6],new List < Call >(DefaultCalls)}
};

StartMenu();

void StartMenu() {
	int x;
	do {  
		Console.Clear();
		x = Inputs.OptionInput(new List<string> { "1 - Ispiši sve kontakte", "2 - Dodaj novi kontakt u imenik", "3 - Brisanje kontakata iz imenika", "4 - Uređivanje preferenca", "5 - Upravljanje pozivima","6 - Ispis svih pozia","7 - Izlaz iz aplikacije" });
		
		switch (x)
		{	
			// + +
			case 1:
				Contact.WriteContactDictionary(ContactDictionary);
				Inputs.Wait("");
				break;
			// + +
			case 2:
				ContactDictionary.Add(Contact.AddContact(ContactDictionary), new List<Call>());
				break;
			// + +
			case 3:
				var contact = Contact.FindContact(ContactDictionary);
                ContactDictionary.Remove(contact);
				break;
			// + +
			case 4:
				contact = Contact.FindContact(ContactDictionary);
				contact.Preferences = Contact.EditPreference();
				break;

			case 5:
				OpenSubmenu();
				break;

			case 6:
				Call.WriteAllCalls(ContactDictionary);
				Inputs.Wait("");
				break;
		}
	} while (x != 7);
}
void OpenSubmenu()
{
	int x;
	x = Inputs.OptionInput(new List<string> { "1 - Ispiši sve pozive s nekom osobom", "2 - Stvori novi poziv","3 - Izađi iz submenua"});
	switch (x)
	{
		//+ +
		case 1:
			var contact = Contact.FindContact(ContactDictionary);
            if (contact.PhoneNumber != "")
			{
				Call.WriteCallsByDate(ContactDictionary[contact]);
			}
			break;
		// + +
		case 2:
			Call.CreateNewCall(ContactDictionary);
			break;
		case 3:
			break;
	}
}
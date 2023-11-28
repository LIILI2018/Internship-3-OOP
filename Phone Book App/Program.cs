using Phone_Book_App.Classes;
using Phone_Book_App.Classes.Utilities;

var defaultContacts = new List<Contact>() 
{
	new Contact("Luko","Paljetak","0913630556"),
	new Contact("Jean","Marquis","1234567890"),
	new Contact("Petar","Stijena","0987654321"),
	new Contact("Ivan","Leptirić","1639653474"),
	new Contact("Dušan","Stijena","1493273434"),
	new Contact("Kapetan Ivan","Slavuj","0253744854"),
	new Contact("Max","Verstapen","9999999999")

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
	{defaultContacts[0],DefaultCalls},
	{defaultContacts[1],DefaultCalls},
	{defaultContacts[2],DefaultCalls},
	{defaultContacts[3],DefaultCalls},
	{defaultContacts[4],DefaultCalls},
	{defaultContacts[5],DefaultCalls},
	{defaultContacts[6],DefaultCalls}
};


StartMenu();

void StartMenu() {
	int x;
	do {  
		Console.Clear();
		x = Inputs.OptionInput(new List<string> { "1 - Ispiši sve kontakte", "2 - Dodaj novi kontakt u imenik", "3 - Brisanje kontakata iz imenika", "4 - Editiranje preferenca kontakta", "5 - Upravljanje kontaktom","6 - Ispis svih pozia","7 -izlaz iz aplikacije" });
		
		switch (x)
		{	
			//+ +
			case 1:
				Contact.WriteContactDictionary(ContactDictionary);
				Inputs.Wait("");
				break;
			//+ 
			case 2:
				ContactDictionary.Add(Contact.AddContact(ContactDictionary), new List<Call>());
				break;

			case 3:
				var contact = Contact.FindContact(ContactDictionary);
				ContactDictionary.Remove(contact);
				break;

			case 4:
				contact = Contact.FindContact(ContactDictionary);
				contact.Preferences = Contact.EditPreference();
				break;
			case 5:
				OpenSubmenu();
				break;
			case 6:
				break;
		}
	} while (x != 7);
}
void OpenSubmenu()
{
	int x;
	x = Inputs.OptionInput(new List<string> { " 1 - Ispiši sve pozive", "2 - Kreirej novi poziv"});
	switch (x)
	{
		case 1:
			var contact = Contact.FindContact(ContactDictionary);
			Call.WriteCallsByDate(ContactDictionary[contact]);
			break;

		case 2:
			break;

	}
}
using Phone_Book_App.Classes;
var allContacts = new List<Contact>() 
{
	new Contact("Luko","Paljetak",0913630556),
	new Contact("Jean","Marquis",1234567890),
	new Contact("Petar","Stijena",0987654321),
	new Contact("Ivan","Leptirić",1639653474),
	new Contact("Dušan","Stijena",1493273434),
	new Contact("Kapetan Ivan","Slavuj",0253744854),
	new Contact("Max","Verstapen",9999999999)

};
var ContactDictionary = new Dictionary<Contact, List<Contact>>()
{
	{allContacts[0],new List<Contact>(){allContacts[1],allContacts[2],allContacts[3]}},
	{allContacts[1],new List<Contact>(){allContacts[2],allContacts[3],allContacts[5]}},
	{allContacts[2],new List<Contact>(){allContacts[1],allContacts[4],allContacts[3]}},
	{allContacts[3],new List<Contact>(){allContacts[2],allContacts[5],allContacts[3]}},
	{allContacts[4],new List<Contact>(){allContacts[4],allContacts[2],allContacts[6]}},
	{allContacts[5],new List<Contact>(){allContacts[1],allContacts[5],allContacts[3]}},
	{allContacts[6],new List<Contact>(){allContacts[2],allContacts[1],allContacts[6]}}
};
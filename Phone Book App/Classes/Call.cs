using Phone_Book_App.Classes.Enums;
using Phone_Book_App.Classes.Utilities;
using System.Security.Cryptography;

namespace Phone_Book_App.Classes
{
	public class Call
	{
		public DateTime CallStart { get; set; }
		public CallStatuses CallStatus { get; set; } = CallStatuses.Finished;
		public Call()
		{
			CallStart = DateTime.Now;
		}
		public Call(CallStatuses callStatus)
		{
			CallStart = DateTime.Now;
			CallStatus = callStatus;
		}
        public Call(DateTime startTime)
        {
            CallStart = startTime;
        }


		//+ +
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
						break;
					}
				}
			}
			return sortedList;
		}
		//+ +
		static public void WriteCall(Call call)
		{
			Console.WriteLine("Poziv je uspostavljen: " + call.CallStart);
			Console.WriteLine("Status poziva: " + call.CallStatus);
			Console.WriteLine();
		}
		//+ +
		static public void WriteAllCalls(Dictionary<Contact, List<Call>> dict)
		{
			foreach (var item in dict.Keys) 
			{ 
				Console.WriteLine(item.Name + " " + item.Surename + ": " + item.PhoneNumber + "      ");
				foreach (var item2 in dict[item])
				{
					WriteCall(item2);

				}
			}
		}
		//+ +
		static public void WriteCallsByDate(List<Call> calls)
		{
			var sortedCalls = SortCallsByDate(calls);
			foreach (var item in sortedCalls)
			{
				WriteCall(item);
			}
			Inputs.Wait("");
		}

		//+
		static public void CreateNewCall(Dictionary<Contact, List<Call>> dict)
		{
			var contact = Contact.FindContact(dict);
			if (contact.PhoneNumber != "")
			{
				if (contact.Preferences != Preferences.Blocked)
				{
					if (new Random().Next(1, 4) == 1)
					{
						dict[contact].Add(new Call(CallStatuses.Missed));
						Inputs.Wait("Osoba nije odgovorila na poziv");
					}
					else
					{
						var newCall = new Call(CallStatuses.InProgress);
						dict[contact].Add(newCall);
						Inputs.Wait("Poziv uspješno uspostavljen");
						for (int i = new Random().Next(1, 21); i > 0; i--)
						{
							Console.WriteLine("Poziv traje još: " + i + " sekundi");
							Thread.Sleep(1000);
						}
						newCall.CallStatus = CallStatuses.Finished;
					}
				}
				else
				{
					Inputs.Wait("Nije moguče uspostaviti poziv sa blokiranom osobom");
				}
			}
		}
	}
}

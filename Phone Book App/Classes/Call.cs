using Phone_Book_App.Classes.Enums;

namespace Phone_Book_App.Classes
{
	public class Call
	{
		public DateTime CallStart { get; set; }
		public CallStatuses CallStatus { get; set; } = CallStatuses.Finished;
        public Call(DateTime startTime)
        {
            CallStart = startTime;
        }
		public Call()
		{
			CallStart = DateTime.Now;
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
		static public void WriteCall(Call call)
		{
			Console.WriteLine("Poziv je uspostavljen: " + call.CallStart);
			Console.WriteLine("Status poziva: " + call.CallStatus);
			Console.WriteLine();
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

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
	}
}

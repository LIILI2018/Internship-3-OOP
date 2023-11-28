
namespace Phone_Book_App.Classes.Utilities
{
	static public class Inputs
	{
		static int IntInput(string txt)
		{
			Console.WriteLine(txt);
			int y;
			bool success = false;
			do
			{
				success = int.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();
			return y;
		}
		static string StringInput(string txt)
		{
            Console.WriteLine(txt);
            var y = Console.ReadLine();
			Console.Clear();
			return y;
		}
		static DateTime DateInput(string txt)
		{
            Console.WriteLine(txt);
            DateTime y;
			bool success = false;
			do
			{
				success = DateTime.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();

			return y;
		}
		static double DoubleInput(string txt)
		{
            Console.WriteLine(txt);
			double y;
			bool success = false;
			do
			{
				success = double.TryParse(Console.ReadLine(), out y);
			} while (!success);
			Console.Clear();

			return y;
		}
		static void Wait(String txt)
		{
			Console.WriteLine(txt);
			Console.WriteLine("Klikni enter za nastavak: ");
			Console.ReadLine();
		}
		static int OptionInput(List<string> txt)
		{
			Console.WriteLine("0 - Izlaz iz aplikacije");

			foreach (var item in txt)
			{
				Console.WriteLine(item);
			}
			int y = 0;
			bool success = false;
			do
			{
				success = int.TryParse(Console.ReadLine(), out y);
			} while (!success || y > txt.Count());
			Console.Clear();
			return y;
		}
	}
}

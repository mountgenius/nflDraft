using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nfl_draft_project
{
	class Player
	{
		public string player { get; set; }
		public int pay { get; set; }
		public string college { get; set; }
		public string position { get; set; }

	}
	class Program
	{
		public static void welcomeOptions()
		{
			Console.WriteLine("Welcome to the draft picker!!!\nYou may pick up to 5 players to draft, up to $95 million");
		}
		public static int positionSelection()
		{
			Console.WriteLine("\n1. Quarterbacks\n2. Running Backs\n3. Wide Receivers\n4. Defensive Linemen\n5. Defensive-Backs");
			Console.WriteLine("6. Tight Ends\n7. Line-Backer's\n8. Offensive Tackles\n\nPlease enter the number corresponding to position...");
			string selectionString = Console.ReadLine();
			Console.Clear();
			int selectionInt = Int32.Parse(selectionString);
			return selectionInt;
		}
		public static int drafting()
		{
			Console.WriteLine("\nWhich player (number 1-5) would you like to draft?");
			string rawUserInput = Console.ReadLine();
			int userInput= Int32.Parse(rawUserInput);
			Console.Clear();
			return userInput;
		}
		static void Main(string[] args)
		{
			string[,] players =
			{
			{ "Mason Rudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield" },
			{ "Saquon Barkley","Derrius Guice", "Bryce Love","Ronald Jones 11","Damien Harris" },
			{ "Courtland Sutton","James Washington","Marcell Ateman","Anthony Miller","Calvin Ridley" },
			{ "Maurice Hurst","Vita Vea","Taven Bryan","Da'Ron Payne","Harrison Phillips" },
			{ "Joshua Jackson","Derwin James","Denzal Ward","Minkah Fitzpatrick","Isiah Oliver" },
			{ "Mark Andrews","Dallas Goedert","Jaylen Samuels","Mike Gesicki","Troy Fumagalli" },
			{ "Roquan Smith","Tremaine Edmundo","Kendall Joseph","Dorian O'Daniel","Malik Jefferson" },
			{ "Orlando Brown","Kolton Miller","Chukwuma Okorafor","Connor Williams","Mike McGlinchey"}
			};
			string[,] school =
			{
			{ "Oklahoma State","Louisville","UCLA","Southern California","Oklahoma" },
			{ "Penn State", "LSU","Stanford","Southern California","Alabama" },
			{ "Southern Methodist","Oklahoma State","Oklahoma State","Memphis","Alabama" },
			{ "Michigan","Washington","Florida","Alabama","Stanford" },
			{ "Iowa","Florida State","Ohio State","Alabama","Colorado" },
			{ "Oklahoma","So. Dakota State","NC State","Penn State","Wisconsin" },
			{ "Georgia","Virgina Tech","Clemson","CLemson","Texas" },
			{ "Oklahoma","UCLA","Western Michigan","Texas","Notre Dame" }
			};
			string[,] positions =
			{
			{ "Quarterback","Quarterback","Quarterback","Quarterback","Quarterback" },
			{ "Running Back","Running Back","Running Back","Running Back","Running Back" },
			{ "Wide-Reciever","Wide-Reciever","Wide-Reciever","Wide-Reciever","Wide-Reciever" },
			{ "Defensive Lineman","Defensive Lineman","Defensive Lineman","Defensive Lineman","Defensive Lineman" },
			{ "Defensive-Back","Defensive-Back","Defensive-Back","Defensive-Back","Defensive-Back" },
			{ "Tight End","Tight End","Tight End","Tight End","Tight End" },
			{ "Line-Backer","Line-Backer","Line-Backer","Line-Backer","Line-Backer" },
			{ "Offensive Tackle","Offensive Tackle","Offensive Tackle","Offensive Tackle","Offensive Tackle" }
			};
			int[,] salary =
			{
			{ 26400100, 20300100, 17420300, 13100145, 10300000 },
			{ 24500100, 19890200, 18700800, 15000000, 11600400 },
			{ 23400000, 21900300, 19300230, 13400230, 10000000 },
			{ 26200300, 22000000, 16000000, 18000000, 13000000 },
			{ 24000000, 22500249, 20000100, 16000200, 11899999 },
			{ 27800900, 21500249, 20000100, 16000200, 11899999 },
			{ 22900300, 19000590, 18000222, 12999999, 10000000 },
			{ 23000000, 20000000, 19400000, 16200700, 15900000 }
			};
			welcomeOptions();
			int z = 0;
			int q = 0;
			int totalPay = 0;
			List<Player> draftedPlayers = new List<Player>();
			int remaining = 95000000;
			while (z < 5)
			{
				int selectionInt = positionSelection();

				for (var x = 0; x < players.GetLength(1); x++)
				{
					Console.WriteLine($"{x + 1}  {players[selectionInt - 1, x]}  " +
						$"{salary[selectionInt - 1, x]}  {school[selectionInt - 1, x]} "); //add salary, school
				}
				int userInput = drafting();
				Console.WriteLine("You have ${0} remaining\n", remaining);
				Console.WriteLine(positions[selectionInt - 1, userInput - 1]);
				Console.WriteLine(players[selectionInt - 1, userInput - 1]);
				Console.WriteLine(school[selectionInt - 1, userInput - 1]);
				Console.WriteLine(salary[selectionInt - 1, userInput - 1]);

				Console.WriteLine("\nConfirm choice? (Y/N)");
				string y = Console.ReadLine().ToUpper();
				if (y == "Y")
				{
					Player selectedPlayer = new Player();
					selectedPlayer.player = players[selectionInt - 1, userInput - 1];
					selectedPlayer.position = positions[selectionInt - 1, userInput - 1];
					selectedPlayer.college = school[selectionInt - 1, userInput - 1];
					selectedPlayer.pay = salary[selectionInt - 1, userInput - 1];
					draftedPlayers.Add(selectedPlayer);
					remaining = remaining - (selectedPlayer.pay = salary[selectionInt - 1, userInput - 1]);
					totalPay=totalPay + (selectedPlayer.pay = salary[selectionInt - 1, userInput - 1]);
					if (userInput < 4)
					{
						q = q + 1;
					}
				}
				if (y == "N")
				{
					z = z - 1;
				}
				if (z != 4)
				{
					Console.WriteLine("would you like to draft another player? (Y/N)");
					y = Console.ReadLine().ToUpper();
					if (y == "N")
					{
						Console.Clear();
						z = 5;
					}
					if (y == "Y")
					{
						Console.Clear();
						z++;
					}
				}
				int budget = 95000000;
				foreach (var i in draftedPlayers)
				{
					Console.WriteLine(i.player + " , " + i.position + " , " + i.college + " , " + i.pay );
				}
				Console.WriteLine("Your Total salary commitment is ${0}.", totalPay);
				Console.WriteLine("You have $" + (budget - totalPay) + " remaining.");
			}
			if (q >= 3)
			{
				if (totalPay <= 65000000)
				{
					Console.WriteLine("Cost Effective");
				}
			}
		}
	}
}
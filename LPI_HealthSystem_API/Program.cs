using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPI_HealthSystem_API
{
	class Program
	{
		static void Main()
		{
			var Entity = new YourMom();

			Entity.DefaultValues();

			Entity.ShowHUD();

			Entity.TakeDamage(120);

			Entity.ShowHUD();


			Console.ReadKey(true);
		}
	}

    public class YourMom
    {
		// Health system handles the player health, shield, lives, etc...
		// Variables: Health, Shield, Lives, Spillover, etc...
		// Methods: ShowHUD(), TakeDamage(int damage), Heal(int hp), RegenerateShield(int hp), etc...
		// Simulated gameplay that tests the code. Showcasing range and error checking.
		// Take Damage Spill down
		// extra mile:
		//             > evolve it beyond a health system, into a player statistics system. 
		//             > experience points + level-up system
		//             > create your own variables, create your own methods.
		//             > create sub-methods
		//			   > instead of putting 0 everywhere. Have a defult min, max value.
		//             > etc...

		int Health;
		static int Shield;
		static int Lives;

		static int Damage;
		

		void test(int dmg)
        {
			Health = 0;

			if (Health <= 0)
			{
				Health = 0;
				DecLives(); // is this broken? T^T
			}
		}

		public void DefaultValues()
        {
			Health = 100;
			Shield = 100;
			Lives = 3;
			Damage = 0;
        }

		void DecLives() //not work?
		{
			if (Lives == 0)
			{
				Console.WriteLine("Game Over"); //this does nothing
			}
			else if (Lives < 0)
			{
				Lives = Lives - 1;
				Console.WriteLine("Revive");
				Health = 100;
				Shield = 100;
			}
			
		}

		int SpillOver(int dmg)
        {
			var spill = dmg - Shield;
			Health -= spill;

			return spill;
        }

		public void TakeDamage(int dmg) // lol fix this
        {
            if (dmg < 0)
            {
				Console.WriteLine("Error! Damage must be positive");
				return;
			}

			if (dmg > Shield)
			{
				SpillOver(dmg);
				Shield = 0;
			}
			else if (Shield > 0) 
            {
				Shield = Shield - dmg;
            }
			else if (Health > 0)
            {
				Health = Health - dmg;
			}

		}

		void Heal(int hp)
        {
			if (hp < 0)
			{
				//hp = 0; // no u
				Console.WriteLine("error!");
				return;
			}

			Health = Health + hp;

			if (Health > 100)
            {
				Health = 100;
            }
		}

		void RegenShield(int hp)
        {
			if (hp < 0)
			{
				//hp = 0; // no u
				Console.WriteLine("error!");
				return;
			}

			Shield = Shield + hp;

			if (Shield > 100)
            {
				Shield = 100;
            }
		}


		void HealthStatus()
		{
			if (Health == 100)
			{
				Console.WriteLine("+ Prefect Health");
			}
			else if (Health >= 75)
			{
				Console.WriteLine("+ Healthy");
			}
			else if (Health >= 50)
			{
				Console.WriteLine("+ Hurt");
			}
			else if (Health >= 10)
			{
				Console.WriteLine("+ Badly hurt");
			}
			else if (Health > 0)
			{
				Console.WriteLine("+ Imminent Danger");
			}
			else if (Health <= 0)
			{
				Health = 0;
				Console.WriteLine("+ Dead");
			}
			else
			{

			}
		}

		void Boarder(float increment)
		{
			if (increment == 1)
			{
				Console.WriteLine("»══════¤══════«");
			}
			else if (increment == 1.5f)
			{
				Console.WriteLine("»═════════¤═════════«");
			}
			else if (increment == 2)
			{
				Console.WriteLine("»════════════¤════════════«");
			}
			else if (increment == 2.5f)
			{
				Console.WriteLine("»═══════════════¤═══════════════«");
			}
			else if (increment == 3)
			{
				Console.WriteLine("»══════════════════¤══════════════════«");
			}
			else
			{

			}
		}

		public void ShowHUD()
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Boarder(2.5f);

			Console.ForegroundColor = ConsoleColor.Magenta;

			Console.WriteLine($"§\tPlayer\t§");

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Console.WriteLine("---------------------------------");

			//add more stuff
			Console.WriteLine("» Shield: " + Shield);
			Console.WriteLine("» Health: " + Health);
			Console.WriteLine("» Lives: " + Lives);

			Console.WriteLine("---------------------------------");

			Console.ForegroundColor = ConsoleColor.Magenta;

			HealthStatus();

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Boarder(2.5f);

			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine();
		}

	}
}
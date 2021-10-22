using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPI_HealthSystem_API
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

	class Program
	{
		static void Main()
		{
			var Entity = new HealthSystem();

			//Entity.test();

			Entity.test();


			Console.ReadKey(true);
		}
	}


    public class HealthSystem
    {
		int Health;
		int Shield;
		int Lives;

		public int Damage;

		public void test()
        {
            DefaultValues();

            TakeDamage(-120);

            ShowHUD();

            TakeDamage(10);

            ShowHUD();

            TakeDamage(100);

            ShowHUD();

            TakeDamage(50);

            ShowHUD();

            TakeDamage(400);

            ShowHUD();
        }

		/* // old spillover
        int SpillOver(int dmg)
        {
            int spill = dmg - Shield;
            Health -= spill;

            return spill;
        }
		*/

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
				Console.WriteLine("+ Dead");
			}
			else
			{
				return;
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
				return;
			}
		}


		public void DefaultValues()
		{
			Health = 100;
			Shield = 100;
			Lives = 3;
			Damage = 0;
		}

		public void DecLives()
		{
			if (Lives > 0)
			{
				Console.WriteLine("> Revive");
				Health = 100;
				Shield = 100;
			}
			else if (Lives == 0)
			{
				Console.WriteLine("> Game Over");
				return;
			}

		}

		public void TakeDamage(int dmg)
		{
			int spillOver;

			if (dmg < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("<!> Error! Damage = " + dmg + ". Value Must be a positive.");
				Console.ForegroundColor = ConsoleColor.White;

				return;
			}

			if (Shield > 0)
            {
                if (dmg > Shield)
                {
                    Console.WriteLine("b" + dmg);
                    spillOver = dmg - Shield;
                    Health = Health - spillOver;
                    Shield = 0;
                }
                else
                {
                    Console.WriteLine("a" + dmg);
                    Shield -= dmg;
                }
            }
            else
            {
				Console.WriteLine("c" + dmg);
				Health -= dmg;
			}

            if (Health <= 0)
            {
				Health = 0;
                Lives--;
            }
        }

		public void Heal(int hp)
		{
			if (hp < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("<!> Error! Heal = " + hp + ". Value Must be a positive.");
				Console.ForegroundColor = ConsoleColor.White;

				return;
			}

			Health = Health + hp;

			if (Health > 100)
			{
				Health = 100;
			}
		}

		public void RegenShield(int hp)
		{
			if (hp < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("<!> Error! Regen = " + hp + ". Value Must be a positive");
				Console.ForegroundColor = ConsoleColor.White;

				return;
			}

			Shield = Shield + hp;

			if (Shield > 100)
			{
				Shield = 100;
			}
		}

		public void ShowHUD()
		{
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Boarder(2.5f);

			Console.ForegroundColor = ConsoleColor.Magenta;

			Console.WriteLine("§ Player §");

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
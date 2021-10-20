using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPI_HealthSystem_API
{
    class Program
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
		//             > etc...

		static int health; //make a system for health
		static int shield; //make a system for shield
		static int lives; //make a system for lives (""""API""""???)

		static int damage;
		

		static void Main()
        {
			DefultValues();

			ShowHUD();

			TakeDamage(-123333322);

			ShowHUD();


			Console.ReadKey(true);
        }

		static void test(int dmg)
        {
			if (dmg < 0)
			{
				//dmg = 0; // no u
				//Console.WriteLine("error!");
				return;
			}

		}

		static void DefultValues()
        {
			health = 100;
			shield = 100;
			lives = 3;
			damage = 0;
        }

		static void DecLives() //not work?
		{
			if (lives == 0)
			{
				Console.WriteLine("Game Over"); //this does nothing
			}
			else if (lives < 0)
			{
				lives = lives - 1;
				Console.WriteLine("Revive");
				health = 100;
				shield = 100;
			}
			
		}

		static int SpillOver(int dmg,int sp)
        {
			sp = dmg - shield;
			health = health - sp;

			return sp;
        }

		static void TakeDamage(int dmg) // lol fix this
        {
			//yandere dev on the scene!

            if (dmg < 0)
            {
				//dmg = 0; // no u
				Console.WriteLine("error!");
				return;
			}

            else if (shield > 0) //extra mile: instead of putting 0 here. Have a defult min, max value.
            {
				shield = shield - dmg;
            }

			else if (dmg > shield)
            {
				SpillOver(dmg, dmg);
				shield = 0;
            }

			else if (health > 0)
            {
				health = health - dmg;
			}

			else if (health <= 0)
            {
				health = 0;
				DecLives(); // is this broken? T^T
            }
            // or I could have just wrapped all of this ^^^^ in		if (dmg < 0)	but me small brain :D

		}

		static void Heal(int hp)
        {
			if (hp < 0)
			{
				hp = 0; // no u
				Console.WriteLine("error!");
			}

			health = health + hp;

			if (health > 100)
            {
				health = 100;
            }
		}

		static void RegenShield(int hp)
        {
			if (hp < 0)
			{
				hp = 0; // no u
				Console.WriteLine("error!");
			}

			shield = shield + hp;

			if (shield > 100)
            {
				shield = 100;
            }
		}


		static void HealthStatus()
		{
			if (health == 100)
			{
				Console.WriteLine("+ Prefect Health");
			}
			else if (health >= 75)
			{
				Console.WriteLine("+ Healthy");
			}
			else if (health >= 50)
			{
				Console.WriteLine("+ Hurt");
			}
			else if (health >= 10)
			{
				Console.WriteLine("+ Badly hurt");
			}
			else if (health > 0)
			{
				Console.WriteLine("+ Imminent Danger");
			}
			else if (health <= 0)
			{
				health = 0;
				Console.WriteLine("+ Dead");
			}
			else
			{

			}
		}

		static void Boarder(float increment)
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

		static void ShowHUD()
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Boarder(2.5f);

			Console.ForegroundColor = ConsoleColor.Magenta;

			Console.WriteLine($"§\tPlayer\t§");

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Console.WriteLine("---------------------------------");

			//add more stuff
			Console.WriteLine("» Shield: " + shield);
			Console.WriteLine("» Health: " + health);
			Console.WriteLine("» Lives: " + lives);

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
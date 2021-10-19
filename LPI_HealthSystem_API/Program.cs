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

		static int health;
		static int shield;
		static int lives;

		static int damage;
		static int spillOver;

		static void Main(string[] args)
        {
			DefultValues();

			ShowHUD();

			


			Console.ReadKey(true);
        }

		static void DefultValues()
        {
			health = 100;
			shield = 100;
			lives = 3;
			damage = 0;
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

		static void TakeDamage(int dmg) // lol fix this
        {
			if (dmg < 0)
			{
				Console.WriteLine("error!");
			}

			if (shield > 0) //extra mile: instead of putting 0 here. Have a defult min, max value.
            {
				shield = shield - dmg;
            }

			if (dmg > shield)
            {
				spillOver = dmg - shield;
				health = health - spillOver;
				shield = 0;
            }

			if (health > 0)
            {
				health = health - dmg;
			}

			if (health <= 0)
            {
				health = 0;
				DecLives();
            }

		}

		static void Heal(int hp)
        {
			if (hp < 0)
			{
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
				Console.WriteLine("error!");
			}

			shield = shield + hp;

			if (shield > 100)
            {
				shield = 100;
            }
		}

		static void DecLives() //not work?
        {
			lives = lives - 1;
			if (lives == 0)
            {
				Console.WriteLine("Game Over");
            }
		}

		static void ShowHUD()
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Boarder(2.5f);

			Console.ForegroundColor = ConsoleColor.Magenta;

			Console.WriteLine($"§\tDumb Protagonist\t§");

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

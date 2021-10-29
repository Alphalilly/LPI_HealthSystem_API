using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 


namespace LPI_HealthSystem_API
{
	// Health system handles the player health, shield, lives, etc...
	// Variables: Health, Shield, Lives, Spillover, etc...
	// Methods: ShowHUD(), TakeDamage(int damage), Heal(int hp), RegenerateShield(int hp), etc...
	// Take Damage Spill down
	// Unit Testing
	// Test that the code works as intended, Showcasing range and error checking. Simulated gameplay is optional.
	// extra mile ideas:
	//		> evolve it beyond a health system, into a player statistics system. 
	//      > experience points + level-up system
	//		> weapon system
	//      > create your own variables, create your own methods.
	//      > create sub-methods
	//	    > instead of putting 0 everywhere. Have a defult min, max value.
	//      > etc...

	class Program
	{
		static void Main()
		{
			var Entity = new HealthSystem();

			Entity.Dubug();

			Console.ReadKey(true);
		}
	}

    public class HealthSystem
    {
		int Health;
		int Shield;
		int Lives;

		public int Damage;

		public void Dubug()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Debug Mode <?>");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(" ");

			// ---------------------------------------------------------------------------------------------
			// Tests if the default values have been set correctly

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing DefaultValues() ... ");
			Console.ForegroundColor = ConsoleColor.White;

			DefaultValues();
			Debug.Assert(Health == 100, "You can put strings in here", "they dont do anything."); // Debug
			Debug.Assert(Shield == 100);
			Debug.Assert(Lives == 3);
			Debug.Assert(Damage == 0);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests if the ShowHUD() displays correctly

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing ShowHUD() ... ");
			Console.ForegroundColor = ConsoleColor.White;

			ShowHUD();

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the TakeDamage() handles negative values correctly

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing TakeDamage() Clamping ... "); // clamping is probably not the right word.
			Console.ForegroundColor = ConsoleColor.White;

			Damage = -10; 
			TakeDamage(Damage); 
			Debug.Assert(Health == 100); 
			Debug.Assert(Shield == 100); 
			Debug.Assert(Lives == 3);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the TakeDamage() Damages Shield

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing TakeDamage() on Shield ..."); 
			Console.ForegroundColor = ConsoleColor.White;

			Damage = 60;
			TakeDamage(Damage);
			Debug.Assert(Shield < 100);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the RegenShield() handles negative values correctly

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing RegenShield() Clamping ..."); // clamping is probably not the right word
			Console.ForegroundColor = ConsoleColor.White;

			RegenShield(-20);
			Debug.Assert(Shield < 100);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the RegenShield() applies regen to Shield, and tests Clamping

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing RegenShield() on Shield, and Clamping ...");
			Console.ForegroundColor = ConsoleColor.White;

			RegenShield(100);
			Debug.Assert(Shield <= 100);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests That the TakeDamage() handles Damage spillover into health

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing TakeDamage() Spillover ...");
			Console.ForegroundColor = ConsoleColor.White;

			Damage = 120;
			TakeDamage(Damage);
			Debug.Assert(Shield == 0);
			Debug.Assert(Health < 100);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the Heal() handles negative values correctly

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing Heal() Clamping ..."); // clamping is probably not the right word
			Console.ForegroundColor = ConsoleColor.White;

			Heal(-30);
			Debug.Assert(Health == Health);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the Heal() applies hp to Health, and tests Clamping

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing Heal() on Health, and Clamping ...");
			Console.ForegroundColor = ConsoleColor.White;

			Heal(30);
			Debug.Assert(Health > 80);
			Debug.Assert(Health >= 100);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the TakeDamage() Damages Health, and clamps the value.

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing TakeDamage() on Health, and clamping ...");
			Console.ForegroundColor = ConsoleColor.White;

			Damage = 120;
			TakeDamage(Damage);
			Debug.Assert(Health <= 0);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------


			// ---------------------------------------------------------------------------------------------
			// Tests that the Revive() decriments Lives and sets Health and Shield back to max

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing Revive() ...");
			Console.ForegroundColor = ConsoleColor.White;

			Revive();
			Debug.Assert(Lives < 3);
			Debug.Assert(Health == 100);
			Debug.Assert(Shield == 100);


			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------



			// ---------------------------------------------------------------------------------------------
			// Tests that the Revive() Displays a "Game Over" when Lives are depleated

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Testing Revive() Game Over ...");
			Console.ForegroundColor = ConsoleColor.White;

			Damage = 200;
			TakeDamage(Damage);
			Revive();
			TakeDamage(Damage);
			Revive();
			TakeDamage(Damage);
			Revive();

			Debug.Assert(Lives == 0);
			Debug.Assert(Health == 0);
			Debug.Assert(Shield == 0);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> Test Successful!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			// ---------------------------------------------------------------------------------------------

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("<?> End of Test <?>");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(" ");
		}

		public void DefaultValues()
		{

			Console.WriteLine("<;> Defult Values set.");

			Health = 100;
			Shield = 100;
			Lives = 3;
			Damage = 0;
		}

		public void Revive()
		{
			if (Lives <= 0)
			{
				Lives = 0;
				Console.WriteLine("> Game Over");
				return;
			}
			if (Lives > 0)
			{
				Lives--;
				Console.WriteLine("> Revive");
				Health = 100;
				Shield = 100;
			}

		}

		public void TakeDamage(int dmg)
		{
			int spillOver;

			if (dmg < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("<!> Error! Damage = " + dmg + ". Value Must be positive.");
				Console.ForegroundColor = ConsoleColor.White;

				return;
			}

			if (Shield > 0)
            {
                if (dmg > Shield)
                {
                    Console.WriteLine("> Player is dealt " + dmg + " Damage! The difference spills over into health");
                    spillOver = dmg - Shield;
                    Health -= spillOver;
                    Shield = 0;
                }
                else
                {
					Console.WriteLine("> Player is dealt " + dmg + " Damage!");

					Shield -= dmg;
                }
            }
            else
            {
				Console.WriteLine("> Player is dealt " + dmg + " Damage!");

				Health -= dmg;
			}

            if (Health <= 0)
            {
				Health = 0;
				Console.WriteLine("> Health is clamped at " + Health);
			}
		}

		public void Heal(int hp)
		{
			if (hp < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("<!> Error! Heal = " + hp + ". Value Must be positive.");
				Console.ForegroundColor = ConsoleColor.White;

				return;
			}

			Console.WriteLine("> Player Heals " + hp + " Health!");

			Health = Health + hp;

			if (Health > 100)
			{
				Health = 100;
				Console.WriteLine("> Player Health is clamped at " + Health);
			}
		}

		public void RegenShield(int hp)
		{
			if (hp < 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("<!> Error! Regen = " + hp + ". Value Must be positive");
				Console.ForegroundColor = ConsoleColor.White;

				return;
			}

			Console.WriteLine("> Player Regenerates " + hp + " Sheild!");

			Shield = Shield + hp;

			if (Shield > 100)
			{
				Shield = 100;
				Console.WriteLine("> Player Shield is clamped at " + Shield);
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
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("»");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("══════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("¤");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("══════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("«");
				Console.ForegroundColor = ConsoleColor.DarkCyan;

			}
			else if (increment == 1.5f)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("»");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("═════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("¤");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("═════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("«");
				Console.ForegroundColor = ConsoleColor.DarkCyan;

			}
			else if (increment == 2)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("»");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("════════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("¤");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("════════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("«");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
			}
			else if (increment == 2.5f)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("»");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("═══════════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("¤");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("═══════════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("«");
				Console.ForegroundColor = ConsoleColor.DarkCyan;


			}
			else if (increment == 3)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("»");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("══════════════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("¤");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("══════════════════");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("«");
				Console.ForegroundColor = ConsoleColor.DarkCyan;

			}
			else
			{
				return;
			}
		}

		public void ShowHUD()
		{
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Boarder(2.5f);

			Console.ForegroundColor = ConsoleColor.Magenta;

			Console.WriteLine("\t   § Player §");

			Console.ForegroundColor = ConsoleColor.DarkCyan;

			Console.WriteLine("---------------------------------");

			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine("» Shield: " + Shield);
			Console.WriteLine("» Health: " + Health);
			Console.WriteLine("» Lives: " + Lives);

			Console.ForegroundColor = ConsoleColor.DarkCyan;

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

/* Old Debug
		public void Dubug()
        {
			DefaultValues();

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Damage = -10;

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Damage = 10;

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Damage = 50;

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			RegenShield(-20);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			RegenShield(100);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Damage = 120;

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Heal(-30);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Heal(30);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Damage = 120;

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Revive();

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Damage = 200;

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Revive();

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			TakeDamage(Damage);

			ShowHUD();

			Console.ReadKey(true);

			Revive();

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			TakeDamage(Damage);

			Console.ReadKey(true);

			ShowHUD();

			Console.ReadKey(true);

			Revive();

			Console.ReadKey(true);
		}
		*/

/* // old spillover
int SpillOver(int dmg)
{
	int spill = dmg - Shield;
	Health -= spill;

	return spill;
}
*/
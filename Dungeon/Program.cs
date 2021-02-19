using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienAppLibrary;
using SpecialEnemyLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Alien: Containment";
            int score = 0;
            bool exitGame = false;
            bool enemyHasBeenFought = false;
            bool isContainmentClear = false;

            Console.WriteLine("Welcome to my game, and thank you for playing!\nAlien: Containment is created to be a unique experience every time you play. You never know when you're going to meet an enemy, or who it will be.\nYour goal is to reach the cargo bay and survive long enough to kill the alien once and for all.\nEnjoy!\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Weapon flamethrower = new Weapon("Flamethrower", 20, 30, 15);
            Weapon pistol = new Weapon("Pistol", 10, 20, 2);
            Player player = new Player(100, 100, 25, 50, 20, pistol, "You", score);
            bool isXenoQueen = new Random().Next(1, 11) <= 5 ? true : false;
            BossXeno boss = new BossXeno(110, 110, 30, 30, 20, 15, 25, "It towers over you as you fight the urge to scream. It's smooth black body slithers and twitches.\nHere it comes.", "xenomorph", isXenoQueen);

            Console.WriteLine("You start awake, trying to catch your breath, which seems just out of reach.\n" +
                "Alarms are blaring, lights strobing all around you. You only take a moment to ground yourself and remember where you are,\nand to realize what must have happened.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("It's out.");
            Console.ReadKey();
            Console.Clear();

            #region Logo
            Console.WriteLine(@"
              *    .  *       .             * *    .  *       .             *
                                     * *   .        *       .       .       
             *   .        *       .       .       *
               .     *
                       .     .  *        *             .  *           *                     
                   .                .        .
            .  *           *                     *
                                         .                   .   *        
              ___  _ *          .   *                                                  
             / _ \| (_)                                                                           
            / /_\ \ |_  ___ _ __    *    .  *       .             *                         
            |  _  | | |/ _ \ '_ \  ()                      *                                  
            | | | | | |  __/ | | |    *   .        *       .       .       *
            \_| |_/_|_|\___|_| |_| ().     *                                                              
                       .     .  *        *           .     .  *        *
            .  *           *                     *.  *           *                                        
             _____   *   .   * _        _                            _   
            /  __ \  .     *  | |      (_) *   .     *     .       *| |  
            | /  \/ ___  _ __ | |_ __ _ _ _ __  _ __ ___   ___ _ __ | |_ 
            | |    / _ \| '_ \| __/ _` | | '_ \| '_ ` _ \ / _ \ '_ \| __|
            | \__/\ (_) | | | | || (_| | | | | | | | | | |  __/ | | | |_ 
             \____/\___/|_| |_|\__\__,_|_|_| |_|_| |_| |_|\___|_| |_|\__|
              *    .  *       .             *          *          .   *
                                     *
             *   .        *       .       .       * .  *           *                     
               .     *
                       .     .  *        *        .                .        .
                   .                .        .
            .  *           *                     *
                                         .              *          .   *
                     *          .   *
            ");
            #endregion

            do
            {
                #region Rooms
                Room start = new Room("Women's CryoSleep Quarters", "There are cryosleep chambers all around you. They were supposed to be holding your crewmembers, but they aren't there. There's blood on one of the chambers. You check the ship's stats as you throw on a pair of sweats and a shirt that you had set out for yourself before you went to sleep.\nYou stop in your steps as you read the logs. That can't be right... but somehow you know it is.\nThe escape pods are gone - all except one.\nThat's where you have to go. Your gun is on the table next to you.\nTime to see what it can do.", true);
                Room storage = new Room("Storage Room", "The storage room is a dead end, but you didn't come here to hide. You look around for anything that might help you a little bit more than this measly pistol they issued you. Your eyes scan the room as you quickly shuffle through the content scattered on the shelves when something catches your eye -- a flamethrower in the corner.", false);
                Room common = new Room("Common Area", "So many fond memories. You find it surprisingly difficult not to reminisce even amidst all of the madness unfolding around you. This room is where some of your fondest memories have come from -- laughing like fools, fighting like even bigger fools. The entire crew is the only family you have. You push the thoughts down and press forward.\nIt feels like every sound is amplified by a thousand. Every noise you make, you are hyper-aware of. You hope it's just the adrenaline pumping through you, but you can't help but feel like you're being watched.", false);
                Room bathroom = new Room("Bathrooms", "There is more blood streaking the floor, leading from the shower. You wonder if someone was taking a shower when they got attacked, or if it was their only place to hide. If it was, you suppose it wasn't good enough.", false);
                Room mensQuarters = new Room("Men's Quarters Hall", "You have to see if anyone might still be alive still be here. You try as hard as you can to manually open the doors, but you aren't strong enough, and your keycard won't work for the men's quarters.", false);
                Room messHall = new Room("Mess Hall", "There has clearly been a struggle here. Empty trays clutter the floor and the salt and pepper are still rolling from their fall. Whoever was here isn't far.", false);
                Room kitchen = new Room("Kitchen", "The top half of one of the ship's androids is slouched in the corner, white liquid slithering its way across the floor. It's still twitching every now and then, but it's clear that it's inoperable. Whatever did that, you don't want to be around to meet it.", false);
                Room observationRoom = new Room("Observation Room", "You enter the room with extreme caution. It's dark, lit intermittently only by the strobing emergency lights.", false);
                Room containment = new Room("Containment Room", "You shiver as you enter. You shouldn't be here. There are eggs all around, at least a dozen. They start to open, all at once, giving birth to whatever has been growing inside of them...", false);
                Room cargoBay = new Room("Cargo Bay", "Here is where you will face the xenomorph and either capture it for study or kill it", false); 
                #endregion
                Console.ReadKey();
                Console.Clear();
                Console.Title = "Women's Quarters";
                Console.WriteLine(start);
                Console.ReadKey();
                do
                {

                    #region Starting Room
                    while (start.IsCurrentRoom == true)
                    {
                        Console.Title = "Women's Quarters";
                        Console.Clear();
                        Console.WriteLine("The women's quarters exit into a hallway.\n" +
                            "1. Check storage room for supplies\n" +
                            "2. Enter common area\n" +
                            "3. Enter bathroom\n" +
                            "4. HUD\n" +
                            "5. Map\n" +
                            "6. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                storage.IsCurrentRoom = true;
                                start.IsCurrentRoom = false;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                common.IsCurrentRoom = true;
                                start.IsCurrentRoom = false;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                bathroom.IsCurrentRoom = true;
                                start.IsCurrentRoom = false;
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.startingPoint);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:

                                        start.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end start

                    #endregion

                    #region storage room
                    while (storage.IsCurrentRoom == true)
                    {
                        Console.Title = "Storage Room";
                        #region combat

                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine($"{(player.EquippedWeapon == flamethrower ? $"{storage}\n1. Take flamethrower (already equipped)\n2. Go back to women's quarters\n3. HUD\n4. Map\n5. Exit" : $"{storage}\n1. Take flamethrower\n2. Go back to women's quarters\n3. HUD\n4. Map\n5. Exit")}");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.Clear();
                                Console.WriteLine($"{(player.EquippedWeapon == flamethrower ? "You already have the flamethrower." : "You picked up the flamethrower.")}");
                                player.EquippedWeapon = flamethrower;
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                storage.IsCurrentRoom = false;
                                start.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.storageRoom);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        storage.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end storage 
                    #endregion

                    enemyHasBeenFought = false;

                    #region Common Room
                    while (common.IsCurrentRoom == true)
                    {
                        Console.Title = "Common Area";
                        #region combat
                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine($"{common}\n" +
                            $"1. Enter mess hall\n" +
                            $"2. Enter men's quarters\n" +
                            $"3. Go back to women's quarters\n" +
                            $"4. HUD\n" +
                            $"5. Map\n" +
                            $"6. Exit");

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.Clear();
                                Console.WriteLine("You try to exit the the common area, but the door that leads that way is jammed.");
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.Clear();
                                Console.WriteLine("You try to exit the the common area, but the door that leads that way is jammed.");
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                common.IsCurrentRoom = false;
                                start.IsCurrentRoom = true;
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.commonArea);
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:

                                        common.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end Common Area 
                    #endregion

                    enemyHasBeenFought = false;

                    #region Bathroom
                    while (bathroom.IsCurrentRoom == true)
                    {
                        Console.Title = "Bathroom";
                        #region combat
                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine($"{bathroom}\n" +
                            $"1. Enter men's quarters\n" +
                            $"2. Enter common area\n" +
                            $"3. Enter mess hall\n" +
                            $"4. Go back to women's quarters\n" +
                            $"5. HUD\n" +
                            $"6. Map\n" +
                            $"7. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                bathroom.IsCurrentRoom = false;
                                mensQuarters.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.Clear();
                                Console.WriteLine("You try to open the common area door, but something is jamming the mechanism. You try to force it, but it's no use.");
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                bathroom.IsCurrentRoom = false;
                                messHall.IsCurrentRoom = true;
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                bathroom.IsCurrentRoom = false;
                                start.IsCurrentRoom = true;
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.bathroom);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        bathroom.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end bathroom 
                    #endregion

                    enemyHasBeenFought = false;

                    #region Mens Quarters
                    while (mensQuarters.IsCurrentRoom == true)
                    {
                        Console.Title = "Men's Quarters";
                        #region combat
                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine($"{mensQuarters}\n" +
                            $"1. Enter common area\n" +
                            $"2. Enter mess hall\n" +
                            $"3. Go back to bathroom\n" +
                            $"4. HUD\n" +
                            $"5. Map\n" +
                            $"6. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.Clear();
                                Console.WriteLine("You try to open the common area door, but something is jamming the mechanism. You try to force it, but it's no use.");
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                mensQuarters.IsCurrentRoom = false;
                                messHall.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                mensQuarters.IsCurrentRoom = false;
                                bathroom.IsCurrentRoom = true;
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.mensQuartersHall);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        mensQuarters.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end Mens Quarters 
                    #endregion

                    enemyHasBeenFought = false;

                    #region Mess Hall
                    while (messHall.IsCurrentRoom == true)
                    {
                        Console.Title = "Mess Hall";
                        #region combat
                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine($"{messHall}\n" +
                            $"1. Enter observation room\n" +
                            $"2. Enter kitchen\n" +
                            $"3. Go back to mens quarters\n" +
                            $"4. Go back to bathroom\n" +
                            $"5. HUD\n" +
                            $"6. Map\n" +
                            $"7. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                messHall.IsCurrentRoom = false;
                                observationRoom.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                messHall.IsCurrentRoom = false;
                                kitchen.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                messHall.IsCurrentRoom = false;
                                mensQuarters.IsCurrentRoom = true;
                                break;

                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                messHall.IsCurrentRoom = false;
                                bathroom.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.messHall);
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        messHall.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }//end exit switch
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end Mess Hall 
                    #endregion

                    enemyHasBeenFought = false;

                    #region Kitchen
                    while (kitchen.IsCurrentRoom == true)
                    {
                        Console.Title = "Kitchen";
                        #region combat
                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine($"{kitchen}\n" +
                            $"1. Enter cargo bay\n" +
                            $"2. Go back to mess hall\n" +
                            $"3. HUD\n" +
                            $"4. Map\n" +
                            $"5. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                kitchen.IsCurrentRoom = false;
                                cargoBay.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                kitchen.IsCurrentRoom = false;
                                messHall.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.kitchen);
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        kitchen.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end Kitchen 
                    #endregion

                    enemyHasBeenFought = false;

                    #region Observation Room
                    while (observationRoom.IsCurrentRoom == true)
                    {

                        Console.Title = "Observation Room";
                        #region combat
                        Enemy currentE = EnemyGenerator.GetEnemy();

                        if (currentE == null || enemyHasBeenFought == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no one here.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            enemyHasBeenFought = true;

                        }
                        else if (enemyHasBeenFought == false)
                        {
                            bool isFinished = false;
                            enemyHasBeenFought = true;
                            Console.Clear();
                            Console.WriteLine($"{(currentE.Name == "android" ? "An " : "A ")}{currentE.Name} lunges towards you!");
                            do
                            {
                                Console.WriteLine("1. Attack\n" +
                                    "2. HUD\n" +
                                    "3. Enemy stats");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        Combat.Battle(player, currentE);
                                        if (currentE.Name == "xenomorph" && currentE.Life < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} turns around and runs out of the room. It's injured, but it's not going to die. Not yet.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            isFinished = true;
                                        }
                                        else if (currentE.Life < 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine($"The {currentE.Name} is dead.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            enemyHasBeenFought = true;
                                            isFinished = true;
                                            score++;
                                        }
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        Console.WriteLine(player);
                                        break;
                                    case ConsoleKey.NumPad3:
                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        Console.WriteLine(currentE);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("You can't do that right now!");
                                        break;
                                }
                                if (player.Life < 1)
                                {
                                    Console.WriteLine($"You died by the {currentE.Name}.\n");
                                    exitGame = true;
                                }
                            } while (isFinished != true);
                        }
                        #endregion
                        Console.WriteLine(observationRoom);
                        Console.Write($"{(player.Life < player.MaxLife ? "You need to get patched up. You see an emergency kit on one of the desks.\nH. Heal\n" : "")}");
                        Console.WriteLine($"1. Enter containment room\n" +
                            $"2. Go back to mess hall\n" +
                            $"3. HUD\n" +
                            $"4. Map\n" +
                            $"5. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.H:
                                player.Life = player.MaxLife;
                                Console.WriteLine("Your health has increased to max.");
                                break;
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                observationRoom.IsCurrentRoom = false;
                                containment.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                observationRoom.IsCurrentRoom = false;
                                messHall.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.observationRoom);
                                Console.ReadKey();
                                break;

                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        observationRoom.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }//end Observation Room 
                    #endregion

                    #region Containment
                    while (containment.IsCurrentRoom == true)
                    {

                        Console.Title = "Containment Room";
                        Console.Clear();
                        if (player.EquippedWeapon == flamethrower && isContainmentClear == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"{containment}\nYou turn the flamethrower on the eggs, burning them all to ash before the creatures can escape from them. There's a loud screech, a sizzle, silence.\nThat's one less thing for you to deal with.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            isContainmentClear = true;
                            score += 12;
                        }
                        if (player.EquippedWeapon != flamethrower && isContainmentClear == false)
                        {
                            Console.WriteLine("The facehuggers all burst from their eggs and attack you. There is no time for escape, and your pistol is useless against them.");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You are dead.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.ReadKey();
                            exitGame = true;
                            containment.IsCurrentRoom = false;
                            continue;

                        }
                        else if (isContainmentClear == true)
                        {
                            Console.WriteLine("The charred remains of the eggs are all that is left in this room.");
                        }

                        Console.WriteLine($"1. Go back to observation room\n" +
                            $"2. HUD\n" +
                            $"3. Map\n" +
                            $"4. Exit");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                containment.IsCurrentRoom = false;
                                observationRoom.IsCurrentRoom = true;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.Clear();
                                Console.WriteLine(player);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.Clear();
                                PlayerMaps.Map(MapRoom.containmentRoom);
                                Console.ReadKey();
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                Console.WriteLine("If you exit, all progress will be lost. Are you sure?\n1. Yes\n2. No");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.NumPad1:
                                    case ConsoleKey.D1:
                                        containment.IsCurrentRoom = false;
                                        exitGame = true;
                                        break;

                                    case ConsoleKey.NumPad2:
                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.Clear();
                                        break;
                                }
                                break;

                            default:
                                Console.Clear();
                                break;
                        }//end switch
                    }
                    #endregion

                    enemyHasBeenFought = false;

                    #region Cargo Bay
                    while (cargoBay.IsCurrentRoom == true)
                    {
                        Console.Title = "Cargo Bay";
                        Console.Clear();
                        bool isFinished = false;
                        Console.Clear();
                        Console.WriteLine($"The {boss.Name} lunges towards you!");
                        do
                        {
                            Console.WriteLine("1. Attack\n" +
                                "2. HUD\n" +
                                "3. Enemy stats");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Combat.Battle(player, boss);
                                    if (boss.Life < 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine($"The {boss.Name} is dead.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        isFinished = true;
                                        cargoBay.IsCurrentRoom = false;
                                        score++;
                                    }
                                    break;

                                case ConsoleKey.NumPad2:
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Console.WriteLine(player);
                                    break;

                                case ConsoleKey.NumPad3:
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    Console.WriteLine(boss);
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("You can't do that right now!");
                                    break;
                            }
                            if (player.Life < 1)
                            {
                                Console.WriteLine($"You died by the {boss.Name}.\n");
                                exitGame = true;
                            }
                        } while (isFinished != true);

                        Console.WriteLine($"It's over. You rush to the last escape pod, get in, and leave.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You survived.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ReadKey();
                        cargoBay.IsCurrentRoom = false;
                        exitGame = true;
                    }
                    #endregion
                    
                } while (start.IsCurrentRoom == true || storage.IsCurrentRoom == true || common.IsCurrentRoom == true || bathroom.IsCurrentRoom == true || mensQuarters.IsCurrentRoom == true || messHall.IsCurrentRoom == true || kitchen.IsCurrentRoom == true || observationRoom.IsCurrentRoom == true || containment.IsCurrentRoom == true || cargoBay.IsCurrentRoom == true);//end while rooms true
            } while (exitGame != true);
            Console.Clear();
            Console.WriteLine($"Your final killcount is: {score}\nThank you for playing!");
        }//end Main()
    }//end class
}//end namespace

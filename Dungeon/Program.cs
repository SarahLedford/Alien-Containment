using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienAppLibrary;


namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitGame = false;

            Console.WriteLine("Welcome to my game, and thank you for playing!\nAlien: Containment is created to be a unique experience every time you play. You never know when you're going to meet an enemy, or who it will be.\nYour goal is to survive long enough to initiate the security protocols to recapture the xenomorph or to kill it once and for all. The choice will be yours.\nEnjoy!\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("You start awake, trying to catch your breath, which seems just out of reach.\n" +
                "Alarms are blaring, lights strobing all around you. It only takes a moment to ground yourself and remember where you are, and to realize what must have happened.");
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
|  _  | | |/ _ \ '_ \                           *                                  
| | | | | |  __/ | | |*   .        *       .       .       *
\_| |_/_|_|\___|_| |_|   .     *                                                              
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
                Room start = new Room("Women's CryoSleep Quarters", "There are cryosleep chambers all around you. They were supposed to be holding your crewmembers, but they aren't there. There's blood on one of the chambers. You throw on a pair of sweats and a shirt that you had set out for yourself before you went to sleep. Your gun is there also.\nTime to see what it can do.", true);
                Room storage = new Room("Storage Room", "It's a storage room. What'd yah expect?", false);
                Room common = new Room("Common Area", "So many fond memories. You find it surprisingly difficult not to reminisce even amidst all of the madness unfolding around you. This room is where some of your fondest memories have come from -- laughing like fools, fighting like even bigger fools. The entire crew is the only family you have. You push the thoughts down and press forward.\nIt feels like every sound is amplified by a thousand. Every noise you make, you are hyper-aware of. You hope it's just the adrenaline pumping through you, but you can't help but feel like you're being watched.", false);
                Room bathroom = new Room("Bathrooms", "There is more blood streaking the floor, leading from the shower. You wonder if someone was taking a shower when they got attacked, or if it was their only place to hide. If it was, you suppose it wasn't good enough.", false);
                Room mensQuarters = new Room("Men's Quarters Hall", "You have to see if anyone might still be alive. The Company doesn't want to deal with any pregnancy complications on these long missions, so they make sure only men can get into the men's quarters and vice versa. You try as hard as you can to manually open the doors, but something's blocking it from the inside.", false);
                Room messHall = new Room("Mess Hall", "There has clearly been a struggle here. Empty trays clutter the floor and the salt and pepper are still rolling from their fall. Whoever was here isn't far.", false);
                Room kitchen = new Room("Kitchen", "The top half of one of the ship's androids is slouched in the corner, white liquid slithering its way across the floor. It's still twitching every now and then, but it's clear that there's nothing left of it. Whatever did that, you don't want to be around to meet it, though you already know what did it.\nYou search the room for any knives or other helpful tools that you could take with you as an extra precaution. You curse to yourself as you come up empty-handed, cursing the androids that usually make the meals. There's no way of telling where they kept them, but you were sure you had seen some knives here before. Where would they have taken them?", false);
                Room observationRoom = new Room("Observation Room", "You enter the room with extreme caution. It's dark, lit intermittently only by the strobing emergency lights. Your hand flies up to your mouth as you try to suppress a scream, throwing up, maybe both.\nYou aren't alone here. Your crewmates lie slumped, bloodied, and lifeless all around you. The creature brought them all back here. It didn't try to incubate them, but instead killed them and left them here to rot. It seemed symbolic, as if it was telling them to observe the last act they would ever see it do.\nThe studies were over.", false);
                Room containment = new Room("Containment Room", "You shiver as you enter. You shouldn't be here. No one should have been there. There are eggs all around. You won't survive if you didn't pick up the flamethrower in the other room", false);//TODO finish containment room description properly
                Room cargoBay = new Room("Cargo Bay", "Here is where you will face the xenomorph and either capture it for study or kill it", false);//TODO finish Cargo Bay description
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(start);
                Console.ReadKey();

                #region Starting Room
                while (start.IsCurrentRoom == true)
                {

                    Console.Clear();
                    Console.WriteLine("You head exit the women's quarters into a hallway.\n" +
                        "1. Check storage room for supplies\n" +
                        "2. Enter common area\n" +
                        "3. Enter bathroom\n" +
                        "4. Map\n" +
                        "5. Exit Game");
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
                            PlayerMaps.Map(MapRoom.startingPoint);
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Console.Clear();
                            Console.WriteLine("If you exit, all progress will be lost. Are you sure?\nY/N");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.Y:
                                    Console.Clear();
                                    Console.WriteLine("You are now exiting the game. Thank you for playing!");
                                    start.IsCurrentRoom = false;
                                    exitGame = true;
                                    break;

                                case ConsoleKey.N:
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
                    Console.Clear();
                    Console.WriteLine(storage);
                }//end storage 
                #endregion

                #region Common Room
                while (common.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(common);
                }//end Common Area 
                #endregion

                #region Bathroom
                while (bathroom.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(bathroom);
                }//end bathroom 
                #endregion

                #region Mens Quarters
                while (mensQuarters.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(mensQuarters);
                }//end Mens Quarters 
                #endregion

                #region Mess Hall
                while (messHall.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(messHall);
                }//end Mess Hall 
                #endregion

                #region Kitchen
                while (kitchen.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(kitchen);
                }//end Kitchen 
                #endregion

                #region Observation Room
                while (observationRoom.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(observationRoom);
                }//end Observation Room 
                #endregion

                #region Containment
                while (containment.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(containment);
                }
                #endregion

                #region Cargo Bay
                while (cargoBay.IsCurrentRoom == true)
                {
                    Console.Clear();
                    Console.WriteLine(cargoBay);
                } 
                #endregion

            } while (exitGame != true);
        }
    }
}

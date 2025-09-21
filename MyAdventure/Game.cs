

namespace MyAdventure
{

    //DU BEHÖVER INTE KALLA PÅ PLAYER SOM REDAN FINNS I KLASSEN!
    public class Game
    {
        public Player player;
        public string[] enemies = { "Mordor", "Isradil", "Aragon", "Red" };
        private Random random = new Random();


        public void Start()
        {
            Console.WriteLine("Enter your name, if you dare to begin your adventure. BE AWARE, THERE IS NO TURNING BACK FROM THIS POINT!! ");
            string name = Console.ReadLine();

            Console.WriteLine($"WELCOME: {name} : indeed you are of the brave ones. \nChoose a class: \n[1] Warrior \n[2] Mage");
            string choice = Console.ReadLine();
            string classChoice = choice == "1" ? "Warrior" : "Mage";

            player = new Player(name, classChoice);
            Console.Clear();

            Console.WriteLine($"Welcome {name} the legendary {classChoice} to an adventure of a lifetime, be prepared to fight. Enemy shows no mercy!!");
            MainMenu();
        }

        public void MainMenu()
        {

            while (player.IsAlive())
            {

                Console.WriteLine("\n --- Main Menu ---");
                Console.WriteLine("1. Start Adventure\n2. Rest \n3. Player Stats \n4 Exit the game");
                string input = Console.ReadLine();
                Console.Clear();

                if (input == "1")
                {
                    StartAdventure();
                    if (!player.IsAlive())
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER Newb!");
                        break;
                    }
                }
                else if (input == "2")
                {
                    int healAmount = 20;
                    player.Heal(healAmount);
                    Console.WriteLine($"You {player.name} have healed {healAmount}. Your health is now {player.hp}/{player.maxHp}");
                }
                else if (input == "3")
                {
                    player.ShowStatus();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Thanks for playing, better luck next time");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
        }


        public void StartAdventure()
        {
            string enemyName = enemies[random.Next(enemies.Length)];
            int hp = random.Next(20, 50);
            int damage = random.Next(5, 15);
            int goldTaken = random.Next(15, 30);
            Enemy enemy = new Enemy(enemyName, hp, damage, goldTaken);

            Combat(enemy);
        }

        // En loop för strider (fortsätter tills fienden eller spelaren har 0 HP)
        //Metod som hanterar spelarens tur,
        //Metod som hanterar fiendens tur.
        public void Combat(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"Enemy has blocked your path, {player.name} you must defeat {enemy.name} to clear the path with your life intact!!");

            while (true)
            {
                //Spelarens tur
                string? move = PlayerMove(enemy);
                if (move == null)
                {
                    // Din jävla fegis, du flydde
                    Console.WriteLine("COWARD!!!");
                    return;
                }
                
                if (enemy.IsAlive() == false)
                {
                    Console.WriteLine($"{enemy.name} is dead and you can continue {player.name} ");
                    int goldDropped = enemy.goldTaken;
                    player.gold += goldDropped;
                    Console.WriteLine($"You looted {goldDropped} gold from the enemy, you now have {player.gold} gold");
                    break;
                }

                // Fiendens tur
                player.TakeDamage(enemy.damage);
                Console.WriteLine($"{enemy.name} attacks you {player.name}. {enemy.name} dealt you {enemy.damage} damage, your HP is now {player.hp}/{player.maxHp}");
                if (player.IsAlive() == false)
                {
                    Console.WriteLine($"{enemy.name} has slained you adventurer: \n1.Start Over \n2.MainMenu");
                    break;
                }
            }
        }

        public string? PlayerMove(Enemy enemy)
        {
            Console.WriteLine("Choose your next move:\n1. Attack \n2. Heal \n3. Flee");

            while (true) {
                string choice = Console.ReadLine().ToLower();
                if (choice == "1")
                {
                    enemy.DamageTaken(player.damage);
                    Console.WriteLine($"You attacked {enemy.name} for {player.damage} damage. {enemy.name} hp is now {enemy.hp}/{enemy.maxHp}");
                    return "Attack";
                }
                else if (choice == "2")
                {
                    int healAmount = 20;
                    player.Heal(healAmount);
                    Console.WriteLine($"Death was almost embracing you {player.name}, you are now regaining hp: {player.hp}/{player.maxHp}");
                    return "Heal";

                }
                else if (choice == "3")
                {
                    Console.WriteLine("You have taken the cowards way out, RUN FOR YOUR LIFE COWARD");
                    return null;
                }
                else
                {
                    Console.WriteLine("That is not a valid move, try again!");
                }
            }
        }
    }
}

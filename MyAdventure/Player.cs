namespace MyAdventure
{
   public class Player
    {
        public string name;
        public string playerClass;
        public int hp;
        public int maxHp;
        public int damage;
        public int gold;
        public int rage;
        public int mana;

        public Player(string name, string myClass)
        {
            this.name = name;
            playerClass = myClass;

            if (myClass == "Warrior")
            {
                hp = 100;
                maxHp = 100;
                damage = 20;
                gold = 50;
                rage = 20;
            } 
            else
            {
                hp = 100;
                maxHp = 100;
                damage = 20;
                mana = 30;
                gold = 50;
            }
        }
        public void Heal(int amount)
        {
            if (amount <= 0) return;


            hp += amount;
            if (hp > maxHp)
            {
                hp = maxHp;
            }
        }
        public void TakeDamage(int amount)
        {
            hp -= amount;
            if(hp < 0)
            {
                hp = 0;
            }
        }

        public int DropGold()
        {
            int loot = gold;
            gold = 15;
            return loot;
        }

        public bool IsAlive()
        {
            return hp > 0;
        }
        public void ShowStatus()
        {
            Console.WriteLine("\n=== Status ===");
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Class:" + playerClass);
            Console.WriteLine("HP:" + hp + "/" + maxHp);
            Console.WriteLine("Damage:" + damage);
            Console.WriteLine("Gold:" + gold);


        }
    }
}

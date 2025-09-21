

namespace MyAdventure
{
    public class Enemy
    {
        public string name;
        public int hp;
        public int maxHp;
        public int damage;
        public int goldTaken;

        public Enemy(string nameEnemey, int hp, int damage, int goldTaken)
        {

            name = nameEnemey;
            this.hp = hp;
            maxHp = hp;
            this.damage = damage;
            this.goldTaken = goldTaken;
        }

        public void DamageTaken(int amount)
        {
            hp -= amount;
            if (hp < 0)
            {
                hp = 0;
            }
        }

        public bool IsAlive()
        {
            return hp > 0;
        }
        public int DropGold()
        {
            int loot = goldTaken;
           goldTaken = 15;
            return loot;
        }

    }
}

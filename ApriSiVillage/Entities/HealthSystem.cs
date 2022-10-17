using System;

namespace ApriSiVillage.Entities
{
    public class HealthSystem
    {
        public HealthSystem()
        {
            Health = RNG.Range(1, 10);
        }

        public int Health;

        public void TakeDamage(Villager target, int amount)
        {
            Health -= amount;
            if(Health <= 0) {
                target.SetDeath(true);
            }
        }
    }
}

using ApriSiVillage.Entities;

namespace ApriSiVillage.Interface
{
    public interface IDamageable
    {
        void Damage(Villager target, int amount)
        {
            var healthSystem = target.HealthSystem;
            healthSystem.TakeDamage(target, amount);
        }
    }
}

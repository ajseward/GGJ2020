using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class ExplosiveWeapon : Weapon
    {
        public float Range = 10f;
        public int Damage = 1;

        protected override void Fire_Implementation(Vector2 direction)
        {
            var components = transform.FindTypeInRadius<HealthComponent>(Range);
            foreach (var component in components)
            {
                component.Damage(Damage);
            }
        }
    }
}
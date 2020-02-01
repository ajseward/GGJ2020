using System.Linq;
using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class DestructiveEnemy : Enemy
    {
        public Weapon Weapon;
        
        public override void Attack()
        {
            if (Weapon != null)
            {
                Weapon.Fire(transform.up);
            }
        }

        public override GameObject GetTarget()
        {
            return transform.FindTypeInRadius<HealthComponent>(100)?
                .OrderBy(comp => comp.gameObject.Distance(gameObject))
                .FirstOrDefault()?.gameObject;
        }
    }
}
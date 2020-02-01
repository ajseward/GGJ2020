using UnityEngine;

namespace AnimeDiseaseGame
{
    public class ShootingEnemy : Enemy
    {
        public Weapon EquippedWeapon;

        public override GameObject GetTarget()
        {
            return GameObject.FindWithTag("Player");
        }

        public override void Attack()
        {
            EquippedWeapon.Fire(transform.up);
        }
    }
}
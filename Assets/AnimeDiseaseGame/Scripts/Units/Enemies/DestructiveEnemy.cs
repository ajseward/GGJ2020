using UnityEngine;

namespace AnimeDiseaseGame
{
    public class DestructiveEnemy : Enemy
    {
        public Weapon Weapon;
        private bool _animationHasFired = false;
        
        public override void Attack()
        {
            if (Weapon != null)
            {
                if (Weapon.CanFire() && !_animationHasFired)
                {
                    var animator = GetComponent<Animator>();
                    animator.SetTrigger("Attack");
                    _animationHasFired = true;
                }
            }
        }

        public void Animation_Attack()
        {
            Weapon.Fire(transform.up);
            _animationHasFired = false;
        }

        public override GameObject GetTarget()
        {
            return GameObject.FindWithTag("Player");
        }
    }
}
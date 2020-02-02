using System.Collections;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class BossBeamWeapon : BossWeapon
    {
        public Projectile BeamProjectile;
        protected override void Fire_Implementation(Vector2 direction)
        {
            if (!HasFinishedFiring)
                return;

            HasFinishedFiring = false;
            SavedDirection = direction;

            StartCoroutine(ChargeAttack());
        }

        public IEnumerator ChargeAttack()
        {
            var enemy = GetComponentInParent<Enemy>();
            enemy.ShouldTrack = false;
            var animator = GetComponentInParent<Animator>();
            animator.SetTrigger("BeamStart");
            
            yield return new WaitForSeconds(2f);
            var proj = Instantiate(BeamProjectile, transform.position, Quaternion.identity);
            proj.transform.up = SavedDirection;
            yield return new WaitForSeconds(0.2f);
            proj.Fire();
            animator.SetTrigger("BeamEnd");

            enemy.ShouldTrack = true;
            HasFinishedFiring = true;
        }
    }
}
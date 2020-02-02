using System.Collections;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class BossChargeWeapon : BossWeapon
    {
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
            var animator = GetComponentInParent<Animator>();
            animator.SetTrigger("ChargeStart");
            
            yield return new WaitForSeconds(2f);
            
            animator.SetTrigger("ChargeStop");
            var rb = GetComponentInParent<Rigidbody2D>();
            var enemy = GetComponentInParent<Enemy>();
            var moveSpeed = enemy.MoveSpeed;
            enemy.MoveSpeed = 100f;
            rb.AddForce(SavedDirection * 100f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
            enemy.MoveSpeed = moveSpeed;
            HasFinishedFiring = true;
        }
    }
}
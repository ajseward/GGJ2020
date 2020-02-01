using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class MeleeWeapon : Weapon
    {
        public int Damage = 1;
        protected override void Fire_Implementation(Vector2 direction)
        {
            var hits = new RaycastHit2D[20];
            var count = Physics2D.BoxCastNonAlloc(transform.position, Vector2.one / 2f, 0f, transform.up, hits);

            if (count > 0)
            {
                for (var i = 0; i < count; ++i)
                {
                    var hit = hits[i];
                    hit.collider.gameObject.Damage(Damage);
                }
            }
        }
    }
}
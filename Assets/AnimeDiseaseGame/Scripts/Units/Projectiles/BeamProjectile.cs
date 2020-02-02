using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class BeamProjectile : Projectile
    {
        public override void OnHitOtherTeam(Collider2D other)
        {
            other.gameObject.Damage(1);
        }

        public override void Fire()
        {
            Destroy(gameObject);
        }
    }
}
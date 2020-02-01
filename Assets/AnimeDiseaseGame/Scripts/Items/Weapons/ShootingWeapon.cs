using UnityEngine;

namespace AnimeDiseaseGame
{
    public class ShootingWeapon : Weapon
    {
        public Projectile Projectile;
        protected override void Fire_Implementation(Vector2 direction)
        {
            var myTransform = transform;
            var parentVelocity = myTransform.root.GetComponent<Rigidbody2D>().velocity;
            
            var go = Instantiate(Projectile.gameObject, myTransform.position, Quaternion.identity);
            go.transform.up = direction;

            var proj = go.GetComponent<Projectile>();

            proj.Team = Team;

            proj.Fire();
        }
    }
}
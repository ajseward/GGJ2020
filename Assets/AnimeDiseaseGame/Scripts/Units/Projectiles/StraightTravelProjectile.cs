using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using GameJamStarterKit.Modifiers;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StraightTravelProjectile : Projectile
    {
        public ModifiableValue<float> Speed;
        
        [SerializeField]
        private float BaseSpeed = 20f;
        public float Lifetime = 10f;
        private TimeSince _timeSinceStart;
        
        private void Awake()
        {
            _timeSinceStart = 0f;
            Speed = BaseSpeed;
        }

        private void Update()
        {
            if (_timeSinceStart >= Lifetime)
            {
                Destroy(gameObject);
            }
        }

        public override void OnHitOtherTeam(Collider2D other)
        {
            other.gameObject.Damage(Damage);
            Destroy(gameObject);
        }

        public override void Fire()
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * Speed.ModifiedValue;
        }
    }
}
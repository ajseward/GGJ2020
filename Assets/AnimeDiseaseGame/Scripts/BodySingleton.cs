using System;
using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [RequireComponent(typeof(HealthComponent))]
    public class BodySingleton : SingletonBehaviour<BodySingleton>
    {
        public int DamagePerSecond = 1;
        private TimeSince _timeSinceDamage;
        public HealthComponent HealthComponent;

        protected override void Awake()
        {
            base.Awake();
            HealthComponent = GetComponent<HealthComponent>();
            _timeSinceDamage = 0;
        }

        public void Update()
        {
            if (_timeSinceDamage < 1)
            {
                return;
            }
            
            _timeSinceDamage = 0;
            HealthComponent.Damage(DamagePerSecond);
        }

        public void Reset()
        {
            HealthComponent.Heal(HealthComponent.MaximumHealth);
        }
    }
}
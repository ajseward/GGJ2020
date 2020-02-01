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
        private HealthComponent _healthComponent;

        protected override void Awake()
        {
            base.Awake();
            _healthComponent = GetComponent<HealthComponent>();
            _timeSinceDamage = 0;
        }

        public void Update()
        {
            if (_timeSinceDamage < 1)
            {
                return;
            }
            
            _timeSinceDamage = 0;
            _healthComponent.Damage(DamagePerSecond);
        }

        public void Reset()
        {
            _healthComponent.Heal(_healthComponent.MaximumHealth);
        }
    }
}
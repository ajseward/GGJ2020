﻿using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class Boss : Enemy
    {
        public BossWeapon ChargeAttack;
        public BossWeapon BeamAttack;
        
        private TimeSince _timeSinceDamagedPlayer;
        public float DamageAuraInterval = 2f;

        private void Start()
        {
            RotateTowards = false;
            GetComponent<HealthComponent>().OnHealthEmpty.AddListener(() => ((GameController)GameController.Instance).WinGame());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.HasComponent<CharacterControl>())
            {
                other.gameObject.Damage(1);
                _timeSinceDamagedPlayer = 0f;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!(_timeSinceDamagedPlayer >= DamageAuraInterval))
                return;
            
            if (!other.gameObject.HasComponent<CharacterControl>())
                return;
            
            other.gameObject.Damage(1);
            _timeSinceDamagedPlayer = 0f;
        }

        public override void Attack()
        {
            if (!BeamAttack.HasFinishedFiring || !ChargeAttack.HasFinishedFiring)
                return;
            
            var coinToss = KitRandom.CoinToss();
            if (coinToss)
            {
                BeamAttack.Fire(transform.position.DirectionTo(Target.transform.position));
            }
            else
            {
                ChargeAttack.Fire(transform.position.DirectionTo(Target.transform.position));
            }
        }

        public override GameObject GetTarget()
        {
            return GameObject.FindWithTag("Player");
        }
    }
}
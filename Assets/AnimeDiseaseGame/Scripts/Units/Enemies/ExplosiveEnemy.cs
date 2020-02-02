using System;
using GameJamStarterKit;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace AnimeDiseaseGame
{
    public class ExplosiveEnemy : Enemy
    {
        public Weapon Weapon;
        public int ChargeUpCount;

        private int _attempts;
        private Vector3 _initialScale;
        private Color _initialColor;
        private SpriteRenderer _spriteRenderer;

        private Vector3 _targetScale;
        private Color _targetColor;
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _initialScale = transform.localScale;
            _targetScale = _initialScale;
            _initialColor = _spriteRenderer.color;
            _targetColor = _initialColor;
        }

        protected override void OnChase()
        {
            if (_attempts == 0)
            {
                return;
            }
            _attempts = 0;
            transform.localScale = _initialScale;
            _targetScale = _initialScale;
            GetComponent<SpriteRenderer>().color = _initialColor;
            _targetColor = _initialColor;
        }

        public override void Attack()
        {
            if (!Weapon.CanFire())
                return;
            Weapon.TimeSinceFire = 0f;
            
            if (_attempts < ChargeUpCount)
            {
                ++_attempts;
                _targetScale = Vector3.one * _attempts;
                _targetColor = (Color.red / ChargeUpCount) * _attempts;
                _targetColor.a = _initialColor.a;
            }
            else
            {
                Weapon.TimeSinceFire = Weapon.FireRate * 2f;
                Weapon.Fire(transform.up);
                Destroy(gameObject);
            }
        }

        protected override void Update()
        {
            base.Update();
            var dt = Time.deltaTime;
            if (!Mathf.Approximately(_targetColor.r, _spriteRenderer.color.r))
            {
                _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, _targetColor, (float) dt * 10f);
            }

            if (!Mathf.Approximately(_targetScale.x, transform.localScale.x))
            {
                transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, dt * 10f);
            }
        }

        public override GameObject GetTarget()
        {
            return GameObject.FindWithTag("Player");
        }
    }
}
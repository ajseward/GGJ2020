using System;
using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : TeamMonoBehaviour
    {
        public float MaxRange = 20f;
        public float MinRange = 10f;
        public float MoveSpeed = 4f;
        private bool _asleep = true;
        private Rigidbody2D _rb;
        private HealthComponent _healthComponent;
        private Animator _animator;

        private Vector2 _moveDir;

        protected GameObject Target;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _healthComponent = GetComponent<HealthComponent>();
            _animator = GetComponent<Animator>();
            _healthComponent.OnHealthLost.AddListener(health =>
            {
                if (_animator.HasParameter("Hit"))
                    _animator.SetTrigger("Hit");

                _rb.velocity = Vector2.zero;
            });
            
            _healthComponent.OnHealthEmpty.AddListener(() => Destroy(gameObject));
        }

        [KitButton()]
        public void WakeUp()
        {
            _asleep = false;
        }

        private void Update()
        {
            if (_asleep)
                return;

            if (Target == null)
            {
                Target = GetTarget();
            }

            var myTransform = transform;
            myTransform.up = (Vector2)myTransform.position.DirectionTo(Target.transform.position);

            if (Vector2.Distance(myTransform.position, Target.transform.position) > MaxRange)
            {
                _moveDir = myTransform.position.DirectionTo(Target.transform.position);
            }
            else if (Vector2.Distance(myTransform.position, Target.transform.position) < MinRange)
            {
                _moveDir = -myTransform.position.DirectionTo(Target.transform.position);
            }
            else
            {
                _moveDir = Vector2.zero;
                Attack();
            }
        }

        private void FixedUpdate()
        {
            _rb.AddForce(_moveDir, ForceMode2D.Impulse);
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, MoveSpeed);
        }

        public abstract void Attack();
        
        public abstract GameObject GetTarget();
    }
}
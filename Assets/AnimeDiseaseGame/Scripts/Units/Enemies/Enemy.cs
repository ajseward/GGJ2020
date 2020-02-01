using System;
using GameJamStarterKit;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour
    {
        public float MaxRange = 20f;
        public float MinRange = 10f;
        public float MoveSpeed = 4f;
        private bool _asleep = true;
        private Rigidbody2D _rb;

        private Vector2 _moveDir;

        private GameObject _target;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
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

            if (_target == null)
            {
                _target = GameObject.FindWithTag("Player");
            }

            var myTransform = transform;
            myTransform.up = (Vector2)myTransform.position - (Vector2)_target.transform.position;

            if (Vector2.Distance(myTransform.position, _target.transform.position) > MaxRange)
            {
                _moveDir = myTransform.position.DirectionTo(_target.transform.position);
            }
            else if (Vector2.Distance(myTransform.position, _target.transform.position) < MinRange)
            {
                _moveDir = -myTransform.position.DirectionTo(_target.transform.position);
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
    }
}
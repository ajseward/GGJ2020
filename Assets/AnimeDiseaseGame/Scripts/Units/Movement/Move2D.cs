﻿using System;
using GameJamStarterKit.Modifiers;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move2D : MonoBehaviour
    {
        public Transform ChildRenderer;
        public ModifiableValue<float> MoveSpeed;
        [SerializeField]
        private float DefaultMoveSpeed = 6f;
        
        private Rigidbody2D _rb;
        private Weapon _weapon;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            MoveSpeed = DefaultMoveSpeed;
        }

        private void Start()
        {
            _weapon = GetComponentInChildren<Weapon>();
        }

        private void Update()
        {
            TryFireWeapon();
        }

        private void FixedUpdate()
        {
            DoMovement();
        }

        private void DoMovement()
        {
            var move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            move = Vector2.ClampMagnitude(move, 1);
            _rb.AddForce(move, ForceMode2D.Impulse);
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, MoveSpeed.ModifiedValue);
            if (ChildRenderer != null)
            {
                ChildRenderer.up = _rb.velocity.normalized;
            }
        }

        private void TryFireWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _weapon.Fire();
        }

        public bool EquipWeapon(Weapon weapon)
        {
            if (_weapon == null)
                return false;

            var go = weapon.gameObject;

            go.transform.SetParent(transform, false);
            _weapon = weapon;

            return true;
        }
    }
}
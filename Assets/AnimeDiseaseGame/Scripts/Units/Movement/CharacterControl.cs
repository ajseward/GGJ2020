using System;
using GameJamStarterKit.HealthSystem;
using GameJamStarterKit.Modifiers;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterControl : TeamMonoBehaviour
    {
        public Transform ChildRenderer;
        public ModifiableValue<float> MoveSpeed;
        [SerializeField]
        private float DefaultMoveSpeed = 6f;
        public Weapon Weapon;
        
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            MoveSpeed = DefaultMoveSpeed;
        }

        private void Start()
        {
            GameController.Instance.RegisterCharacterHealth(GetComponent<HealthComponent>());
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
            move = Vector2.ClampMagnitude(move, 1) * MoveSpeed.ModifiedValue;
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
                if (Weapon != null)
                    Weapon.Fire(ChildRenderer.up);
        }

        public bool EquipWeapon(Weapon weapon)
        {
            if (Weapon == null)
                return false;

            var go = weapon.gameObject;

            go.transform.SetParent(transform, false);
            Weapon = weapon;
            Weapon.Team = Team;

            return true;
        }
    }
}
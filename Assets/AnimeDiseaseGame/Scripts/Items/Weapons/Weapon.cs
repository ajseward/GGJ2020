using System;
using GameJamStarterKit;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public abstract class Weapon : TeamMonoBehaviour
    {
        public float FireRate;
        protected TimeSince TimeSinceFire;

        private void Start()
        {
            TimeSinceFire = 100f;
        }

        public void Fire(Vector2 direction)
        {
            if (TimeSinceFire >= FireRate)
            {
                TimeSinceFire = 0;
                Fire_Implementation(direction);
            }
        }
        
        protected abstract void Fire_Implementation(Vector2 direction);
    }
}
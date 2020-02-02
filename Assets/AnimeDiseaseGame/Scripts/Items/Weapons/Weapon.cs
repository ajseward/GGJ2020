using System;
using System.Runtime.InteropServices.WindowsRuntime;
using GameJamStarterKit;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public abstract class Weapon : TeamMonoBehaviour
    {
        public float FireRate;
        internal TimeSince TimeSinceFire;

        private void Start()
        {
            TimeSinceFire = 100f;
        }

        public bool CanFire()
        {
            return TimeSinceFire >= FireRate;
        }
        public void Fire(Vector2 direction)
        {
            if (CanFire())
            {
                TimeSinceFire = 0;
                Fire_Implementation(direction);
            }
        }
        
        protected abstract void Fire_Implementation(Vector2 direction);
    }
}
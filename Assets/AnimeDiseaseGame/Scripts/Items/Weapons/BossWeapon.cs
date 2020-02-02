using UnityEngine;

namespace AnimeDiseaseGame
{
    public abstract class BossWeapon : Weapon
    {
        protected Vector2 SavedDirection;
        public bool HasFinishedFiring = true;
    }
}
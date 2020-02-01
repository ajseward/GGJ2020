using System;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public abstract class Projectile : TeamMonoBehaviour
    {
        public int Damage;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var teamBehaviour = other.gameObject.GetComponent<TeamMonoBehaviour>();
            
            if (teamBehaviour != null)
            {
                if (Team != teamBehaviour.Team)
                {
                    OnHitOtherTeam(other);
                }
            }
        }
        public abstract void OnHitOtherTeam(Collider2D other);
        public abstract void Fire();
    }
}
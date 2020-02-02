using GameJamStarterKit.HealthSystem;
using TMPro;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class HealthUpdater : MonoBehaviour
    {
        public TMP_Text Text;
        public HealthComponent HealthComponent;

        private void FixedUpdate()
        {
            Text.SetText($"Health: {HealthComponent.Health} / {HealthComponent.MaximumHealth}");
        }
    }
}
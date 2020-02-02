using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [CreateAssetMenu(menuName = "Upgrades/SizeUpgrade")]
    public class SizeUpgrade : Upgrade
    {
        public float Size = 1f;
        public float HealthIncrease = 1f;
        public override void ApplyUpgrade(CharacterControl character)
        {
            character.gameObject.transform.localScale = Vector3.one * Size;
            var collider = character.GetComponent<Collider2D>();
            collider.SetSize(collider.GetSize() / Size, true);

            var health = character.GetComponent<HealthComponent>();
            health.MaximumHealth = Mathf.RoundToInt(health.MaximumHealth * HealthIncrease);
        }
    }
}
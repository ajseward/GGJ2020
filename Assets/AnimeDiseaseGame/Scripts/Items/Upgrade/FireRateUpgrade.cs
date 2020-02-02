using UnityEngine;

namespace AnimeDiseaseGame
{
    [CreateAssetMenu(menuName = "Upgrades/FireRateUpgrade")]
    public class FireRateUpgrade : Upgrade
    {
        public float FireRateMultiplier;
        public float ProjectileSpeedMultiplier;
        public override void ApplyUpgrade(CharacterControl character)
        {
            var weapon = character.Weapon;

            weapon.FireRate *= FireRateMultiplier;
            if (weapon is ShootingWeapon shootingWeapon)
            {
                shootingWeapon.ProjectileSpeedMultiplier = ProjectileSpeedMultiplier;
            }
        }
    }
}
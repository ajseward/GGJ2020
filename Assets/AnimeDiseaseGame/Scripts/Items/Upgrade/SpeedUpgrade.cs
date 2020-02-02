using System;
using GameJamStarterKit.Modifiers;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [CreateAssetMenu(menuName = "Upgrades/SpeedUpgrade")]
    public class SpeedUpgrade : Upgrade
    {
        public float Multiplier = 2f;
        public override void ApplyUpgrade(CharacterControl character)
        {
            character.MoveSpeed.AddModifier(new ValueModifier<float>(bv => bv * Multiplier));
        }
    }
}
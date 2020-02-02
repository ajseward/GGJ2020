using System;
using UnityEngine;

namespace AnimeDiseaseGame
{
    [Serializable]
    public abstract class Upgrade : ScriptableObject
    {
        public string Description;
        public Sprite Sprite;
        public abstract void ApplyUpgrade(CharacterControl character);
    }
}
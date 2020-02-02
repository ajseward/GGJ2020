using System.Collections.Generic;
using System.Linq;
using GameJamStarterKit;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace AnimeDiseaseGame
{
    public class UpgradeChoiceManager : MonoBehaviour
    {
        public List<Upgrade> PotentialUpgrades = new List<Upgrade>();
        public HorizontalLayoutGroup Container;
        [CanBeNull]
        public List<Upgrade> GetUpgradeChoices()
        {
            if (PotentialUpgrades.Count < 3)
            {
                Debug.LogError("Can't make an upgrade choice with less than 3 potential upgrades");
                return null;
            }

            var items = new List<Upgrade>();
            PotentialUpgrades.Shuffle();
            items.AddRange(PotentialUpgrades.GetRange(0, 3));
            return items;
        }

        public void ShowUpgradeChoices()
        {
            var choices = GetUpgradeChoices();
            if (choices == null)
                return;
            var i = 0;
            foreach (var view in Container.GetComponentsInChildren<UpgradeView>())
            {
                view.Show(choices[i++]);
            }
        }

        public void SelectUpgrade(Upgrade upgrade)
        {
            var control = GameObject.FindWithTag("Player").GetComponent<CharacterControl>();
            upgrade.ApplyUpgrade(control);
            if (GameView.Instance is GameView view)
            {
                view.HideUpgradeChoice();
            }
        }
    }
}
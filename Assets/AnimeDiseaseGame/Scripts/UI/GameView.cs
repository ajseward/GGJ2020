using System;
using GameJamStarterKit.UI;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class GameView : View
    {
        public UpgradeChoiceManager UpgradeManager;

        private void Start()
        {
            ShowUpgradeChoice();
        }

        public void ShowUpgradeChoice()
        {
            UpgradeManager.transform.SetAsLastSibling();
            UpgradeManager.gameObject.SetActive(true);
            ShowInputBlockerBehind(UpgradeManager.transform);
            UpgradeManager.ShowUpgradeChoices();
        }

        public void HideUpgradeChoice()
        {
            UpgradeManager.gameObject.SetActive(false);
            HideInputBlocker();
        }
    }
}
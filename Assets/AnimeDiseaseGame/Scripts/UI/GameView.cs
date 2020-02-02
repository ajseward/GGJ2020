using System.Collections;
using GameJamStarterKit.UI;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class GameView : View
    {
        public UpgradeChoiceManager UpgradeManager;
        public GameObject ThanksForPlaying;

        private void Start()
        {
            ShowUpgradeChoice();
        }

        public void ShowUpgradeChoice()
        {
            UpgradeManager.gameObject.SetActive(true);
            UpgradeManager.transform.SetAsLastSibling();
            ShowInputBlockerBehind(UpgradeManager.transform);
            UpgradeManager.ShowUpgradeChoices();
        }

        public void HideUpgradeChoice()
        {
            UpgradeManager.gameObject.SetActive(false);
            HideInputBlocker();
        }

        public IEnumerator ShowThanks()
        {
            ThanksForPlaying.SetActive(true);
            ThanksForPlaying.transform.SetAsLastSibling();
            ShowInputBlockerBehind(ThanksForPlaying.transform);
            yield return new WaitForSeconds(5f);
            
            GameController.Instance.RestartGame();
        }
    }
}
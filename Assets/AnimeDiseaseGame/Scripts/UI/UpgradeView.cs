using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AnimeDiseaseGame
{
    public class UpgradeView : MonoBehaviour, IPointerClickHandler
    {
        public TMP_Text Description;
        public Image Renderer;

        private Upgrade _upgrade;
        public void Show(Upgrade upgrade)
        {
            _upgrade = upgrade;
            Description.SetText(upgrade.Description);
            Renderer.sprite = upgrade.Sprite;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (GameView.Instance is GameView view)
            {
                view.UpgradeManager.SelectUpgrade(_upgrade);
            }
        }
    }
}
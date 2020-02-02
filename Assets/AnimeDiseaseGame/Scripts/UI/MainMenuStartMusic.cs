using UnityEngine;

namespace AnimeDiseaseGame
{
    public class MainMenuStartMusic : MonoBehaviour
    {
        private void Start()
        {
            BGMController.Instance.PlaySong("Menu");
        }
    }
}
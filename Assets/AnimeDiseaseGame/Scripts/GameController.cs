using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class GameController : PersistentSingletonBehaviour<GameController>
    {
        private BodySingleton _body;
        private DungeonGenerator _dungeonGenerator;
        public int ActiveEnemies = 0;

        private void Start()
        {
            _body = BodySingleton.Instance;
            _dungeonGenerator = DungeonGenerator.Instance;

            _body.HealthComponent.OnHealthEmpty.AddListener(LoseGame);
        }

        public void RegisterCharacterHealth(HealthComponent characterHealth)
        {
            characterHealth.OnHealthEmpty.AddListener(LoseGame);
        }

        public void LoseGame()
        {
            if (GameView.Instance is GameView gv)
            {
                StartCoroutine(gv.ShowThanks());
            }
        }

        public void WinGame()
        {
            if (GameView.Instance is GameView gv)
            {
               StartCoroutine(gv.ShowThanks());
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RestartGame();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                BGMController.Instance.PlaySong("Combat");
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                BGMController.Instance.PlaySong("Calm");
            }
        }

        public void RestartGame()
        {
            KItSceneManager.ReloadCurrentScene();
            BGMController.Instance.PlaySong("Calm");
        }
    }
}
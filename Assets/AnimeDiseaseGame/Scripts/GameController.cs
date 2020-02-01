using System;
using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class GameController : PersistentSingletonBehaviour<GameController>
    {
        private BodySingleton _body;
        private DungeonGenerator _dungeonGenerator;

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

        private void LoseGame()
        {
            Debug.LogError("damn u lose");
        }

        private void RestartGame()
        {
            KItSceneManager.ReloadCurrentScene();
        }
    }
}
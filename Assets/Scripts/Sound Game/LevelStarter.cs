using MoreMountains.Feedbacks;
using UnityEngine;

namespace Sound_Game
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private GameState gameState;
        [SerializeField] private CheckButtons checkButtons;
        [SerializeField] private AudioSource levelAudio;

        private void Awake()
        {
            gameState.OnLevelChange += OnLevelChange;
        }

        private void OnLevelChange(LevelSettings levelSettings)
        {
            
        }

        public void SetLevel(LevelSettings levelSettings)
        {
            checkButtons.InitImages(levelSettings.levelImages, levelSettings.correctImageNumber);
            levelAudio.clip = levelSettings.levelAudio;
        }
    }
}
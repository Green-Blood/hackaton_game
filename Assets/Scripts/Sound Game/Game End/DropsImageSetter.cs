using UnityEngine;

namespace Sound_Game.Game_End
{
    public class DropsImageSetter : MonoBehaviour
    {
        [SerializeField] private Drop[] drops;
        [SerializeField] private Sprite[] dropSprites;
        [SerializeField] private float dropAnimationDelay = 0.35f;

        private ScoreSystem _scoreSystem;

        public void Construct(ScoreSystem score)
        {
            _scoreSystem = score;
            InitDropImages();
        }

        public void Animate()
        {
            Debug.Log("Current Score is + " + _scoreSystem.GetCurrentScore());
            for (var index = 0; index < _scoreSystem.GetCurrentScore(); index++)
            {
                var drop = drops[index];

                drop.SetDropImage(drop.IsCatDrop ? dropSprites[1] : dropSprites[0]);
                drop.AnimateImage(dropAnimationDelay * index);
            }
        }

        private void InitDropImages()
        {
            foreach (var drop in drops)
            {
                drop.SetDropImage(dropSprites[3]);
            }
        }
    }
}
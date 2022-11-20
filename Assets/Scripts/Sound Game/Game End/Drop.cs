using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Sound_Game.Game_End
{
    public class Drop : MonoBehaviour
    {
        [SerializeField] private Image dropImage;
        [SerializeField] private Image fillDropImage;
        [SerializeField] private bool isCatDrop;
        [SerializeField] private float fillDuration = 0.5f;
        public bool IsCatDrop => isCatDrop;

        public void SetDropImage(Sprite sprite) => fillDropImage.sprite = sprite;

        public void AnimateImage(float dropAnimationDelay)
        {
            fillDropImage.DOFillAmount(0, 0);
            fillDropImage.DOFillAmount(1f, fillDuration).SetDelay(dropAnimationDelay + fillDuration);
        }
    }
}
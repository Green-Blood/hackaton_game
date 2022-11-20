using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Sound_Game.Game_End
{
    public class GameEndPanel : MonoBehaviour
    {
        [SerializeField] private StarsAnimation starsAnimation;
        [SerializeField] private DropsImageSetter dropsImageSetter;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI congratulationsText;
        [SerializeField] private float animationDuration;
        [SerializeField] private float congratulationsAnimationDuration = 0.75f;
        [SerializeField] private Ease congratulationsEase;

        public void Construct(ScoreSystem score)
        {
            dropsImageSetter.Construct(score);
            canvasGroup.DOFade(0, 0);
        }

        public void StartAnimation()
        {
            canvasGroup.DOFade(1f, animationDuration)
                .OnComplete(()
                    => starsAnimation.Animate(()
                        =>
                    {
                        congratulationsText.transform.DOScale(Vector3.one, congratulationsAnimationDuration)
                            .SetEase(congratulationsEase);
                        dropsImageSetter.Animate();
                    }));
        }
    }
}
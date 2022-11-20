using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Sound_Game.Game_End
{
    public class StarsAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject[] stars;
        [SerializeField] private float animationStartDelay = 0.1f;
        [SerializeField] private float animationDuration = 0.1f;
        [SerializeField] private Ease animationEase;

        private void Awake()
        {
            foreach (var star in stars)
            {
                star.transform.DOScale(Vector3.zero, 0);
            }
        }

        public void Animate(Action onAnimationFinished)
        {
            for (var index = 0; index < stars.Length; index++)
            {
                var star = stars[index];
                star.transform.DOScale(Vector3.one, animationDuration).SetEase(animationEase)
                    .SetDelay(index * animationStartDelay);
            }

            Observable.Timer((TimeSpan.FromSeconds(stars.Length * animationStartDelay)))
                .Subscribe(l => onAnimationFinished?.Invoke());
        }
    }
}
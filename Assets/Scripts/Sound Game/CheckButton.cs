using System;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

namespace Sound_Game
{
    public class CheckButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private MMF_Player correctFeedback;
        [SerializeField] private MMF_Player inCorrectFeedback;
        [SerializeField] private Image image;
        [SerializeField] private Image buttonImage;

        public bool IsCorrect { get; set; }
        public Button Button => button;
        public Image Image => buttonImage;
        public Action OnCorrectFeedbackClicked;
        private Color _initialColor;

        private void Awake()
        {
            _initialColor = image.color;
        }


        public void PlayCorrectFeedback()
        {
            correctFeedback.PlayFeedbacks();
            image.gameObject.SetActive(true);
            image.DOColor(Color.green, 0.2f).SetLoops(2).OnComplete(() =>
            {
                image.color = _initialColor;
                image.gameObject.SetActive(false);
                OnCorrectFeedbackClicked?.Invoke();
            });
        }

        public void PlayIncorrectFeedback()
        {
            inCorrectFeedback.PlayFeedbacks();
            image.gameObject.SetActive(true);
            image.DOColor(Color.red, 0.2f).SetLoops(2).OnComplete(() =>
            {
                image.color = _initialColor;
                image.gameObject.SetActive(false);
            });
        }
    }
}
using System;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sound_Game
{
    public class CheckButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private MMF_Player correctFeedback;
        [SerializeField] private MMF_Player inCorrectFeedback;
        [SerializeField] private MMF_Player clickFeedback;
        [SerializeField] private Image image;
        [SerializeField] private Image buttonImage;

        private HandMover _handMover;

        public bool IsCorrect { get; set; }
        public Button Button => button;
        public Image Image => buttonImage;
        public Action<Button> OnButtonClicked;

        public Action OnCorrectFeedbackClicked;
        private bool _canClick = true;
        private ScoreSystem _scoreSystem;
        private void Awake() => DeactivateStateImage();

        public void Construct(HandMover handMover, ScoreSystem scoreSystem)
        {
            _handMover = handMover;
            _scoreSystem = scoreSystem;
            
            _handMover.OnHandClicked += OnHandClicked;
            _handMover.OnHandFinishedMoving += OnHandFinishedMoving;
        }

        private void OnHandFinishedMoving()
        {
            DeactivateStateImage();
            _canClick = true;
        }

        private void DeactivateStateImage() => image.gameObject.SetActive(false);

        private void OnHandClicked(Button clickedButton)
        {
            if (clickedButton != button) return;
            clickFeedback.PlayFeedbacks();
            image.gameObject.SetActive(true);
        }

        public void PlayCorrectFeedback()
        {
            if (!_canClick) return;
            correctFeedback.PlayFeedbacks();
            Observable.Timer(TimeSpan.FromSeconds(correctFeedback.TotalDuration)).Subscribe(l =>
            {
                OnCorrectFeedbackClicked?.Invoke();
                _scoreSystem.IncreaseScore();
            });
            OnButtonClicked?.Invoke(button);
            _canClick = false;


            // image.gameObject.SetActive(true);
            // image.DOColor(Color.green, 0.2f).SetLoops(2).OnComplete(() =>
            // {
            //     image.color = _initialColor;
            //     image.gameObject.SetActive(false);
            //   
            // });
        }

        public void PlayIncorrectFeedback()
        {
            if (!_canClick) return;
            inCorrectFeedback.PlayFeedbacks();
            OnButtonClicked?.Invoke(button);
            _canClick = false;


            // image.gameObject.SetActive(true);
            // Observable.Timer(TimeSpan.FromSeconds(inCorrectFeedback.TotalDuration)).Subscribe(l =>
            // {
            // image.gameObject.SetActive(false);
            // });

            // image.DOColor(Color.red, 0.2f).SetLoops(2).OnComplete(() =>
            // {
            //     image.color = _initialColor;

            // });
        }
    }
}
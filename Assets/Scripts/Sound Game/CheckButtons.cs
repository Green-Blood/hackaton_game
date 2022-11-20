using UnityEngine;

namespace Sound_Game
{
    public class CheckButtons : MonoBehaviour
    {
        [SerializeField] private CheckButton[] checkButtons;

        private HandMover _handMover;

        public void Construct(ScoreSystem scoreSystem, HandMover handMover)
        {
            _handMover = handMover;

            foreach (var checkButton in checkButtons)
            {
                checkButton.Construct(_handMover, scoreSystem);
            }
        }


        public void InitImages(Sprite[] levelSettingsLevelImages, int levelSettingsCorrectImageNumber)
        {
            for (var index = 0; index < checkButtons.Length; index++)
            {
                var checkButton = checkButtons[index];
                checkButton.Image.sprite = levelSettingsLevelImages[index];
                if (index == levelSettingsCorrectImageNumber - 1)
                {
                    checkButton.IsCorrect = true;
                }
            }

            InitButtons();
        }

        private void InitButtons()
        {
            foreach (var checkButton in checkButtons)
            {
                UnSubscribeFromPreviousEvents(checkButton);
                SubscribeToCorrectButtonClick(checkButton);
                SubscribeToHandMovement(checkButton);
            }
        }

        private void UnSubscribeFromPreviousEvents(CheckButton checkButton)
        {
            if (checkButton.OnButtonClicked != null) checkButton.OnButtonClicked -= _handMover.MoveCatHand;
        }

        private static void SubscribeToCorrectButtonClick(CheckButton checkButton)
        {
            if (checkButton.IsCorrect)
                checkButton.Button.onClick.AddListener(checkButton.PlayCorrectFeedback);
            else
                checkButton.Button.onClick.AddListener(checkButton.PlayIncorrectFeedback);
        }

        private void SubscribeToHandMovement(CheckButton checkButton) =>
            checkButton.OnButtonClicked += _handMover.MoveCatHand;


        public void SetInteractable(bool isInteractable)
        {
            foreach (var checkButton in checkButtons) checkButton.Button.interactable = isInteractable;
        }
    }
}
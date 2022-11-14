using System;
using UnityEngine;

namespace Sound_Game
{
    public class CheckButtons : MonoBehaviour
    {
        [SerializeField] private CheckButton[] checkButtons;

        public void InitImages(Sprite[] levelSettingsLevelImages, int levelSettingsCorrectImageNumber, Action onCorrectButtonClicked)
        {
            for (var index = 0; index < checkButtons.Length; index++)
            {
                var checkButton = checkButtons[index];
                checkButton.Image.sprite = levelSettingsLevelImages[index];
                Debug.Log("Check button image is " + levelSettingsLevelImages[index]);
                if (index == levelSettingsCorrectImageNumber - 1)
                {
                    checkButton.IsCorrect = true;
                }
            }

            InitButtons(onCorrectButtonClicked);
        }

        private void InitButtons(Action onCorrectButtonClicked)
        {
            foreach (var checkButton in checkButtons)
            {
                if (checkButton.IsCorrect)
                {
                    checkButton.Button.onClick.AddListener(checkButton.PlayCorrectFeedback);
                    checkButton.OnCorrectFeedbackClicked += () => onCorrectButtonClicked?.Invoke();
                }
                else
                {
                    checkButton.Button.onClick.AddListener(checkButton.PlayIncorrectFeedback);
                }
            }
        }
    }
}
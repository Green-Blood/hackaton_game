using UnityEngine;

namespace Sound_Game
{
    public class CheckButtons : MonoBehaviour
    {
        [SerializeField] private CheckButton[] checkButtons;
     
        private void Awake()
        {
            foreach (var checkButton in checkButtons)
            {
                if (checkButton.isCorrect)
                {
                    checkButton.Button.onClick.AddListener(checkButton.PlayCorrectFeedback);
                }
                else
                {
                    checkButton.Button.onClick.AddListener(checkButton.PlayIncorrectFeedback);
                }
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
                    checkButton.isCorrect = true;
                }
            }
        }
    }
}
using UnityEngine;

namespace Sound_Game.Game_End
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameEndPanel gameEndPanel;
        [SerializeField] private CheckButtons checkButtons;
        [SerializeField] private HandMover handMover;

        public HandMover HandMover => handMover;
        public CheckButtons CheckButtons => checkButtons;
        public GameEndPanel GameEndPanel => gameEndPanel;

        public void Construct(ScoreSystem scoreSystem)
        {
            checkButtons.Construct(scoreSystem, handMover);
            GameEndPanel.Construct(scoreSystem);
        }
        public void ActivateEndPanel()
        {
            gameEndPanel.gameObject.SetActive(true);
            checkButtons.gameObject.SetActive(false);
            handMover.gameObject.SetActive(false);
        }

        public void ActivateMainPanel()
        {
            gameEndPanel.gameObject.SetActive(false);
            checkButtons.gameObject.SetActive(true);
            handMover.gameObject.SetActive(true);
        }
    }
}
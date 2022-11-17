using UnityEngine;

namespace Sound_Game
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameLevels gameLevels;
        [SerializeField] private CheckButtons checkButtons;
        [SerializeField] private AudioSource levelAudio;
        [SerializeField] private HandMover handMover;
        
        private StateMachine _stateMachine;
        private GameState _gameState;
        private ScoreSystem _scoreSystem;
        private LevelStarter _levelStarter;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            _gameState = new GameState(gameLevels);
            _scoreSystem = new ScoreSystem();
            _levelStarter = new LevelStarter(_gameState, checkButtons, levelAudio, _scoreSystem);
        }
        private void Start() => StartGame();
        private void StartGame() => _gameState.SetLevel(1);
        private void OnEnable()
        {
            _stateMachine.OnStateChange += OnStateChange;
            handMover.OnHandFinishedMoving += StartNextLevel;
        }

        private void StartNextLevel() => _stateMachine.ChangeState(State.NextGame);

        private void OnStateChange(State state)
        {
            if (state != State.NextGame) return;
            if (_gameState.CanStartNextLevel())
            {
                _gameState.SetNextLevel();
            }
            else
            {
                // End Level
            }
        }

        private void OnDisable()
        {
            _stateMachine.OnStateChange -= OnStateChange;
            handMover.OnHandFinishedMoving -= StartNextLevel;
        }
    }
}
using UnityEngine;

namespace Sound_Game
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameLevels gameLevels;
        [SerializeField] private CheckButtons checkButtons;
        [SerializeField] private AudioSource levelAudio;
        
        private StateMachine _stateMachine;
        private GameState _gameState;
        private LevelStarter _levelStarter;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            _gameState = new GameState(gameLevels);
            _levelStarter = new LevelStarter(_gameState, checkButtons, levelAudio);
        }
        private void Start() => StartGame();
        private void StartGame() => _gameState.SetLevel(1);
        private void OnEnable() => _stateMachine.OnStateChange += OnStateChange;

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

        private void OnDisable() => _stateMachine.OnStateChange -= OnStateChange;
    }
}
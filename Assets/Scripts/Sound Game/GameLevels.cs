using UnityEngine;

namespace Sound_Game
{
    [CreateAssetMenu(fileName = "Game Level Settings", menuName = "Settings")]
    public class GameLevels : ScriptableObject
    {
        public LevelSettings[] levelSettings;
    }
}

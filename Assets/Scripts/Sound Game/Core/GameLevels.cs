using UnityEngine;

namespace Sound_Game.Core
{
    [CreateAssetMenu(fileName = "Game Level Settings", menuName = "Settings/Game Level")]
    public class GameLevels : ScriptableObject
    {
        public LevelSettings[] levelSettings;
    }
}

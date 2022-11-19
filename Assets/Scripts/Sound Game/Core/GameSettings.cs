using UnityEngine;

namespace Sound_Game.Core
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public float levelSoundStartDelay = 1f;
    }
}
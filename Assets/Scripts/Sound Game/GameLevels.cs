using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sound_Game
{
    [CreateAssetMenu(fileName = "Game Level Settings", menuName = "Settings")]
    public class GameLevels : ScriptableObject
    {
        public LevelSettings[] levelSettings;
    }

    [Serializable]
    public struct LevelSettings
    {
        public Sprite[] levelImages;
        [Tooltip("Start from 1, it's ok)")]
        public int correctImageNumber;
        public AudioClip levelAudio;
    }
    
}

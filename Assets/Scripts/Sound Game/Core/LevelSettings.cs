using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sound_Game.Core
{
    [Serializable]
    public class LevelSettings
    {
        public Sprite[] levelImages;
        [Tooltip("Start from 1, it's ok)")]
        [ValidateInput(nameof(IsZero), "Correct number can't be zero")]
        public int correctImageNumber;
        public AudioClip levelAudio;

        private bool IsZero(int imageNumber) => imageNumber != 0;
    }
}
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Sound_Game
{
    public class GameSound : MonoBehaviour
    {
        [SerializeField] private AudioSource levelAudio;
        [SerializeField] private MMF_Player clickFeedback;

        public void PlayClickFeedback() => clickFeedback.PlayFeedbacks();
        public void PlayLevelAudio() => levelAudio.Play();
        public float GetLevelAudioLenght() => levelAudio.clip.length;
        public void ChangeLevelAudio(AudioClip audioSource) => levelAudio.clip = audioSource;
    }
}
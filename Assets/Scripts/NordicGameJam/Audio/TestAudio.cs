using System;
using System.Linq;
using UnityEngine;

namespace NordicGameJam.Audio
{
    public class TestAudio : MonoBehaviour
    {
        private void OnGUI()
        {
            GUILayout.Space(100);
            var audioClips = Enum.GetValues(typeof(AudioClipType)).Cast<AudioClipType>();;
            foreach (var audioClipType in audioClips)
            {
                if (GUILayout.Button(audioClipType.ToString()))
                {
                    SimpleAudioManager.Instance.PlayOneShot(audioClipType);
                }
            }
        }
    }
}

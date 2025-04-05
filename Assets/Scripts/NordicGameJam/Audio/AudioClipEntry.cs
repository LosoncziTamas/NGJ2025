using System;
using UnityEngine;

namespace NordicGameJam.Audio
{
    [Serializable]
    public class AudioClipEntry
    {
        public AudioClipType Type;
        public AudioClip Clip;
    }
}
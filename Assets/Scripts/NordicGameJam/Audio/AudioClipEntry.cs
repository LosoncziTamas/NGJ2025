using System;
using UnityEngine;

namespace NordicGameJam.Audio
{
    [Serializable]
    public class AudioClipEntry
    {
        public AudioClipTypes Type;
        public AudioClip Clip;
    }
}
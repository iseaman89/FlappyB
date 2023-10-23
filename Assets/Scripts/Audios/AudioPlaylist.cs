using System.Collections.Generic;
using UnityEngine;

namespace Audios
{
    [CreateAssetMenu(fileName = "AudioPlaylist", menuName = "Audio", order = 0)]
    public class AudioPlaylist : ScriptableObject
    {
        public List<AudioClip> Playlist;
    }
}
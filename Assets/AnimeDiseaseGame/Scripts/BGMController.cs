using System.Collections.Generic;
using System.Linq;
using GameJamStarterKit;
using GameJamStarterKit.Audio;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class BGMController : PersistentSingletonBehaviour<BGMController>
    {
        public List<BGMItem> Songs = new List<BGMItem>();
        private string _lastSongPlayed = "";
        public void PlaySong(string songName)
        {
            var song = Songs.FirstOrDefault(s => s.Name == songName);
            if (song != null && _lastSongPlayed != songName)
            {
                var clip = song.Clips.GetClip();
                if (clip == null)
                    return;
                _lastSongPlayed = songName;
                Debug.Log($"Playing Clip: {clip.name}");
                PersistentBackgroundMusic.Instance.PlayOneShot(clip, 1f, true);
            }
        }
    }
}
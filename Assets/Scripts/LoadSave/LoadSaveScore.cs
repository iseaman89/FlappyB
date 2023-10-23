using Scores;
using UnityEngine;

namespace LoadSave
{
    public class LoadSaveScore
    {
        private const string Key = "Score";
        private readonly Score _score;

        public LoadSaveScore(Score score)
        {
            _score = score;
        }

        public void Save(int value) => PlayerPrefs.SetInt(Key, value);

        public void Load() => _score.BestScore = PlayerPrefs.GetInt(Key);
    }
}
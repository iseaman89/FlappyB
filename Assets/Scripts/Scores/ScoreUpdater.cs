using System;

namespace Scores
{
    public class ScoreUpdater
    {
        private int _toastyGoal = 10;
        public Score Score { get; set; }

        public Action OnValueChanged;
        public Action OnToastyGoalReached;

        public ScoreUpdater(Score score)
        {
            Score = score;
        }

        public void Update()
        {
            Score.LastScore++;
            if (Score.BestScore <= Score.LastScore) Score.BestScore = Score.LastScore;
            ShowToasty();
            OnValueChanged?.Invoke();
        }

        public void Reset()
        {
            Score.LastScore = 0;
            _toastyGoal = 10;
        }

        private void ShowToasty()
        {
            if (Score.LastScore < _toastyGoal) return;
            OnToastyGoalReached?.Invoke();
            _toastyGoal += 10;
        }
    }
}
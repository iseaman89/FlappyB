using TMPro;
using UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameUI
    {
        public readonly InGameAnimation InGameAnimation;
        public Button PauseButton { get; private set; }
        public TextMeshProUGUI ScoreText { get; set; }

        public InGameUI(GameObject inGameWindow)
        {
            InGameAnimation = new InGameAnimation(inGameWindow);
            PauseButton = inGameWindow.GetComponentInChildren<Button>();
            ScoreText = inGameWindow.GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void Show()
        {
            InGameAnimation.Enter();
        }

        public void Hide()
        {
            InGameAnimation.Exit();
        }
    }
}
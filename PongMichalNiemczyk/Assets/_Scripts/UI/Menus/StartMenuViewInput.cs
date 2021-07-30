using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class StartMenuViewInput : MonoBehaviour, IStartMenuViewInputListener
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public Button StartButton
        {
            get => _startButton;
        }

        public Button QuitButton
        {
            get => _quitButton;
        }

        public void OnStartButtonClick()
        {
            throw new System.NotImplementedException();
        }

        public void OnQuitButtonClick()
        {
            throw new System.NotImplementedException();
        }
    }
}
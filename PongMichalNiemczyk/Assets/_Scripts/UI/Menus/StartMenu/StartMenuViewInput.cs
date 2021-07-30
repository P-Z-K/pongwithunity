using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI
{
    public class StartMenuViewInput : MonoBehaviour
    {
        private IStartMenuViewInputListener _startMenuViewInputListener;

        [Inject]
        public void Construct(IStartMenuViewInputListener startMenuViewInputListener)
        {
            _startMenuViewInputListener = startMenuViewInputListener;
        }

        public void OnStartButtonClick()
        {
            _startMenuViewInputListener.OnStartButtonClick();
        }

        public void OnQuitButtonClick()
        {
            _startMenuViewInputListener.OnQuitButtonClick();
        }
    }
}
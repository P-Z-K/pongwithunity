using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class StartMenuController : MonoBehaviour, IStartMenuViewInputListener
    {
        private StartMenuView _startMenuView;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(StartMenuView startMenuView, SignalBus signalBus)
        {
            _startMenuView = startMenuView;
            _signalBus = signalBus;
        }

        public void Show()
        {
            _startMenuView.Show();
        }


        public void Hide()
        {
            _startMenuView.Hide();
        }

        public void OnStartButtonClick()
        {
            _signalBus.Fire<StartButtonClickedSignal>();
        }

        public void OnQuitButtonClick()
        {
            _signalBus.Fire<QuitButtonClickedSignal>();
        }
    }
}
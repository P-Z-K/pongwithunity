using _Scripts.UI.Signals;
using Zenject;

namespace _Scripts.UI
{
    public class StartMenuController : IStartMenuViewInputListener
    {
        private readonly SignalBus _signalBus;
        private readonly StartMenuView _startMenuView;

        public StartMenuController(StartMenuView startMenuView, SignalBus signalBus)
        {
            _startMenuView = startMenuView;
            _signalBus = signalBus;
        }

        public void OnStartButtonClick() => _signalBus.Fire<StartButtonClickedSignal>();

        public void OnQuitButtonClick() => _signalBus.Fire<QuitButtonClickedSignal>();

        public void Show() => _startMenuView.Show();


        public void Hide() => _startMenuView.Hide();
    }
}
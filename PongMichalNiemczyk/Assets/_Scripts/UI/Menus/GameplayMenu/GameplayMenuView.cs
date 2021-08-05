using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerOneScoreText;
        [SerializeField] private TMP_Text _playerTwoScoreText;
        [SerializeField] private TMP_Text _countdownTimerText;

        public void UpdatePlayerOneScoreText(int points) => _playerOneScoreText.text = points.ToString();

        public void UpdatePlayerTwoScoreText(int points) => _playerTwoScoreText.text = points.ToString();

        public void UpdateCountdownTimerText(int seconds) => _countdownTimerText.text = seconds.ToString();

        public void ShowCountdownTimer() => _countdownTimerText.enabled = true;

        public void HideCountdownTimer() => _countdownTimerText.enabled = false;

        public bool IsCountdownTimerEnabled => _countdownTimerText.enabled;

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}
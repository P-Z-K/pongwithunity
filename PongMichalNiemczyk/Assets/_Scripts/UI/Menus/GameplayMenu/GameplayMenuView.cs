using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private Text _playerOneScoreText;
        [SerializeField] private Text _playerTwoScoreText;

        public void UpdatePlayerOneScoreText(int points)
        {
            _playerOneScoreText.text = points.ToString();
        }

        public void UpdatePlayerTwoScoreText(int points)
        {
            _playerTwoScoreText.text = points.ToString();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }


        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
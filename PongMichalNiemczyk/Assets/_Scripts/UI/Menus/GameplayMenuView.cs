using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private Text _playerOneScoreText;
        [SerializeField] private Text _playerTwoScoreText;
        

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public Text PlayerOneScoreText
        {
            get => _playerOneScoreText;
        }

        public Text PlayerTwoScoreText
        {
            get => _playerTwoScoreText;
        }
    }
}
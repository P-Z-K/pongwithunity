using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private Text _playerOneScoreText;
        [SerializeField] private Text _playerTwoScoreText;

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
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class GameplayMenuView : MonoBehaviour, IMenu
    {
        [SerializeField] private Text _playerOneScoreText;
        [SerializeField] private Text _playerTwoScoreText;


        public bool IsVisible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
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
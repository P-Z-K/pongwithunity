using UnityEngine;

namespace _Scripts.UI
{
    public class GameOverMenuView : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}
using UnityEngine;

namespace _Scripts.UI
{
    public class StartMenuView : MonoBehaviour
    {
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
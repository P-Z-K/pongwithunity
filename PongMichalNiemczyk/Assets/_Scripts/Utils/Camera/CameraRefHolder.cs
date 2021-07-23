using UnityEngine;

namespace _Scripts.Utils
{
    public class CameraRefHolder : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;

        public Camera MainCamera => _mainCamera;
    }
}
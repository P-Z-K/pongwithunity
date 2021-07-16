using UnityEngine;

namespace _Scripts.PongBat
{
    public class PongBatView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Rigidbody2D Rigidbody2D
        {
            get => _rigidbody2D;
        }
    }
}
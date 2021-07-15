using UnityEngine;

namespace _Scripts.PongBat
{
    public class PongBatView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Rigidbody2D Rigidbody2D
        {
            get => _rigidbody2D;
        }
    }
}
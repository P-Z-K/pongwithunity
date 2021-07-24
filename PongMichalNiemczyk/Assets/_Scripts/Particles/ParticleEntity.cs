using UnityEngine;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleEntity : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
    }
}
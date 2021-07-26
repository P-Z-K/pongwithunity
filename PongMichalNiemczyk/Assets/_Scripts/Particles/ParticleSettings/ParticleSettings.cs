using System;
using UnityEngine;

namespace _Scripts.Particles.ParticleSettings
{
    [Serializable]
    public class ParticleSettings
    {
        [SerializeField] private GameObject _wallHitParticle;
        [SerializeField] private GameObject _pongBatHitParticle;
        [SerializeField] private GameObject _ballFallPlayerHoleParticle;
    }
}
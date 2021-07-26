using _Scripts.Ball;
using _Scripts.Particles.ParticleTypes;
using _Scripts.Particles.ParticleTypes.BallParticle;
using _Scripts.Particles.ParticleTypes.PongBatParticle;
using UnityEngine;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleEntityManager
    {
        private SignalBus _signalBus;
        private WallHitParticleEntityPool _wallHitParticleEntityPool;
        private PongBatHitParticleEntityPool _pongBatHitParticleEntityPool;
        private BallFallIntoPlayerHoleParticleEntityPool _ballFallIntoPlayerHoleParticleEntityPool;

        public ParticleEntityManager(SignalBus signalBus,
            WallHitParticleEntityPool wallHitParticleEntityPool,
            PongBatHitParticleEntityPool pongBatHitParticleEntityPool,
            BallFallIntoPlayerHoleParticleEntityPool ballFallIntoPlayerHoleParticleEntityPool)
        {
            _signalBus = signalBus;
            _wallHitParticleEntityPool = wallHitParticleEntityPool;
            _pongBatHitParticleEntityPool = pongBatHitParticleEntityPool;
            _ballFallIntoPlayerHoleParticleEntityPool = ballFallIntoPlayerHoleParticleEntityPool;
        }

        public void SubscribeSignals()
        {
            _signalBus.Subscribe<BallHitWallSignal>(TEST_PlayWallHitParticle);
            _signalBus.Subscribe<BallHitPongBatSignal>(TEST_PlayPongBatHitParticle);
        }

        public void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<BallHitWallSignal>(TEST_PlayWallHitParticle);
            _signalBus.Unsubscribe<BallHitPongBatSignal>(TEST_PlayPongBatHitParticle);
        }

        private void TEST_PlayPongBatHitParticle(BallHitPongBatSignal obj)
        {
            throw new System.NotImplementedException();
        }

        private void TEST_PlayWallHitParticle(BallHitWallSignal obj)
        {
            _wallHitParticleEntityPool.Spawn(obj.BallPosition);
        }
    }
}
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
        private readonly SignalBus _signalBus;
        private readonly WallHitParticleEntityPool _wallHitParticleEntityPool;
        private readonly PongBatHitParticleEntityPool _pongBatHitParticleEntityPool;
        private readonly BallFallIntoPlayerHoleParticleEntityPool _ballFallIntoPlayerHoleParticleEntityPool;

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
            _signalBus.Subscribe<BallFellIntoPlayerHoleSignal>(TEST_PlayBallFallIntoPlayerHoleParticle);
        }

        public void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<BallHitWallSignal>(TEST_PlayWallHitParticle);
            _signalBus.Unsubscribe<BallHitPongBatSignal>(TEST_PlayPongBatHitParticle);
            _signalBus.Unsubscribe<BallFellIntoPlayerHoleSignal>(TEST_PlayBallFallIntoPlayerHoleParticle);
        }
        
        private void TEST_PlayBallFallIntoPlayerHoleParticle(BallFellIntoPlayerHoleSignal obj)
        {
            _ballFallIntoPlayerHoleParticleEntityPool.Spawn(obj.BallPosition);
        }

        private void TEST_PlayPongBatHitParticle(BallHitPongBatSignal obj)
        {
            _pongBatHitParticleEntityPool.Spawn(obj.BallPosition);
        }

        private void TEST_PlayWallHitParticle(BallHitWallSignal obj)
        {
            _wallHitParticleEntityPool.Spawn(obj.BallPosition);
        }
    }
}
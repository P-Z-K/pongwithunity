using System.Collections.Generic;
using System.Linq;
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
        private List<IParticleEntity> _particleEntities =
            new List<IParticleEntity>();

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

        public void Tick()
        {
            foreach (var entity in _particleEntities.ToList())
            {
                if (!entity.IsPlaying)
                {
                    ReturnEntityToPool(entity);
                }
            }
        }
        
        private void ReturnEntityToPool(IParticleEntity entity)
        {
            entity.Despawn();
            _particleEntities.Remove(entity);
        }

        public void SubscribeSignals()
        {
            _signalBus.Subscribe<BallHitWallSignal>(PlayWallHitParticle);
            _signalBus.Subscribe<BallHitPongBatSignal>(PlayPongBatHitParticle);
            _signalBus.Subscribe<BallFellIntoPlayerHoleSignal>(PlayBallFallIntoPlayerHoleParticle);
        }

        public void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<BallHitWallSignal>(PlayWallHitParticle);
            _signalBus.Unsubscribe<BallHitPongBatSignal>(PlayPongBatHitParticle);
            _signalBus.Unsubscribe<BallFellIntoPlayerHoleSignal>(PlayBallFallIntoPlayerHoleParticle);
        }

        private void PlayBallFallIntoPlayerHoleParticle(BallFellIntoPlayerHoleSignal obj)
        {
            IParticleEntity particle = _ballFallIntoPlayerHoleParticleEntityPool.Spawn(obj.BallPosition);
            AddToParticlesList(particle);
        }

        private void PlayPongBatHitParticle(BallHitPongBatSignal obj)
        {
            IParticleEntity particle =_pongBatHitParticleEntityPool.Spawn(obj.BallPosition);
            AddToParticlesList(particle);
        }

        private void PlayWallHitParticle(BallHitWallSignal obj)
        {
            IParticleEntity particle =_wallHitParticleEntityPool.Spawn(obj.BallPosition);
            AddToParticlesList(particle);
        }

        private void AddToParticlesList(IParticleEntity entity)
        {
            _particleEntities.Add(entity);
        }
    }
}
using System.Collections.Generic;
using _Scripts.Composite;
using _Scripts.PongBat;
using Zenject;

namespace _Scripts.Root
{
    public class PongBatComponent : PrimitiveComponent
    {
        [Inject] private List<PongBatFacade> _pongBatFacades = new List<PongBatFacade>();

        public override void Tick()
        {
            foreach (PongBatFacade pongBat in _pongBatFacades)
            {
                pongBat.Tick();
            }
        }

        public override void FixedTick()
        {
            foreach (PongBatFacade pongBat in _pongBatFacades)
            {
                pongBat.FixedTick();
            }
        }
    }
}
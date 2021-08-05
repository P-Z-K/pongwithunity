using _Scripts.Composite;
using _Scripts.Players;

namespace _Scripts.Root
{
    public class PointsTrackerComponent : PrimitiveComponent
    {
        private readonly PointsTracker _pointsTracker;

        public PointsTrackerComponent(PointsTracker pointsTracker)
        {
            _pointsTracker = pointsTracker;
        }

        public override void Enter()
        {
            _pointsTracker.ResetPoints();
        }
    }
}
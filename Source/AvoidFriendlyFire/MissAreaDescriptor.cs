using Verse;

namespace AvoidFriendlyFire
{
    public struct MissAreaDescriptor
    {
        public IntVec3[] AdjustmentVector;
        public int AdjustmentCount;

        public MissAreaDescriptor(IntVec3[] adjustmentVector, int adjustmentCount)
        {
            AdjustmentVector = adjustmentVector;
            AdjustmentCount = adjustmentCount;
        }
    }
}
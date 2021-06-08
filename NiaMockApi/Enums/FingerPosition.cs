using NiaMockApi.Attributes;

namespace NiaMockApi.Enums
{
    public enum FingerPosition
    {
        [StringValue("Right Thumb")]
        RT = 1,
        [StringValue("Right Index Finger")]
        RI,
        [StringValue("Right Middle Finger")]
        RM,
        [StringValue("Right Ring Finger")]
        RR,
        [StringValue("Right Little Finger")]
        RL,
        [StringValue("Left Thumb")]
        LT,
        [StringValue("Left Index Finger")]
        LI,
        [StringValue("Left Middle Finger")]
        LM,
        [StringValue("Left Ring Finger")]
        LR,
        [StringValue("Left Little Finger")]
        LL,
    }
}

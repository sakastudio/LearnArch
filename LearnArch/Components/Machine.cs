namespace LearnArch.Components;

public struct Machine
{
    public const float ProgressTime = 3;
    
    public MachineState State;
    public float RemainingTime;
}

public enum MachineState
{
    Idle,
    Processing,
}
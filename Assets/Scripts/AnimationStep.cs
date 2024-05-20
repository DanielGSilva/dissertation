using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateStep(float update);
public delegate void InitStep();
public delegate void FinishStep();
public delegate void FinalState();


public class AnimationStep
{
    private float duration;
    private bool isUpdated;
    public UpdateStep updateStep;
    public InitStep initStep;
    public FinishStep finishStep;
    public FinalState finalState;

    public AnimationStep() {
        this.isUpdated = false;
    }

    public AnimationStep(float duration)
    {
        this.isUpdated = true;
        this.duration = duration;
    }

    public float getDuration()
    {
        return duration;
    }
    
    public bool hasUpdate() {
        return isUpdated;
    }

    public void setUpdateStep(UpdateStep updateStep)
    {
        this.updateStep = updateStep;
    }

    public void setInitStep(InitStep initStep)
    {
        this.initStep = initStep;
    }

    public void setFinishStep(FinishStep finishStep)
    {
        this.finishStep = finishStep;
    }

    public void setFinalState(FinalState finalState)
    {
        this.finalState = finalState;
    }
}

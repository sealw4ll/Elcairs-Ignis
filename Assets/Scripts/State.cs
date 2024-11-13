using UnityEngine;

public abstract class State : MonoBehaviour 
{
    public bool isComplete = false;

    float startTime;

    float time => Time.time - startTime;

    public StateMachine machine;

    private State parent;

    public State state => machine.state;

    public void Set(State newState, bool forceReset = false) {
        machine.Set(newState, forceReset);
    }

    public void DoBranch() {
        Do();
        state?.DoBranch();
    }

    public void FixedDoBranch()
    {
        FixedDo();
        state?.FixedDoBranch();
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public void Initalize()
    {
        isComplete = false;
        startTime = Time.time;
        machine = new StateMachine();
    }
}

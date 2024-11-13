using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public playerScript player;

    public GroundState groundState;
    public AirState airState;
    public HurtState hurtState;

    private StateMachine stateMachine = new StateMachine();
    private State currentState => stateMachine.state;

    void Set(State newState, bool forceReset = false)
    {
        stateMachine.Set(newState, forceReset);
    }

    void Start()
    {
        PlayerState[] states = GetComponents<PlayerState>();
        foreach (PlayerState state in states)
        {
            state.SetUp(player);
        }
        stateMachine.Set(groundState);
    }

    void SelectState()
    {
        if (player.damaged)
        {
            Set(hurtState);
            return;
        }

        if (currentState.isComplete)
        {
            if (player.groundSensor.isGrounded)
            {
                Set(groundState);
            }
            else
            {
                Set(airState);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == null)
        {
            Debug.Log("not supposed to happen");
        }
        // List<State> states = stateMachine.GetActiveStateBranch();
        // Debug.Log("Active States: " + string.Join(" > ", states));
        SelectState();
        currentState.DoBranch();
    }

    private void FixedUpdate()
    {
        currentState.FixedDoBranch();
    }
}

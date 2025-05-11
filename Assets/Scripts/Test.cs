using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] StateManager stateManager;

    void Update()
    {
        //마우스를 누르는 동안 Walk, 마우스를 떼면 Idle
        EState finalState = Input.GetKeyDown(KeyCode.Space) ? EState.WALK : EState.IDLE;
        stateManager.TransitionTo(finalState);
    }
}
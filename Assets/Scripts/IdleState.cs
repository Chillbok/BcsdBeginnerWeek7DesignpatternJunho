using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    public override void Enter()
    {
        Debug.Log("IdleEnter");
    }

    public override void Exit()
    {
        Debug.Log("IdleExit");
    }
    public override void UpdateState()
    {
        Debug.Log("IdleUpdate");
    }
}
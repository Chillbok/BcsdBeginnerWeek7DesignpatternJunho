using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class WalkState : StateBase
{
    public override void Enter()
    {
        Debug.Log("WalkEnter");
    }
    public override void Exit()
    {
        Debug.Log("WalkExit");
    }
    public override void UpdateState()
    {
        Debug.Log("WalkUpdate");
    }
}
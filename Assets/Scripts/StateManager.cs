using System.Collections.Generic;
using UnityEngine;

public enum EState
{
    IDLE,
    WALK
}

public abstract class StateBase : MonoBehaviour
{
    public EState eState;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
}

public class StateManager : MonoBehaviour
{
    [SerializeField] EState curState;
    [SerializeField] StateBase[] stateBases;

    Dictionary<EState, StateBase> stateDic;

    public void TransitionTo(EState nextState)
    {
        if (curState == nextState) return;

        stateDic[curState].Exit();
        curState = nextState;
        stateDic[nextState].Enter();
    }

    void Awake()
    {
        stateDic = new();
        foreach (StateBase stateBase in stateBases)
        {
            stateDic.TryAdd(stateBase.eState, stateBase);
        }
        stateDic[curState].Enter();
    }

    void Update()
    {
        stateDic[curState].UpdateState();
    }
}

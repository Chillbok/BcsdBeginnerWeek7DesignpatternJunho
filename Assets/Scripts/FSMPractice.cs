using UnityEngine;

public class FSM
{
    private MonsterBaseState _currentState;

    public FSM(MonsterBaseState initState)
    {
        _currentState = initState;
        ChangeState(_currentState);
    }

    public void ChangeState(MonsterBaseState nextState)
    {
        if(nextState == _currentState)
            return;
        
        if(_currentState != null)
        {
            _currentState.OnStateEnd();
        }

        _currentState = nextState;
        _currentState.OnStateStart();
    }

    public void UpdateState()
    {
        _currentState?.OnStateUpdate();
    }
}

//몬스터의 상태와 관련된 추상 클래스
public abstract class MonsterBaseState
{
    private Monster _monster;

    protected MonsterBaseState(Monster monster)
    {
        _monster = monster;
    }

    //상태에 들어왔을 때 한 번 실행
    public abstract void OnStateStart();
    //상태에 있을 때 계속 실행
    public abstract void OnStateUpdate();
    //상태를 빠져나갈 때 한 번 실행
    public abstract void OnStateEnd();
}

//몬스터 상태를 정의한 코드
public class Monster : MonoBehaviour
{
    private enum MonsterStateEnum
    {
        IDLE,
        CHASE,
        ATTACK,
        DEATH
    }
    private MonsterStateEnum _state;

    private void Start()
    {
        _state = MonsterStateEnum.IDLE;
    }

    private void Update()
    {
        switch(_state)
        {
            case MonsterStateEnum.IDLE:
                break;
            case MonsterStateEnum.CHASE:
                break;
            case MonsterStateEnum.ATTACK:
                break;
            case MonsterStateEnum.DEATH:
                break;
            default:
                break;
        }
    }
}
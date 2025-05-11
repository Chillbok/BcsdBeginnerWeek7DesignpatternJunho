using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    START, //플레이 시작
    PLAYING, //플레이 도중
    PAUSED, //플레이 멈춤
    CLEAR //게임 클리어
}
public class LevelManager : MonoBehaviour
{
    //SingletonComponent의 객체가 몇개이든지 동일한 instance 변수를 공유함
    //private로 선언해 외부에서 함부로 수정할 수 없도록 만들기
    [SerializeField] GameObject player; //플레이어 프리팹 연결
    [SerializeField] GameObject goal; //도착지점 프리팹 연결
    [SerializeField] GameObject pauseScreen; //게임 멈춤 화면
    private static LevelManager instance;
    public GameState currentState; //현재 게임 상태 변수
    bool isPaused = false; //게임 멈추기 여부
    //Instance 컴포넌트 생성
    public static LevelManager Instance
    {
        //클래스 외부, 내부 모든 곳에서 호출하는 프로퍼티
        get
        {
            //instance를 가져가기 전 instance가 비어있는지 확인
            if (instance == null)
            {
                var obj = FindFirstObjectByType<LevelManager>();
                //SingletonComponent를 가지고 있는 게임 오브젝트가 존재한다면
                if(obj != null)
                { //그 객체를 instance에 넣어주기
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<LevelManager>(); //새로 생성한 게임 오브젝트에 SingletonComponent를 부착하고
                    instance = newObj; //instance 변수에 넣어주기
                }
            }
            return instance;
        }
    }

    //특정 scene으로 이동시키는 메서드
    private void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        //상태 초기화
        currentState = GameState.START;

        var objs = FindObjectsByType<LevelManager>(FindObjectsSortMode.None);
        //이미 존재하는지 중복 검사
        //이미 존재하는 경우에는 삭제해야 함
        if(objs.Length != 1) { //1개가 아니라면 같은 컴포넌트를 가진 다른 게임 오브젝트가 있다는 뜻
            Destroy(gameObject); //이미 instance에 할당되어 있을 확률이 높으므로 방금 생성한 objs 객체 파괴
            return;
        }
        //Scene이 바뀌어도 SingletonComponent가 부착된 개체가 사라지지 않도록 만들기
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        switch(currentState)
        {
            case GameState.START:
                //게임 시작 상태일 때 할 일
                HandleStartState();
                break;
            case GameState.PLAYING:
                //플레이 도중 상태일 때 할 일
                HandlePlayingState();
                break;
            case GameState.PAUSED:
                //플레이 멈춤 상태일 때 할 일
                HandlePausedState();
                break;
            case GameState.CLEAR:
                //게임 클리어 상태일 때 할 일
                HandleClearState();
                break;
        }
    }

    void HandleStartState()
    {
        //currentState 상태 확인하고, START 아닌 경우에만 START로 바꾸기
        if(currentState == GameState.START)
            return;
        else
            currentState = GameState.START;

        //게임 시작
        LoadNextScene("Level0");
    }
    void HandlePlayingState()
    {
        if(currentState == GameState.PLAYING)
            return;
        else
            currentState = GameState.PLAYING;

        if(isPaused)
            isPaused = false;
        
        if(Input.GetKeyDown(KeyCode.Escape))
            PauseScreenToggle();
    }
    //게임 일시 중지 시 실행할 내용
    void HandlePausedState()
    {
        if(currentState == GameState.PAUSED)
            return;
        else
            currentState = GameState.PAUSED;
        
        if(!isPaused)
            isPaused = true;
        
        if(Input.GetKeyDown(KeyCode.Escape))
            PauseScreenToggle();
    }
       //게임 클리어 시 실행할 내용
    void HandleClearState()
    {
        LoadNextScene("Level1");
    }
    
    void PauseScreenToggle()
    {
        //게임 실행 중에 ESC 누르면
        if(!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f; //시간 멈추기
            PauseImageToggle(true); //일시정지 이미지 켜기
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f; //시간 다시 움직이기
            PauseImageToggle(false); //일시정지 이미지 끄기
        }
    }

    //일시정지 이미지 활성화 비활성화 메서드
    void PauseImageToggle(bool isVisible)
    {
        pauseScreen.SetActive(isVisible); //GameObject 활성화/비활성화
        Debug.Log("GameObject 활성화");
    }

}
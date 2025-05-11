using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //SingletonComponent의 객체가 몇개이든지 동일한 instance 변수를 공유함
    //private로 선언해 외부에서 함부로 수정할 수 없도록 만들기
    [SerializeField] int startLevel = 0;
    private static LevelManager instance;
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
}
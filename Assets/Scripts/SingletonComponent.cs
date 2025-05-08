using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    //new 연산자를 통해서 생성되는 일반 C# 클래스의 객체와 달리 컴포넌트 클래스의 객체를 생성할 때는 게임 오브젝트를 생성한 다음에 AddComponent 함수를 이용해서 게임 오브젝트에 붙여줘야 한다.
    void Start()
    {
        //static으로 선언된 변수는 SingletonComponent의 객체가 몇 개이던지 이 변수는 단 하나로 모든 SingletonComponent들이 공유하게 된다.
        //instance가 비어있으면 정식으로 생성된 SingletonComponent의 객체가 없다는 뜻이므로 새 인스턴스를 생성해서 채워주고
        //이미 instance 안에 무언가가 채워져 있으면 그 이후에 생성된 객체는 부정한 객체이므로 삭제되어야 한다.
        private static SingletonComponent instance;
        
        //싱글톤 프로퍼티 추가
        //맨 앞글자를 대문자로 해서 private로 선언한 instance 변수와 차이 둠
        public static SingletonComponent Instance
        //이 instance는 클래스 내부와 외부, 모든 곳에서 호출하는 프로퍼티
        {
            get //getter 만들기
            {
                //instance가 비어 있는지 검사
                if (instance == null)
                {
                    var obj = FindObjectOfType
                }
            }
        }
    }
}
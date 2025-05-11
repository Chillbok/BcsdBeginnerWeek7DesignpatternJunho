using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonClass
{
    //클래스의 객체를 생성할 때 쓰이는 생성자
    //모든 생성자를 private로 선언해서 함부로 접근하지 못하게 함
    //객체를 하나만 생성 가능하도록 한정함
    private SingletonClass() { } //private로 선언해 클래스 외부에서 함부로 객체를 만들 수 없게 만들기

    private static SingletonClass instance; //이 변수에 넣어둔 객체만 꺼내서 사용할 예정
    public static SingletonClass Instance //Instance 프로퍼티 호출
    {
        get
        {
            //static인 instance 변수 비어있는지 검사
            if(instance == null) //비어있는 경우
            {
                //새 객체 생성해서 instance 변수에 넣어주기
                instance = new SingletonClass();
            }
        }
    }
}
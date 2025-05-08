//Monobehaviour를 상속받지 않는 일반 C# 클래스에서 싱글톤 패턴 사용하는 방법
public class SingletonClass
{
    //클래스의 객체를 생성할 때 쓰이는 생성자를 private로 선언
    //클래스의 외부에서 함부로 객체를 만들 수 없게 만들자
    //객체를 하나만 생성 가능하게 만드는 것
    private SingletonClass() { }

    //instance 변수에 넣어둔 객체만을 꺼내서 사용
    private static SingletonClass instance;

    public static SingletonClass Instance
    {
        get
        {
            //static인 instance 변수가 비어있는지 검사
            if(instance == null)
            {
                //비어 있는 경우에만 새 객체를 생성해서 instance 변수에 넣기
                instance = new SingletonClass();
            }
            return instance;
        }
    }
}

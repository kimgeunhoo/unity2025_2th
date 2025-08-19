using System.Collections;
using System.Collections.Generic;

public class PropertyExample
{
    // 멤버 변수, 멤버 함수

    private int hp; //

    // 프로퍼티 사용 형태 (1)
    public int HP { get; set; }
    public int ATK { get; set; }

    // 프로퍼티 사용 형태 (2)
    public int HP2 { 
        get 
        { 
            if (hp <= 0)
            {
                hp = 0;
            }
            return hp; 
        } set {
            hp = value; 
        } 
    }

    // 프로퍼티 사용법 3
    public int DEF { get; set; } // 외부에서 값을 변경하지 마시오

    public int MAxLevel { get; private set; } // 게임 시작할 때 최대 레벨을 설정. 다른 클래스에서 변경할 수 없도록 설정


    /*
        프로퍼티(Property)
        사용법 : 변수 선언 public (타입) (변수 이름) 첫 글자를 대문자로 작성하는 것이 이름 규칙
        public int HP {get; set;}
    */

    /// <summary>
    /// hp를 절반으로 변경해주는 코드, 반드시 이 함수를 사용해서 HP 조절
    /// </summary>
    public void UseThisFunction()
    {
        // hp가 어떤 시스템에 의해서 변경된다.

        hp /= 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    ScriptableObject 왜 사용하는가?
    데이터의 메모리가 어떻게 사용되는가
    GameObject 객체를 생성해서 컴포넌트를 부착, 
    모든 객체가 그 클래스의 데이터타입만큼의 메모리를 컴퓨터에 할당한다
    공통적으로 사용하는 데이터를 한 번만 사용할 수 있게 할수 없을까?
    같은 데이터를 모든 오브젝트가 개별로 생성하고 있다. => 이 데티어를 사용하는 모든 오브젝트가 참조하도록 하면 된다.
    디자인 패턴 : flyweight 패턴
    단점 : 사용할 때 유의할 점. 참조하고 있는 데이터를 수정하면 다른 오브젝트들도 모두 변경된다.
    - 깊은 복사, 얕은 복사
    
*/
namespace Example
{
    [CreateAssetMenu(fileName = "Default Monster Name", menuName = "ScriptableObject/MonsterData", order = 100)]
    public class MonsterInfo : ScriptableObject
    {
        public float moveSpeed; // 몬스터가 움직이는 속도
        public Sprite sprite;
        public float Size;
        public string monsterName;
        public Collider2D collider;
        public Color color;

    } 
}

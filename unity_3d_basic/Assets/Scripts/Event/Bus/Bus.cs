using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이벤트를 총괄적으로 관리하는 특별한 클래스
// Generic Coding (T) 어떠한 클래스도 올 수 있다.
// where 클래스가 IEvent 상속한 경우만 <> 들어올 수 있다.
public class Bus<T> where T : IEvent  
{
    public delegate void Event(T evt);
    public static event Event OnEvent;
    public static void Raise(T evt) => OnEvent?.Invoke(evt); // 람다 표현식 (중괄호 생략)

}

public interface IEvent
{

}

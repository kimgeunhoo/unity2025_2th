using UnityEngine;

public class AnotherClass : MonoBehaviour
{
    PropertyExample example;

    public void Test()
    {
        example.UseThisFunction();

        example.HP = 10;

        int maxHP = example.HP;
    }

    private void Start()
    {
        example = new();

        Test();
    }
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager>
{
    ObjectGenerator generator = new ObjectGenerator();

    void Start()
    {
        StartCoroutine(Main());
    }

    void Init()
    {
        //고양이 두마리 생성
    }

    IEnumerator Main()
    {
        generator.Generate(); //생선, 황금 생성, 폭탄 생성
        yield return null;
    }
}

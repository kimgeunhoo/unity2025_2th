using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // 특정 시점, 특정 이벤트가 발생되고 나서 몬스터 생성

    [Header("몬스터 생성 정보")]
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject[] spawnMonsters;
    [SerializeField] int spawnCount = 5;
    [SerializeField] float spawnIntervalTime = 0.75f;
    private Coroutine spawnCoroutine;
    

    // Start is called before the first frame update
    void Start()
    {
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Spawn();
        }
    }

    /// <summary>
    /// 게임 월드에 특정 위치에 몬스터를 생성하는 데, 몇마리를 생성할까
    /// 한번에 몬스터가 등장할 것인가, 시간 걸쳐서 생성할 것인가
    /// 유니티에서 함수 이름이 Spawn이고 위의 두 줄의 기능을 하는 함수를 만들기
    /// </summary>
    public void Spawn()
    {
        if (spawnCoroutine != null) 
        {
            StopCoroutine(SpawnCoroutine());
        }
        spawnCoroutine = StartCoroutine(SpawnCoroutine());
        //StartCoroutine("SpawnCoroutine"); // << string 메서드 이름을 가져올 때 문제점 : 철자, 대소문자 틀리면 어디서 문제가 발생했는지 찾기 어렵다
        //StartCoroutine(nameof(SpawnCoroutine)); // string 으로 가져올 때는 nameof가 적절하다
        // 두 방식 중에 어떤 코루틴 호출 방식을 사용해야 하나?
        // 두 방식 중 원하는것 사용을 하나, 방식을 하나로 통일할 것
    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spawnPositions.Length);
            int randomMonsterIndex = UnityEngine.Random.Range(0, spawnMonsters.Length);


            Instantiate(spawnMonsters[randomMonsterIndex], spawnPositions[randomIndex]);

            // interval 시간 후에 위 코드를 다시 실행하라
            yield return new WaitForSeconds(spawnIntervalTime);
        }
    }

}

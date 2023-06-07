using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbulb_K : MonoBehaviour
{
    public GameObject bulb; 
    public int bulbcount = 6; 

    private int clearnum = 0; // 파괴된 게임 오브젝트 수

    private void Start()
    {
        SpawnObject(); // 시작할 때 초기 오브젝트 생성
    }

    private void Update()
    {
        // 예를 들어, 특정 키를 입력받아 게임 오브젝트를 파괴하는 로직
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyObject();
        }
    }

    private void SpawnObject()
    {
        if (clearnum < bulbcount)
        {
            Instantiate(bulb, transform.position, Quaternion.identity);
        }
    }

    private void DestroyObject()
    {
        // 오브젝트를 파괴할 때마다 destroyedObjects 값 증가
        clearnum++;

        if (clearnum <= bulbcount)
        {
            SpawnObject(); // 파괴 후에 새로운 오브젝트 생성
        }
    }
}

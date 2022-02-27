using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour 
{
    public Transform target; // 목표가 될 트랜스폼 컴포넌트

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position; //카메라 위치 좌표에 특정한 게임 오브젝트의 위치 좌표를 넣으면 됨

    }
}

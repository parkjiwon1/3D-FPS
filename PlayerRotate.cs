using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    float mx = 0; // 캐릭터는 좌우 회전만 하면 되므로 좌우 회전에 대한 x축만 cam에서 복사

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X"); //마우스를 좌우로 회전 입력 받는 X

        mx += mouse_X * rotSpeed * Time.deltaTime; // 회전 값 변수에 마우스 입력 값만큼 미리 누적시킨다.

        transform.eulerAngles = new Vector3(0, mx, 0); // 좌우만 회전
    }
}

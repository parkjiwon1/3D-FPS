using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f; //물체의 회전 속도

    float mx = 0;
    float my = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X"); //마우스를 좌우로 회전 입력 받는 X
        float mouse_Y = Input.GetAxis("Mouse Y"); //마우스를 상하로 회전 입력 받는 Y

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime; // 회전 값 변수에 마우스 입력 값만큼 미리 누적시킴

        my = Mathf.Clamp(my, -90f, 90f); //미리 누적시킨 my(상하)를 -90~90도 사이로 제한

        transform.eulerAngles = new Vector3(-my, mx, 0); //물체를 회전 방향으로 회전 시킴

    }
}

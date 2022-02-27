using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;

    CharacterController cc; // 캐릭터 컨트롤러 변수 선언

    float gravity = -20f; //중력 값

    float yVelocity = 0; //수직 속력 변수

    public float jumpPower = 10f; //점프력 변수

    public bool isJumping = false; //한 번만 점프가 되게 도와주는 함수

    public float hp = 15f;

    public void DamageAction(int damage) //플레이어 피격 함수
    {
        hp -= damage; //에너미의 공격력만큼 플레이어의 체력을 깎음
    }

    void Start()
    {
        cc = GetComponent<CharacterController>(); // 캐릭터 컨트롤러 컴포넌트를 cc로 불러옴
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        dir = dir.normalized; // 방향의 크기 1로 만듦

        dir = Camera.main.transform.TransformDirection(dir); // transform 컴포넌트가 붙어있는 게임 오브젝트를 기준으로 상대 방향 벡터로 변환시켜줌
        
        if (cc.collisionFlags == CollisionFlags.Below)// 만약 다시 바닥에 착지했다면
        {
            if (isJumping) //만약 점프 중이었다면
            {
                isJumping = false; //다시 점프 전 상태로 초기화

                yVelocity = 0; //캐릭터 수직속도도 0으로 초기화
            }
        }

        if (Input.GetButtonDown("Jump") && !isJumping) //만일 키보드 스페이스바를 눌렀고 점프 중이 아니라면
        {
            yVelocity = jumpPower; //점프 파워를 y축속력에 저장
            isJumping = true;
        }

        yVelocity += gravity * Time.deltaTime; // 캐릭터 수직 속도에 중력값을 적용

        dir.y = yVelocity; //방향의 y축에 중력 힘 작용

        cc.Move(dir * moveSpeed * Time.deltaTime); //Move함수로 움직임 구현
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 오브젝트를 삭제한다
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        
        // 충돌 판정
        //Vector2 p1 = transform.position;              // 화살의 중심 좌표
        //Vector2 p2 = this.player.transform.position;  // 플레이어의 중심 좌표
        //Vector2 dir = p1 - p2;
        //float d = dir.magnitude;
        //float r1 = 0.5f;  // 화살 반경
        //float r2 = 1.0f;  // 플레이어 반경

        //if (d < r1 + r2)
        {
            // 감독 스크립트에 플레이어와 화살이 충돌했다고 전달한다 
            //GameObject director = GameObject.Find("GameDirector");
            //director.GetComponent<GameDirector>().DecreaseHp();

            // 충돌했다면 화살을 지운다
            //Destroy(gameObject);
        }
    }

    // 화살 도착
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("아얏");

        // 감독 스크립트에 플레이어와 화살이 충돌했다고 전달한다 
        GameObject director = GameObject.Find("GameDirector");
        

        // 2. 찾은 게임 오브젝트에 붙어있는 <GameDirector> 스크립트 컴포넌트를 가져옵니다.
        GameDirector directorScript = director.GetComponent<GameDirector>();

        // 감독에게 플레이어가 무적이 아닐 때만 HP를 감소시키라고 전달
        if (directorScript.isInvincible == false)
        {
            directorScript.DecreaseHp();
        }

        // 충돌했다면 화살을 지운다
        Destroy(gameObject);
    }

}

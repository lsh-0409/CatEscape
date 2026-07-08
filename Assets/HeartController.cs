using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    void Update()
    {
        // 아래로 천천히 떨어지게 함 (화살보다 느리게)
        transform.Translate(0, -0.05f, 0);

        // 화면 밖으로 나가면 스스로 파괴
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    // 플레이어와 충돌했을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        // GameDirector를 찾아서 IncreaseHp 함수를 호출
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().IncreaseHp();

        // HP를 회복시키고 스스로 파괴
        Destroy(gameObject);
    }
}
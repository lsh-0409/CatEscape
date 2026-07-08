using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    void Update()
    {
        // 아래로 천천히 떨어짐
        transform.Translate(0, -0.05f, 0);

        // 화면 밖으로 나가면 파괴
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    // 플레이어와 충돌했을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        // GameDirector를 찾아서 무적 활성화 함수를 호출
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().ActivateInvincibility();

        // 아이템은 즉시 파괴
        Destroy(gameObject);
    }
}
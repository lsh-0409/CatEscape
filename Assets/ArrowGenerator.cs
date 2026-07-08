using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;
    float gameTimer = 0;

    // 모든 화살이 공유할 '낙하 속도' 변수 (static으로 선언)
    public static float arrowSpeed = 0.1f;

    // 게임이 다시 시작될 때 속도를 초기화하기 위함
    void Start()
    {
        arrowSpeed = 0.1f;
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        this.gameTimer += Time.deltaTime;

        // 10초마다
        if (gameTimer > 5.0f)
        {
            gameTimer = 0; // 타이머 리셋

            // 생성 주기를 0.05초씩 짧게 만듦 (최소 0.3초)
            if (span > 0.3f)
            {
                span -= 0.05f;
            }

            // 낙하 속도를 0.02씩 증가시킴 (최대 0.5)
            if (arrowSpeed < 0.5f)
            {
                arrowSpeed += 0.02f;
            }
        }

        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
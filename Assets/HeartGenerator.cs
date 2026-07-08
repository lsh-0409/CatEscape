using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGenerator : MonoBehaviour
{
    public GameObject heartPrefab; // 하트 Prefab을 연결할 변수
    float span = 2.0f; // 생성 간격 (2초)
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            // 1초에서 10초 사이의 랜덤한 시간 뒤에 다음 하트가 나오도록 설정
            span = Random.Range(1.0f, 10.0f);

            GameObject go = Instantiate(heartPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
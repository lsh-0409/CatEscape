using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionGenerator : MonoBehaviour
{
    public GameObject potionPrefab;
    float span = 4.0f; // 생성 간격
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            // 5초에서 10초 사이 랜덤한 시간 뒤에 다음 물약 생성
            span = Random.Range(5.0f, 10.0f);

            GameObject go = Instantiate(potionPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
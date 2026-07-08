using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가한다
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro를 사용하기 위해 추가!

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;

    // --- 점수 기능 추가 ---
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    private float score = 0f;         // 점수를 저장할 변수
    // --------------------
    public bool isInvincible = false; // 무적 상태인지 확인하는 변수


    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    void Update()
    {
        // --- 점수 기능 추가 ---
        // 매 초마다 점수가 1씩 오름 (더 빨리 올리고 싶으면 * 10 등을 추가)
        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + (int)score; // 소수점은 버리고 정수로 표시
        // --------------------
    }


    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;

        // 체력이 0이 되면 게임 오버
        if (this.hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            // 게임을 멈추고 싶다면 여기에 Time.timeScale = 0f; 를 추가할 수 있습니다.
            // Time.timeScale = 0f; 
            SceneManager.LoadScene("ClearScene");
        }
    }

    // 추가 hp회복 함수 ---
    public void IncreaseHp()
    {
        // HP 게이지를 0.1만큼 채운다
        this.hpGauge.GetComponent<Image>().fillAmount += 0.1f;
        // fillAmount가 1.0f를 넘어가지 않도록 방지할 수 있지만, 일단 간단하게 구현
    }

    // 물약을 먹었을 때 호출할 함수
    public void ActivateInvincibility()
    {
        // 이미 무적 상태가 아니라면 코루틴 실행
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    // 3초 무적을 처리할 코루틴
    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;  // 1. 무적 상태로 만든다
        Debug.Log("무적 시작!");

        // 플레이어의 SpriteRenderer를 가져옴
        SpriteRenderer playerRenderer = GameObject.Find("player").GetComponent<SpriteRenderer>();

        // 0.2초 간격으로 15번 깜빡이게 함 (총 3초)
        for (int i = 0; i < 15; i++)
        {
            playerRenderer.enabled = false; // 숨기기
            yield return new WaitForSeconds(0.1f);
            playerRenderer.enabled = true; // 보이기
            yield return new WaitForSeconds(0.1f);
        }

        isInvincible = false; // 3. 무적 상태를 해제한다
        Debug.Log("무적 종료!");
    }

}

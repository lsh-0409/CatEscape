using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Scene 관리를 위해 필수!

public class RestartButton : MonoBehaviour
{
    // 버튼을 클릭했을 때 호출될 함수
    public void RestartGame()
    {
        // "GameScene"을 다시 불러옵니다.
        // 만약 메인 게임 씬의 이름이 다르다면 그 이름으로 바꿔주세요.
        SceneManager.LoadScene("GameScene");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test06_UI : testbase
{
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        int score = 100;

        // �̸����� ã��
        //GameObject obj = GameObject.Find("ScoreText");  // ����õ : ���ڿ��� �˻�, �̸��� �ߺ��Ǹ� �߸�ã�� �� ����

        // �±׷� ã��
        //GameObject obj = GameObject.FindGameObjectWithTag("Test");      // ���� �±� �� �ϳ��� ã��
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("Test");  // ���� �±� ��� ã��
        // GameObject.FindWithTag;  // ���ο��� FindGameObjectWithTag ȣ��
        //Debug.Log(obj.name);

        // ������Ʈ Ÿ������ ã��(Ư�� ������Ʈ�� ����)
        //ScoreText scoreText = FindObjectOfType<ScoreText>();    // �ϳ��� ã��
        //ScoreText[] scoreTexts = FindObjectsByType<ScoreText>(FindObjectsInactive.Include, FindObjectsSortMode.None); // ���� ���� ��� ã��
        //FindAnyObjectByType<ScoreText>();   // �ϳ��� ã��(FindAnyObjectByType���� ����)
        //FindFirstObjectByType<ScoreText>(); // ù��°�� ã��(�ӵ��� ����, ������ �߿��Ҷ� ���)

        ScoreText scoreText = FindAnyObjectByType<ScoreText>();
        scoreText.AddScore(score);
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        int score = 1000;
        ScoreText scoreText = FindAnyObjectByType<ScoreText>();
        scoreText.AddScore(score);
    }
}

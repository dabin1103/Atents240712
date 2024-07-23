using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    /// <summary>
    /// ������ �ö󰡴� �ּ� �ӵ�(�ʴ�)
    /// </summary>
    public float scoreUpMinSpeed = 50.0f;

    [Range(1.0f, 10.0f)]    // ������ ������ ���� ���� ������ ������ �� �ְ� ���ִ� attribute
    /// <summary>
    /// ���� ���� �ӵ� �����
    /// </summary>
    public float scoreUpSpeedModifier = 5.0f;

    /// <summary>
    /// ���� ��¿� UI
    /// </summary>
    TextMeshProUGUI score;

    /// <summary>
    /// ���� ����
    /// </summary>
    int goalScore = 0;

    /// <summary>
    /// ���̴� ����
    /// </summary>
    float displayScore = 0.0f;

    /// <summary>
    /// ���� Ȯ�ο� ������Ƽ(�б� ����)
    /// </summary>
    public int Score
    {
        get => goalScore;
        private set     // private������ ���� ����
        {
            goalScore = value;
            //score.text = $"Score : {goalScore,5}";    //5�ڸ��� ���, ������ �����̽�
            //score.text = $"Score : {goalScore:d5}";     //5�ڸ��� ���, ������ 0���� ä���
            //score.text = $"{goalScore}";
        }
    }

    private void Awake()
    {
        Transform child = transform.GetChild(1);
        score = child.GetComponent<TextMeshProUGUI>();

        //GetComponents<testbase>();    // �� ���� ������Ʈ�� ����ִ� ��� testbase ã��
        //TextMeshProUGUI[] result = GetComponentsInChildren<TextMeshProUGUI>();    // �ڽŰ� �ڽ��� ��� �ڽĿ� ����ִ� TextMeshProUGUI ã��

    }

    // �ǽ�
    // 1. ������ �ٷ� ����Ǵ� ���� �ƴ϶� õõ�� �����ǰ� ������
    // 2. ���̴� ������ ���� ������ ���̰� ũ�� Ŭ���� ������ �����Ѵ�.
    void Update()
    {
        // displayScore�� goalScore�� �� ������ ��� ������Ű��
        if (displayScore < goalScore)
        {
            // displayScore�� goalScore���� �۴�.

            // ���� �ӵ� ����(goalScore�� displayScore�� ���̰� ũ�� Ŭ���� ������ ����, �ּ�ġ�� scoreUpMinSpeed)
            float speed = Mathf.Max((goalScore - displayScore) * scoreUpSpeedModifier, scoreUpMinSpeed);

            displayScore += Time.deltaTime * speed; // �ӵ��� ���� displayScore ����

            displayScore = Mathf.Min(displayScore, goalScore);  // displayScore�� goalScore�� ���� ���ϰ� ����

            // UI�� ����ϱ�
            //score.text = displayScore.ToString();  // �Ʒ��� ���� �ڵ�
            //score.text = $"{displayScore}";
            //score.text = $"{(int)displayScore }";   // ĳ�������� �Ҽ��� �����ϱ�
            //score.text = displayScore.ToString("f0");  // �Ʒ��� ���� �ڵ�
            score.text = $"{displayScore:f0}";           // �Ҽ��� �����ϱ�(�������� ����)
        }
    }

    /// <summary>
    /// ������ ������Ű�� �Լ�
    /// </summary>
    /// <param name="point">������ų ��</param>
    public void AddScore(int point)
    {
        Score += point;
    }
}

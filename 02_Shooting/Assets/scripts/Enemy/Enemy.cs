using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    public float moveSpeed = 3.0f;

    /// <summary>
    /// ���� �׷����� �ѹ� �պ��ϴµ� �ɸ��� �ð� ������(Ŀ������ �պ� �ӵ��� ��������)
    /// </summary>
    public float frequency = 2.0f;

    /// <summary>
    /// ���� �׷����� ������� ������Ű�� ��(��, �Ʒ� �����̴� ����)
    /// </summary>
    public float amplitude = 3.0f;

    /// <summary>
    /// ����� ������ ����Ʈ
    /// </summary>
    public GameObject explosionEffect;

    /// <summary>
    /// �ð� ������ ����
    /// </summary>
    float elapsedTime = 0.0f;

    /// <summary>
    /// ���� ��ġ �����(������ ��ġ)
    /// </summary>
    float spawnY = 0.0f;

    /// <summary>
    /// ���� HP
    /// </summary>
    int hp = 2;

    /// <summary>
    /// ���� HP�� get/set�� �� �ִ� ������Ƽ
    /// </summary>
    public int HP
    {
        //get
        //{
        //    return hp;
        //}
        get => hp;          // �б�� public
        private set         // ����� private
        {
            hp = value;
            if (hp < 1)     // 0�� �Ǹ�
            {
                OnDie();    // ��� ó�� ����
            }
        }
    }

    /// <summary>
    /// ���� ���θ� ǥ���ϴ� ����
    /// </summary>
    bool isAlive = true;

    /// <summary>
    /// �� ���� �׿��� �� ��� ����
    /// </summary>
    public int point = 10;

    // �ǽ�
    // 1. ��� ������ �������� �����δ�.
    // 2. ���Ʒ��� ����ġ���� �����δ�.

    private void Start()
    {
        // Mathf : ����Ƽ ���п� Ŭ����

        spawnY = transform.position.y;      // ���� ��ġ ����ϱ�
    }

    private void Update()
    {
        MoveUpdate(Time.deltaTime);         // �̵� ������Ʈó��
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hp--;
        //if (hp <= 0)
        //{
        //    OnDie();
        //}
        HP--;       //HP = HP - 1;  // HP�� get�� ���� -1�� ó���ϰ� �ٽ� set�ϱ�
    }

    /// <summary>
    /// �̵� ó���� �ϴ� �Լ�
    /// </summary>
    /// <param name="deltaTime"></param>
    void MoveUpdate(float deltaTime)
    {
        elapsedTime += deltaTime * frequency;    // frequency��ŭ ������ �ð��� ����

        // �� ��ġ ����
        transform.position = new Vector3(
            transform.position.x - deltaTime * moveSpeed,   // ���� x��ġ���� ���� ����
            spawnY + Mathf.Sin(elapsedTime) * amplitude,    // ������ġ���� sin*amplitude �����ŭ ����
            0.0f);
    }

    /// <summary>
    /// ���� ���� �� ����� �Լ�
    /// </summary>
    void OnDie()
    {
        if (isAlive) // ������� ���� ���� �� ����
        {
            isAlive = false;    // �׾��ٰ� ǥ��

            ScoreText scoreText = FindAnyObjectByType<ScoreText>();
            scoreText.AddScore(point);   // ���� ����

            Instantiate(explosionEffect, transform.position, Quaternion.identity);  // ������ ����Ʈ ������
            Destroy(gameObject);    // �ڱ� �ڽ� ����
        }
    }
}

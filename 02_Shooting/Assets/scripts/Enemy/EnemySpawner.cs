using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // �ǽ�
    // 1. ���� �ð� �������� ���� �����Ѵ�.
    // 2. �����Ǵ� ������ ȭ�� ������ ��

    /// <summary>
    /// ������ ���� ������
    /// </summary>
    public GameObject enemyPrefab;

    /// <summary>
    /// �� ���� �ð�����
    /// </summary>
    public float spawnInterval = 1.0f;

    /// <summary>
    /// �ּ� ����
    /// </summary>
    const float MinY = -4;

    /// <summary>
    /// �ִ� ����
    /// </summary>
    const float MaxY = 4;

    
    // float elapedTime = 0.0f;

    private void Start()
    {
        // elapedTime = 0;
        StartCoroutine(SpawnCoroutine());   // �ڷ�ƾ ����

        //Time.timeScale = 0.1f;        // ���� ����Ǵ� �ð��� ������ (1�� �� ���� �ӵ�)
    }

    //private void Update()
    //{
    //    elapedTime += Time.deltaTime;
    //    if (elapedTime > spawnInterval)
    //    {
    //        elapedTime = 0.0f;
    //        Spawn();
    //    }
    //}

    /// <summary>
    /// ���� �ֱ������� �����ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Spawn();
        }
    }

    /// <summary>
    /// ���� �ϳ� �����ϴ� �Լ�
    /// </summary>
    void Spawn()
    {
        Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
    }

    /// <summary>
    /// ������ ��ġ�� �����ִ� �Լ�
    /// </summary>
    /// <returns>������ ��ġ</returns>
    Vector3 GetSpawnPosition()
    {
        Vector3 result = transform.position;
        result.y = Random.Range(MinY, MaxY);
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 p0 = transform.position + Vector3.up * MaxY;
        Vector3 p1 = transform.position + Vector3.up * MinY;
        Gizmos.DrawLine(p0, p1);
    }

    
    private void OnDrawGizmosSelected()
    {
        // ������ �簢�� �׸���(����1, ���� 8)
        Gizmos.color = Color.red;

        //new Color(1, 1, 1); // ���
        //new Color(1, 0, 0); // ������
        //new Color(0, 1, 0); // ���
        //new Color(0, 0, 1); // �Ķ���

        Vector3 p0 = transform.position + MaxY * Vector3.up + 0.5f * Vector3.left;
        Vector3 p1 = transform.position + MaxY * Vector3.up + 0.5f * Vector3.right;
        Vector3 p2 = transform.position + MaxY * Vector3.up + 0.5f * Vector3.right;
        Vector3 p3 = transform.position + MaxY * Vector3.up + 0.5f * Vector3.left;
        Gizmos.DrawLine(p0, p1);
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p0);
    }
}

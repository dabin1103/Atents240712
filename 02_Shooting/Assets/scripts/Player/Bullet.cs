using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// �Ѿ��� �̵��ӵ�
    /// </summary>
    public float moveSpeed = 7.0f;

    /// <summary>
    /// �Ѿ��� ����
    /// </summary>
    public float lifeTime = 10.0f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // �ǽ�
    // 1. ������ �����ϸ� �Ѿ��� ������ ���������� ��� ���ư��� �����

    private void Update()
    {
        // �� ��ġ���� �ʴ� moveSpeed �ӵ���, �� ������ �������� �̵��ϱ�
        //transform.position += (Time.deltaTime * moveSpeed * transform.right);

        // �ʴ� moveSpeed �ӵ���, ���� �������� �� ������ �������� �̵��ϱ�
        //transform.Translate(Time.deltaTime * moveSpeed * transform.right, Space.World);

        // �ʴ� moveSpeed �ӵ���, ���� �������� ������ �������� �̵��ϱ�
        //transform.Translate(Time.deltaTime * moveSpeed * Vector3.right, Space.self);

        // �ʴ� moveSpeed �ӵ���, ���� �������� ������ �������� �̵��ϱ�
        //transform.Translate(Time.deltaTime * moveSpeed * Vector3.right);

        // �ʴ� moveSpeed �ӵ���, ���� �������� ������ �������� �̵��ϱ�
        transform.Translate(Time.deltaTime * moveSpeed, 0, 0);

    }
}

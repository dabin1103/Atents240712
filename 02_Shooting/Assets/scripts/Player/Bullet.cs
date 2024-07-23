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

    /// <summary>
    /// �Ѿ��� �¾��� �� ���� ����Ʈ
    /// </summary>
    public GameObject hitEffect;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ���۵Ǿ��� �� ����
        Debug.Log("�浹 ����");
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);    // �ڱ��ڽ� �����ϱ�
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    // �浹�� �� ���¿��� �������� ���� �� ����
    //    Debug.Log("�浹 ��");
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    // �浹�� ������ �� ����
    //    Debug.Log("�浹 ����");
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("��ħ ����");
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("��ħ ��");    
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("��ħ ����");
    //}
}

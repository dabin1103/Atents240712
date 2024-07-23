using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    public float moveSpeed = 0.01f;

    /// <summary>
    /// �Ѿ� �߻� ����
    /// </summary>
    public float fireInterval = 0.5f;

    /// <summary>
    /// �Ѿ� ������
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// �Էµ� ����
    /// </summary>
    Vector3 inputDirection = Vector3.zero;

    /// <summary>
    /// �Է¿� ��ǲ �׼�
    /// </summary>
    PlayerInputActions inputActions;

    /// <summary>
    /// �ִϸ����� ������Ʈ�� ������ ����
    /// </summary>
    Animator animator;

    /// <summary>
    /// �ִϸ����Ϳ� �ؽ� �����
    /// </summary>
    readonly int InputY_String = Animator.StringToHash("InputY");

    /// <summary>
    /// �Ѿ� �߻�� Ʈ������
    /// </summary>
    Transform fireTransform;

    /// <summary>
    /// �Ѿ� �߻�� �ڷ�ƾ
    /// </summary>
    IEnumerator fireCoroutine;

    /// <summary>
    /// �Ѿ� �߻� ����Ʈ�� ���� ������Ʈ
    /// </summary>
    GameObject fireFlash;

    /// <summary>
    /// �Ѿ� �߻� ����Ʈ�� ���� �ð���
    /// </summary>
    WaitForSeconds flashWait;

    /// <summary>
    /// ������ٵ� ������Ʈ
    /// </summary>
    Rigidbody2D rigid;

    private void Awake()
    {
        inputActions = new PlayerInputActions();    // ��ǲ �׼� ����

        animator = GetComponent<Animator>();        // �ڽŰ� ���� ���ӿ�����Ʈ �ȿ� �ִ� ������Ʈ ã��
        rigid = GetComponent<Rigidbody2D>();
        fireTransform = transform.GetChild(0);      // ù���� �ڽ� ã��

        fireFlash = transform.GetChild(1).gameObject; // �ι�° �ڽ� ã�Ƽ� �� �ڽ��� ���� ������Ʈ �����ϱ�

        fireCoroutine = FireCoroutine();            // �ڷ�ƾ �����ϱ�

        flashWait = new WaitForSeconds(0.1f);       // �Ѿ� �߻�� ����Ʈ�� 0.1�� ���ȸ� ���δ�.
    }   
        
    private void OnEnable()
    {
        inputActions.Enable();                          // ��ǲ �׼� Ȱ��ȭ
        inputActions.Player.Fire.performed += OnFireStart;  // �׼ǰ� �Լ� ���ε�
        inputActions.Player.Fire.canceled += OnFireEnd;
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Fire.canceled -= OnFireEnd;
        inputActions.Player.Fire.performed -= OnFireStart;
        inputActions.Disable();
    }

    //private void Update()
    //{
    //    // Update �Լ��� ȣ��Ǵ� �ð� ����(Time.deltaTime)�� �Ź� �ٸ���.
    //    // Debug.Log(Time.deltaTime);

    //    //transform.position += (Time.deltaTime * moveSpeed * inputDirection);    // �ʴ� moveSpeed�� �ӵ��� inputDirection �������� �̵�
    //    //transform.position += (inputDirection * moveSpeed * Time.deltaTime);  // ���� �ڵ�� 4�� �������� �� �ڵ�� 6�� ���Ѵ�.

    //    //transform.Translate(Time.deltaTime * moveSpeed * inputDirection);
    //}

    private void FixedUpdate()
    {
        // �׻� ���� �ð� ����(Time.fixedDeltaTime)���� ȣ��ȴ�.
        // Debug.Log(Time.fixedDeltaTime);

        // transform.Translate(Time.fixedDeltaTime * moveSpeed * inputDirection);  // �ѹ��� �İ� ����.
        rigid.MovePosition(rigid.position + Time.deltaTime * moveSpeed * (Vector2)inputDirection);
    }

    /// <summary>
    /// Move �׼��� �߻����� �� ����� �Լ�
    /// </summary>
    /// <param name="context"></param>
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();       // �Է� �� �б�
        //transform.position += (Vector3)input;     // �Է� ���� ���� �̵�
        inputDirection = (Vector3)input;

        //animator.SetFloat("InputY", input.y);       // �ִϸ������� "InputY" �Ķ���� ����
        animator.SetFloat(InputY_String, input.y);
    }

    /// <summary>
    /// Fire �׼��� �߻����� �� ����� �Լ�
    /// </summary>
    /// <param name="_"></param>�Է� ����(������� �ʾƼ� ĭ�� ��Ƴ��� ��)
    private void OnFireStart(InputAction.CallbackContext _)
    {
        //Debug.Log("�߻� ����");
        //Fire();
        //StartCoroutine("FireCoroutine");
        //StartCoroutine(FireCoroutine());
        StartCoroutine(fireCoroutine);
    }

    private void OnFireEnd(InputAction.CallbackContext _)
    {
        //Debug.Log("�߻� ����");
        //StopAllCoroutines();     // ��� �ڷ�ƾ ������Ű��
        //StopCoroutine("FireCoroutine");
        //StopCoroutine(FireCoroutine());
        StopCoroutine(fireCoroutine);
    }

    /// <summary>
    /// �Ѿ��� �ѹ� �߻��ϴ� �Լ�
    /// </summary>
    void Fire()
    {
        // �÷��� ����Ʈ ��� �ѱ�
        StartCoroutine(FlashEffect());

        // �Ѿ� ����
        //Instantiate(bulletPrefab, transform);  // �ڽ��� �θ� ����ٴϹǷ� �̷��� �ϸ� �ȵ�
        //Instantiate(bulletPrefab, transform.position, Quaternion.identity);       // �Ѿ��� ������ ���� ��ġ�� ����
        //Instantiate(bulletPrefab, transform.position + Vector3.right, Quaternion.identity);   // �Ѿ� �߻� ��ġ�� Ȯ���ϱ� ����
        Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);  // �Ѿ��� fireTransform�� ��ġ�� ȸ���� ���� ����
    }

    /// <summary>
    /// ����� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator FireCoroutine()
    {
        // �ڷ�ƾ : ���� �ð� �������� �ڵ带 �����ϰų� ���� �ð����� �����̸� �� �� ����

        while (true)  // ���� ����
        {
            //Debug.Log("Fire");
            Fire();
            yield return new WaitForSeconds(fireInterval);  // fireInterval�ʸ�ŭ ��ٷȴٰ� �ٽ� �����ϱ�
        }

        // ������ ����ñ��� ���
        // yield return null;
        // yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// �߻� ����Ʈ�� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator FlashEffect()
    {
        fireFlash.SetActive(true);  // ���� ������Ʈ Ȱ��ȭ�ϱ�
        yield return flashWait;     // ��� ������ �ɱ�
        fireFlash.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // ������ ����. ==�� ���� �������� �� �����ȴ�. �����Ǵ� �ڵ嵵 �ξ� ������ �����Ǿ� ����.
        {
            Debug.Log("���� �ε��ƴ�.");
        }
    }
}

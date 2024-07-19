using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    /// <summary>
    /// �̵� �ӵ�
    /// </summary>
    public float moveSpeed = 0.01f;

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

    private void Awake()
    {
        inputActions = new PlayerInputActions();    // ��ǲ �׼� ����

        animator = GetComponent<Animator>();        // �ڽŰ� ���� ���ӿ�����Ʈ �ȿ� �ִ� ������Ʈ ã��

        fireTransform = transform.GetChild(0);      // ù���� �ڽ� ã��
        fireFlash = transform.GetChild(1).gameObject; // �ι�° �ڽ� ã�Ƽ� �� �ڽ��� ���� ������Ʈ �����ϱ�

        fireCoroutine = FireCoroutine();            // �ڷ�ƾ �����ϱ�

        flashWait = new WaitForSeconds(0.1f);       // �Ѿ� �߻�� ����Ʈ�� 0.1�� ���ȸ� ���δ�.

    }   
        
    private void OnEnable()
    {
        inputActions.Enable();                          // ��ǲ �׼� Ȱ��ȭ
        inputActions.Player.Fire.performed += OnFireStart;
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

    // Move �׼��� �߻����� �� ����� �Լ�


    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();       // �Է� �� �б�
        //transform.position += (Vector3)input;     // �Է� ���� ���� �̵�
        inputDirection = (Vector3)input;

        //animator.SetFloat("InputY", input.y);       // �ִϸ������� "InputY" �Ķ���� ����
        animator.SetFloat(InputY_String, input.y);
    }

    // Fire �׼��� �߻����� �� ����� �Լ�
    // <param name="_">�Է� ����(������� �ʾƼ� ĭ�� ��Ƴ��� ��)

    private void OnFire(InputAction.CallbackContext _)
    {

    }

    private void OnFireStart(InputAction.CallbackContext _)
    {
        Debug.Log("�߻� ����");    // �߻��� ���
        //Fire();
        StartCoroutine(fireCoroutine);
    }

    private void OnFireEnd(InputAction.CallbackContext _)
    {
        Debug.Log("�߻� ����");
        //StopAllCoroutines();     // ��� �ڷ�ƾ ������Ű��
        //StopCoroutine("FireCoroutine");
        StopCoroutine(fireCoroutine);
    }

    private void Update()
    {
        //transform.position += (Time.deltaTime * moveSpeed * inputDirection);    // �ʴ� moveSpeed�� �ӵ��� inputDirection �������� �̵�
        //transform.position += (inputDirection * moveSpeed * Time.deltaTime);  // ���� �ڵ�� 4�� �������� �� �ڵ�� 6�� ���Ѵ�.

        transform.Translate(Time.deltaTime * moveSpeed * inputDirection);
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


        //StartCoroutine(FireCoroutine());

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
            Debug.Log("Fire");
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
}

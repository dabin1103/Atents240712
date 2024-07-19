using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01_sprite : MonoBehaviour
{
    // �׽�Ʈ�� ��ǲ�׼��� ������ �ɹ� ����
    TestInputActions inputActions;

    private void Awake()
    {
        // �� ��ũ��Ʈ�� ������ �����Ǹ� ����Ǵ� �Լ�
        inputActions = new TestInputActions();  // TestInputActions�� ���� ����

        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        // �� ��ũ��Ʈ�� Ȱ��ȭ�Ǹ� ����Ǵ� �Լ�
        Debug.Log("OnEnable");
        inputActions.Test.Enable(); // Test�׼Ǹ� Ȱ��ȭ�ϱ�
        //inputActions.Test.Test1.started += OnTest1_started;   //�Է��� ������ �ߵ�
        inputActions.Test.Test1.performed += OnTest1_performed; //�Է��� ����� ������ �ߵ�
        //inputActions.Test.Test1.canceled += OnTest1_canceled;   //�Է��� ���(��ư���� ���� ����)�ϸ� �ߵ�
    }

    private void OnTest1_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("canceled");
    }

    private void OnTest1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("performed");
    }

    private void OnTest1_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Started");
    }

    private void OnDisable()
    {
        // �� ��ũ��Ʈ�� ��Ȱ��ȭ�Ǹ� ����Ǵ� �Լ�
        Debug.Log("OnDisable");

        inputActions.Test.Test1.performed += OnTest1_performed; // Test1.performed�� ��ϵǾ� �ִ� �Լ� ����
        inputActions.Test.Disable(); // Test�׼Ǹ� ��Ȱ��ȭ�ϱ�
    }
        

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� �ѹ� ����Ǵ� �Լ�(ù��° ������Ʈ �Լ��� ����Ǳ� ������ �ѹ� ȣ��Ǵ� �Լ�)
        //Debug.Log("����");
    }

    // Update is called once per frame
    void Update()
    {
        // �����Ӹ��� �Ź� ����Ǵ� �Լ�
        //Debug.Log("������Ʈ");

        ////InputManager ���
        //if (Input.GetKeyDown(KeyCode.A))    // pooling ���
        //{
        //    Debug.Log("A������");
        //}
    }
}

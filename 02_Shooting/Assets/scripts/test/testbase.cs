using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;      // �ٸ� ���ӽ����̽����� �����ϴ� Random�� �־

public class testbase : MonoBehaviour
{
    public int seed = AllRandom;   // public���� �Ǿ� �ִ� ������ �ν�����â���� Ȯ���� �����ϴ�.
    const int AllRandom = -1;

    // [SerializeField]     // SerializeField attribute�� �ִ� ������ �ν�����â���� Ȯ���� �����ϴ�.(����Ƽ���� public�� �����ϰ� ����)
    // int ssss = 10;

    // �׽�Ʈ�� ��ǲ�׼��� ������ �ɹ� ����
    TestInputActions inputActions;

    private void Awake()
    {
        inputActions = new TestInputActions();          // TestInputActions�� ���� ����

        if (seed != -1)
            if (seed != AllRandom)
            {
                Random.InitState(seed);
            }
    }

    private void OnEnable()
    {
        inputActions.Test.Enable();                     // Test�׼Ǹ� Ȱ��ȭ�ϱ�
        inputActions.Test.Test1.performed += OnTest1;   // �׼ǰ� �Լ� ���ε�
        inputActions.Test.Test2.performed += OnTest2;
        inputActions.Test.Test3.performed += OnTest3;
        inputActions.Test.Test4.performed += OnTest4;
        inputActions.Test.Test5.performed += OnTest5;
        inputActions.Test.LClick.performed += OnTestLClick;
        inputActions.Test.RClick.performed += OnTestRClick;
        inputActions.Test.TestWASD.performed += OnTestWASD;
        inputActions.Test.TestWASD.canceled += OnTestWASD;
    }




    private void OnDisable()
    {
        inputActions.Test.TestWASD.canceled -= OnTestWASD;
        inputActions.Test.TestWASD.performed -= OnTestWASD;
        inputActions.Test.RClick.performed -= OnTestRClick;
        inputActions.Test.LClick.performed -= OnTestLClick;
        inputActions.Test.Test5.performed -= OnTest5;
        inputActions.Test.Test4.performed -= OnTest4;
        inputActions.Test.Test3.performed -= OnTest3;
        inputActions.Test.Test2.performed -= OnTest2;
        inputActions.Test.Test1.performed -= OnTest1;
        inputActions.Test.Disable();
    }

    protected virtual void OnTestLClick(InputAction.CallbackContext context)
    {
        //Debug.Log("�θ� : OnTest1");
    }

    protected virtual void OnTestRClick(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest5(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest4(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest3(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest2(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest1(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTestWASD(InputAction.CallbackContext context)
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test01_Sprite2 : testbase
{
    // Start is called before the first frame update
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        // base;    // �θ� �����ϱ� ���� Ű����
        // this;    // �ڱ� �ڽſ� �����ϱ� ���� Ű����

        //base.OnTest1(context);    // �θ��� ��ɵ� ���� �����ϴ� ���
        Debug.Log("�ڽ� : OnTest1");
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        int rand = Random.Range(0, 10);
        Debug.Log($"���� : {rand}");
    }

    protected override void OnTestWASD(InputAction.CallbackContext context)
    {
       Vector2 input = context.ReadValue<Vector2>();
        Debug.Log($"�Է� : {input}");
    }
}  
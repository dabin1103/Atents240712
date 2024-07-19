using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test02_Move : testbase
{
    public GameObject target;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(0, 1); // ���� 1��ŭ �̵�
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(0, -1); // �Ʒ��� 1��ŭ �̵�
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(-1, 0); // �������� 1��ŭ �̵�
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(1, 0); // ���������� 1��ŭ �̵�
    }

    protected override void OnTestWASD(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        target.transform.position += (Vector3)input;
    }
}

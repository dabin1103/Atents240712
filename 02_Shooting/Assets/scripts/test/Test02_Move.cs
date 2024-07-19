using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test02_Move : testbase
{
    public GameObject target;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(0, 1); // 위로 1만큼 이동
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(0, -1); // 아래로 1만큼 이동
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(-1, 0); // 왼쪽으로 1만큼 이동
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        target.transform.position += new Vector3(1, 0); // 오른쪽으로 1만큼 이동
    }

    protected override void OnTestWASD(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        target.transform.position += (Vector3)input;
    }
}

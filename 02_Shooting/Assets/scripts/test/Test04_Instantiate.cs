using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test04_Instantiate : testbase
{
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        int i = Random.Range(0, 10);        // 0~9 �� ������ int�� �����Ѵ�.
        float f = Random.Range(0.0f, 10.0f); // 0.0~10.0 �� ������ float�� �����Ѵ�.
        float f2 = Random.value;            //
    }
}

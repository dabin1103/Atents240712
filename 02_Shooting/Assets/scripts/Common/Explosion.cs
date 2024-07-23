using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // animator.GetCurrentAnimatorClipInfo(0) : �ִϸ����� ��Ʈ�ѷ��� ù��° ���̾ ������ �ִ� Ŭ�� ������ ��������
        // animator.GetCurrentAnimatorClipInfo(0)[0] : Ŭ�� �����鿡�� ù��° Ŭ���� ����

        AnimatorClipInfo info = animator.GetCurrentAnimatorClipInfo(0)[0]; // �ϳ��� �����ϴ� ���� �˰� �־ ù��°�� ��������

        Destroy(gameObject, info.clip.length); // �ִϸ��̼� Ŭ�� ��� �ð��� ������ ����
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCtrl : MonoBehaviour
{
    public Animation CombatSG;
    public SkinnedMeshRenderer Spas12;
    public MeshRenderer[] Ak47;
    public MeshRenderer[] M4A1;
    public bool isHaveM4A1 = false;
    public bool isRun = false;
    void Start()
    {
        
    }
    void Update()
    {
        RunAndStop();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponChange1();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponChange2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponChange3();
        }
    }

    private void WeaponChange3()
    {
        isHaveM4A1 = true;
        CombatSG.Play("draw");
        Spas12.enabled = false;
        for (int i = 0; i < Ak47.Length; i++)
        {
            Ak47[i].enabled = false;
        }
        for (int i = 0; i < M4A1.Length; i++)
        {
            M4A1[i].enabled = true;
        }
    }

    private void WeaponChange2()
    {
        isHaveM4A1 = false;
        CombatSG.Play("draw");
        Spas12.enabled = false;
        for (int i = 0; i < Ak47.Length; i++)
        {
            Ak47[i].enabled = true;
        }
        for (int i = 0; i < M4A1.Length; i++)
        {
            M4A1[i].enabled = false;
        }
    }

    private void WeaponChange1()
    {
        isHaveM4A1 = false;
        CombatSG.Play("draw");
        Spas12.enabled = true;
        for (int i = 0; i < Ak47.Length; i++)
        {
            Ak47[i].enabled = false;
        }
        for (int i = 0; i < M4A1.Length; i++)
        {
            M4A1[i].enabled = false;
        }
    }

    private void RunAndStop()
    {
        //����Ʈ ����Ű�� WŰ�� ���� ������ ��� 
        if (Input.GetKey(KeyCode.LeftShift) &&
            Input.GetKey(KeyCode.W))
        {
            isRun = true;
            CombatSG.Play("running");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {         //���ʽ���ƮŰ�� ���ٸ�
            CombatSG.Play("runStop");
            isRun = false;
        }
    }
}

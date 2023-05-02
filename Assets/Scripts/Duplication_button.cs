using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Duplication_button : MonoBehaviour
{
    [SerializeField]
    Database database = null;
    [SerializeField]
    private InputField id_field = null;
    [SerializeField]
    GameObject state_pan = null;

    Coroutine coroutine = null;

    public void duplication_push()
    {

        StartCoroutine(delay());
        Debug.Log("â0");

    }

    IEnumerator delay()
    {
        Debug.Log("â1");
        yield return StartCoroutine(database.getlog(id_field.text));
        Debug.Log("â1_1");
        yield return StartCoroutine(check());
    }

    IEnumerator check()
    {
        Debug.Log("��ư"+database.duplication);
        if (database.duplication==true)
        {
            Debug.Log("â3");
            Activewindow().text = "���̵�: <color=red><size=60>" + id_field.text + "</size></color>�� �ߺ��Դϴ�.";
            database.duplication = false;
        }
        else if(id_field.text =="")
        {
            Activewindow().text = "���̵� <color=red><size=60> �Է� </size></color> ���ּ���.";
        }
        else
        {
            Activewindow().text = "���̵�: <color=blue><size=60>" + id_field.text + "</size></color>�� ��밡���մϴ�.";

        }

        yield return coroutine;
    }
    public Text Activewindow()
    {
        state_pan.SetActive(true);
        GameObject state = state_pan.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Text state_text = state.GetComponent<Text>();
        return state_text;
    }
}

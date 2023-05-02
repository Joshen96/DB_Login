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
        Debug.Log("창0");

    }

    IEnumerator delay()
    {
        Debug.Log("창1");
        yield return StartCoroutine(database.getlog(id_field.text));
        Debug.Log("창1_1");
        yield return StartCoroutine(check());
    }

    IEnumerator check()
    {
        Debug.Log("버튼"+database.duplication);
        if (database.duplication==true)
        {
            Debug.Log("창3");
            Activewindow().text = "아이디: <color=red><size=60>" + id_field.text + "</size></color>는 중복입니다.";
            database.duplication = false;
        }
        else if(id_field.text =="")
        {
            Activewindow().text = "아이디 <color=red><size=60> 입력 </size></color> 해주세요.";
        }
        else
        {
            Activewindow().text = "아이디: <color=blue><size=60>" + id_field.text + "</size></color>는 사용가능합니다.";

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

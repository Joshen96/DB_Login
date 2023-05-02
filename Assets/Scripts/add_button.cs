using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class add_button : MonoBehaviour
{
    [SerializeField]
    private InputField id = null;
    [SerializeField]
    private InputField pw = null;
    [SerializeField]
    Database database = null;
    [SerializeField]
    Coroutine coroutine = null;

    [SerializeField]
    GameObject Main_Panel = null;
    
   

    public void Login_push()
    {
        if (id.text == "" || pw.text == "")
        {
            Main_Panel.gameObject.SetActive(true);
            GameObject state = Main_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();
            state_text.text = "<color=red><size=60>다시</size></color>입력하세요";
            
            return;

        }
       
        else
        {

            //Debug.Log("확인용 : " + id.text + "확인용 : " + pw.text);
            //database.StartCoroutine(database.AddScoreCoroutine(id.text, int.Parse(pw.text)));

            StartCoroutine(delay());

            //id.text = "";
            //pw.text = "";

            //this.gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //this.gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    IEnumerator delay()
    { 
        yield return StartCoroutine(database.Login_Ck(id.text, pw.text));
        yield return StartCoroutine(check());
    }
    IEnumerator check()
    {

        if (database.state == 1)
        {
            Debug.Log("성공");
            Main_Panel.gameObject.SetActive(true);

            GameObject state = Main_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=aqua><size=60>로그인성공</size></color>";
            //로그인성공부분

        }
        else if(database.state == 2) 
        {
            Debug.Log("비번틀림");

            Main_Panel.gameObject.SetActive(true);
            GameObject state = Main_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=orange><size=60>비번틀림</size></color>";
        }
        else if(database.state == 3) 
        {
            
            Debug.Log("아이디없음");
            Main_Panel.gameObject.SetActive(true);
            GameObject state = Main_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=lime><size=60>아이디 없음</size></color>";
        }
        else
        {
            Debug.Log("모름" + database.state);
        }
        
        yield return coroutine;
    }
    public void quit()
    {
        Main_Panel.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    public void Sign_Canvas_()
    {

    }
    

}

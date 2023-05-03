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
    GameObject State_Panel = null;
    [SerializeField]
    GameObject Suclogin_panel = null;

    
   

    public void Login_push()
    {
        
        if (id.text == "" || pw.text == "")
        {
            State_Panel.gameObject.SetActive(true);
            GameObject state = State_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
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
            Suclogin_panel.gameObject.SetActive(true);
            
            GameObject state = Suclogin_panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=aqua><size=60>로그인 성공!</size></color>";
            //로그인성공부분

            //여기에 이제 디비 전체 정보 보여주기 만들기

        }
        else if(database.state == 2) 
        {
            Debug.Log("비번틀림");

            State_Panel.gameObject.SetActive(true);
            GameObject state = State_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=orange><size=60>비밀번호를 다시입력 하세요.</size></color>";
        }
        else if(database.state == 3) 
        {
            
            Debug.Log("존재하지 않는 아이디");
            State_Panel.gameObject.SetActive(true);
            GameObject state = State_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=lime><size=60>존재하지 않는</size></color>아이디.";
        }
        else
        {
            Debug.Log("모름" + database.state);
        }
        
        yield return coroutine;
    }
    public void quit()
    {
        State_Panel.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    public void Sign_Push() //회원가입 창띄우는 버튼
    {
        State_Panel.gameObject.SetActive(true);
    }
    

}

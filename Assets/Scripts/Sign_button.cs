using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Sign_button : MonoBehaviour
{
    [SerializeField]
    Database database = null;
    [SerializeField]
    InputField id_field = null;
    [SerializeField]
    InputField pw_field = null;

    [SerializeField]
    GameObject Main_Panel = null;


    public void push_Sign()
    {
        //회원가입 검증 부분
        if (pw_field.text == "" || id_field.text == "") //공백
        {

            Activewindow().text = "빈칸없이<color=red><size=60>다시</size></color>입력하세요";
            //오류창
            return;
        }
        else if(id_field.text =="qwe")//중복아이디
        {
            //오류창
            Activewindow().text = "아이디: <color=red><size=60>"+ id_field.text + "</size></color>는 중복입니다.";

            return;
        }
        else
        {
            Activewindow().text = "회원가입 성공! <color=red><size=60>" + id_field.text + "</size></color>님 환영해요.";

            database.SignUp(id_field.text, pw_field.text);
        }
    }
    public Text Activewindow()
    {
        Main_Panel.SetActive(true);
        GameObject state = Main_Panel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Text state_text = state.GetComponent<Text>();
        return state_text;
    }
}

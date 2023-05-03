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
    InputField name_field = null;
    [SerializeField]
    InputField age_field = null;

    Coroutine coroutine = null;

    [SerializeField]
    GameObject Main_Panel = null;
    int cknum = 0;

    public void push_Sign()
    {
        StartCoroutine(delay());



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
        //회원가입 검증 부분
        if (pw_field.text == "" || id_field.text == "" || name_field.text == "" || age_field.text == "") //공백
        {

            Activewindow().text = "빈칸없이<color=red><size=60>다시</size></color>입력하세요";
            //오류창
            
        }
        else if (database.duplication == true)//중복아이디
        {
            //오류창
            Activewindow().text = "아이디: <color=red><size=60>" + id_field.text + "</size></color>는 중복입니다.";

            
        }
        else if (!int.TryParse(age_field.text, out cknum))
        {
            Activewindow().text = "나이: <color=red><size=60>" + age_field.text + "</size></color>는 문자입니다.";
        }
        else
        {
            Activewindow().text = "회원가입 성공! <color=red><size=60>" + id_field.text + "</size></color>님 환영해요.";

            database.SignUp(id_field.text, pw_field.text, name_field.text, age_field.text);
        }

        yield return coroutine;
    }

    public Text Activewindow()
    {
        Main_Panel.SetActive(true);
        GameObject state = Main_Panel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Text state_text = state.GetComponent<Text>();
        return state_text;
    }
}

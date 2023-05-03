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
        Debug.Log("â1");
        yield return StartCoroutine(database.getlog(id_field.text));
        Debug.Log("â1_1");
        yield return StartCoroutine(check());
    }
    IEnumerator check()
    {
        //ȸ������ ���� �κ�
        if (pw_field.text == "" || id_field.text == "" || name_field.text == "" || age_field.text == "") //����
        {

            Activewindow().text = "��ĭ����<color=red><size=60>�ٽ�</size></color>�Է��ϼ���";
            //����â
            
        }
        else if (database.duplication == true)//�ߺ����̵�
        {
            //����â
            Activewindow().text = "���̵�: <color=red><size=60>" + id_field.text + "</size></color>�� �ߺ��Դϴ�.";

            
        }
        else if (!int.TryParse(age_field.text, out cknum))
        {
            Activewindow().text = "����: <color=red><size=60>" + age_field.text + "</size></color>�� �����Դϴ�.";
        }
        else
        {
            Activewindow().text = "ȸ������ ����! <color=red><size=60>" + id_field.text + "</size></color>�� ȯ���ؿ�.";

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

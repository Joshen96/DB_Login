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
        //ȸ������ ���� �κ�
        if (pw_field.text == "" || id_field.text == "") //����
        {

            Activewindow().text = "��ĭ����<color=red><size=60>�ٽ�</size></color>�Է��ϼ���";
            //����â
            return;
        }
        else if(id_field.text =="qwe")//�ߺ����̵�
        {
            //����â
            Activewindow().text = "���̵�: <color=red><size=60>"+ id_field.text + "</size></color>�� �ߺ��Դϴ�.";

            return;
        }
        else
        {
            Activewindow().text = "ȸ������ ����! <color=red><size=60>" + id_field.text + "</size></color>�� ȯ���ؿ�.";

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

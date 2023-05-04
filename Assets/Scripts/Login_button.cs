using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class Login_button : MonoBehaviour
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
        string idChecker1 = Regex.Replace(id.text, @"[ ^0-9a-zA-Z��-�R ]", string.Empty, RegexOptions.Singleline); //Ư�����ڸ� �����
        string idChecker2 = Regex.Replace(id.text, @"[^a-zA-Z0-9��-�R]", string.Empty, RegexOptions.Singleline); //Ư�����ڸ� ������
    
    Debug.Log("1��"+idChecker1 +": "+ id.text);
    Debug.Log("2��"+idChecker2 +": "+ id.text);

        if (id.text == "" || pw.text == "")
        {
            Active_window().text = "<color=red><size=60>�ٽ�</size></color>�Է��ϼ���";
            
            return; 

        }   
       else if(id.text.Equals(idChecker2) == false)
        {
          
                id.text.Remove(0, id.text.Length);

                id.text = "";
                pw.text = "";
            Active_window().text ="Ư������, ������ ������ �ʽ��ϴ�..";

            
        }
       

        else
        {
            
            StartCoroutine(delay());
        }
    }
    IEnumerator delay() //�ߺ��˻�
    { 
        yield return StartCoroutine(database.Login_Ck(id.text, pw.text));
        //id.text = "";
        pw.text = "";
        yield return StartCoroutine(check());
          
    }
    IEnumerator check()
    {

        if (database.state == 1)
        {
            Debug.Log("����");
            Suc_Active_window().text = "<color=aqua><size=60>�α��� ����!</size></color>";
            //�α��μ����κ�

            id.text = "";
            pw.text = "";

        }
        else if(database.state == 2) 
        {
            Debug.Log("���Ʋ��");

            Active_window().text = "<color=orange><size=60>��й�ȣ�� �ٽ��Է� �ϼ���.</size></color>";
            pw.text = "";
        }
        else if(database.state == 3) 
        {
            
            Debug.Log("�������� �ʴ� ���̵�");


            Active_window().text = "[<color=red><size=60>" + id.text + "</size></color>]<color=lime>�� �������� �ʴ�</color>���̵�.";
           
            pw.text = "";
        }
        else
        {
            Debug.Log("��" + database.state);
        }
        
        yield return coroutine;
    }
    public void quit()
    {
        State_Panel.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    public void Sign_Push() //ȸ������ â���� ��ư
    {
        State_Panel.gameObject.SetActive(true);
    }

    public Text Active_window()
    {
        State_Panel.gameObject.SetActive(true);
        GameObject state = State_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Text state_text = state.GetComponent<Text>();
        return state_text;
    }
    public Text Suc_Active_window()
    {
        Suclogin_panel.gameObject.SetActive(true);

        GameObject state = Suclogin_panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Text state_text = state.GetComponent<Text>();
        return state_text;
    }

}

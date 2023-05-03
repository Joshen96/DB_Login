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
            state_text.text = "<color=red><size=60>�ٽ�</size></color>�Է��ϼ���";
            
            return;

        }
       
        else
        {

            //Debug.Log("Ȯ�ο� : " + id.text + "Ȯ�ο� : " + pw.text);
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
            Debug.Log("����");
            Suclogin_panel.gameObject.SetActive(true);
            
            GameObject state = Suclogin_panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=aqua><size=60>�α��� ����!</size></color>";
            //�α��μ����κ�

            //���⿡ ���� ��� ��ü ���� �����ֱ� �����

        }
        else if(database.state == 2) 
        {
            Debug.Log("���Ʋ��");

            State_Panel.gameObject.SetActive(true);
            GameObject state = State_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=orange><size=60>��й�ȣ�� �ٽ��Է� �ϼ���.</size></color>";
        }
        else if(database.state == 3) 
        {
            
            Debug.Log("�������� �ʴ� ���̵�");
            State_Panel.gameObject.SetActive(true);
            GameObject state = State_Panel.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            Text state_text = state.GetComponent<Text>();

            state_text.text = "<color=lime><size=60>�������� �ʴ�</size></color>���̵�.";
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
    

}

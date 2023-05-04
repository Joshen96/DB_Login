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
        string idChecker1 = Regex.Replace(id.text, @"[ ^0-9a-zA-Z°¡-ÆR ]", string.Empty, RegexOptions.Singleline); //Æ¯¼ö¹®ÀÚ¸¸ ³²±â°í
        string idChecker2 = Regex.Replace(id.text, @"[^a-zA-Z0-9°¡-ÆR]", string.Empty, RegexOptions.Singleline); //Æ¯¼ö¹®ÀÚ¸¦ Á¦°ÅÇÔ
    
    Debug.Log("1ºñ±³"+idChecker1 +": "+ id.text);
    Debug.Log("2ºñ±³"+idChecker2 +": "+ id.text);

        if (id.text == "" || pw.text == "")
        {
            Active_window().text = "<color=red><size=60>´Ù½Ã</size></color>ÀÔ·ÂÇÏ¼¼¿ä";
            
            return; 

        }   
       else if(id.text.Equals(idChecker2) == false)
        {
          
                id.text.Remove(0, id.text.Length);

                id.text = "";
                pw.text = "";
            Active_window().text ="Æ¯¼ö¹®ÀÚ, °ø¹éÀº Çã¿ëµÇÁö ¾Ê½À´Ï´Ù..";

            
        }
       

        else
        {
            
            StartCoroutine(delay());
        }
    }
    IEnumerator delay() //Áßº¹°Ë»ç
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
            Debug.Log("¼º°ø");
            Suc_Active_window().text = "<color=aqua><size=60>·Î±×ÀÎ ¼º°ø!</size></color>";
            //·Î±×ÀÎ¼º°øºÎºÐ

            id.text = "";
            pw.text = "";

        }
        else if(database.state == 2) 
        {
            Debug.Log("ºñ¹øÆ²¸²");

            Active_window().text = "<color=orange><size=60>ºñ¹Ð¹øÈ£¸¦ ´Ù½ÃÀÔ·Â ÇÏ¼¼¿ä.</size></color>";
            pw.text = "";
        }
        else if(database.state == 3) 
        {
            
            Debug.Log("Á¸ÀçÇÏÁö ¾Ê´Â ¾ÆÀÌµð");


            Active_window().text = "[<color=red><size=60>" + id.text + "</size></color>]<color=lime>´Â Á¸ÀçÇÏÁö ¾Ê´Â</color>¾ÆÀÌµð.";
           
            pw.text = "";
        }
        else
        {
            Debug.Log("¸ð¸§" + database.state);
        }
        
        yield return coroutine;
    }
    public void quit()
    {
        State_Panel.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    public void Sign_Push() //È¸¿ø°¡ÀÔ Ã¢¶ç¿ì´Â ¹öÆ°
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

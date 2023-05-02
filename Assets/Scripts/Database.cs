using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Security.Cryptography;
using System;

public class Database : MonoBehaviour
{
    
    public class DataLogin
    {
        public string id { get; set; }
        public string pw { get; set; }
    }

    public int state =10;

    public bool duplication = false;

    private void Start()
    {


        //StartCoroutine(AddScoreCoroutine("qweasd", 400)); //디비에 넣기

        //StartCoroutine(LoginCoroutine("test1", "1234")); //디비에서 가져오기
    }



    private IEnumerator SignUpCoroutine(
         string _id, string _pw)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        form.AddField("pw", _pw);

        using (UnityWebRequest www =
            UnityWebRequest.Post("" +
            "http://localhost/signup.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result ==
                UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(
                    "AddScore Success : " +
                    _id + "(" + _pw + ")");
            }
        }
    }

    private IEnumerator LoginCoroutine(string _id, string _pw) {

        
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        form.AddField("pw", _pw);

        using (UnityWebRequest www =
            UnityWebRequest.Post("http://localhost/login.php", form)) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log("핸들러 " + www.downloadHandler.text);
                string data = www.downloadHandler.text; //텍스트로 받아온다

                if (data == "Login success!!")
                {
                    state = 1;

                }
                else if (data == "Wrong password...")
                {
                    state = 2;
                }
                else if (data == "ID not Found..") 
                {
                    state = 3;
                }
            }
        }
    }
    private IEnumerator GetLoginCoroutine()
    {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://localhost/getLogin.php", ""))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("핸들러 " + www.downloadHandler.text);
                string data = www.downloadHandler.text; //텍스트로 받아온다

                List<DataLogin> datainfos =
                   JsonConvert.DeserializeObject<List<DataLogin>>(data); //역직열화 숫자는 인트 같은작업을 해준다 제이슨사용이유
                //목록으로 만들어줌

                foreach (DataLogin datainfo in datainfos)
                {
                    Debug.Log(datainfo.id + " : " + datainfo.pw);
                    

                }
            }
        }
    }

    private IEnumerator GetLoginCKCoroutine(string id)
    {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://localhost/getLogin.php", ""))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("핸들러 " + www.downloadHandler.text);
                string data = www.downloadHandler.text; //텍스트로 받아온다

                List<DataLogin> datainfos =
                   JsonConvert.DeserializeObject<List<DataLogin>>(data); //역직열화 숫자는 인트 같은작업을 해준다 제이슨사용이유
                //목록으로 만들어줌

                foreach (DataLogin datainfo in datainfos)
                {
                    if(datainfo.id ==id)
                    {
                        duplication = true;

                        break;
                    }
                    
                    Debug.Log("디비속" + duplication);
                }
            }
        }


    }

    public void SignUp(string _id, string _pw)
    {

        StartCoroutine(SignUpCoroutine(_id, _pw));
    }
    public IEnumerator Login_Ck(string _id, string _pw)
    {
        
       yield return StartCoroutine(LoginCoroutine(_id, _pw));
  

    }
    public IEnumerator getlog(string _id)
    {
        yield return StartCoroutine(GetLoginCKCoroutine(_id));
    }


    
}
/*
                //목록으로 만들어줌
                
                foreach (DataScore dataScore in dataScores) {
                    Debug.Log(dataScore.id + " : " + dataScore.pw);
                    
                    Debug.Log(dataScore.id + " : " + dataScore.score);

                    GameObject text = GameObject.Instantiate(textPrefab,Content.transform);
                    Text text1 = text.GetComponent<Text>();
                    text1.text = string.Format("아이디 : [ {0,10} ] \t점수 : [ {1,10} ]",dataScore.id,dataScore.score);
                    //text.transform.parent = Content.transform;
                    

                }
            }
        }


    }
    
    

    public void add(string _id, int _pw)
    {

        StartCoroutine(AddScoreCoroutine(_id, _pw));
    }
    public void Info(string _id, string _pw)
    {
        StartCoroutine(LoginCoroutine(_id, _pw));
    }
   
}
*/
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

   
    public void push_Sign()
    {
        

        database.SignUp(id_field.text,pw_field.text);

    }
}

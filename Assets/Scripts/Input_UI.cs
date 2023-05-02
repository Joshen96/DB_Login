using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Input_UI : MonoBehaviour
{
    public InputField InputText;

    public void get(Text _text)
    {
        _text.text = InputText.text;
    }

   
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_button : MonoBehaviour
{
    public void Close_Panel()
    {
        this.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);

    }
}

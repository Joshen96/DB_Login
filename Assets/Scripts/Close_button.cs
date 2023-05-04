using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_button : MonoBehaviour
{
    [SerializeField]
    Database database;
    [SerializeField]
    GameObject user_canvas;
    public void Close_Panel()
    {
        this.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);

    }

    public void SucLogin_Panel()
    {
        user_canvas.gameObject.SetActive(true);
        database.uploadDB();
        this.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);

    }
}

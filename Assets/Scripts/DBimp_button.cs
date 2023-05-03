using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBimp_button : MonoBehaviour
{
    [SerializeField]
    GameObject Content = null;
    [SerializeField]
    Database database = null;
    
    
    public void DB_Up_load()
    {
        Transform[] childList = Content.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        database.uploadDB();

    }
   



}

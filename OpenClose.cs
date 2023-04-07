using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public GameObject obj;
    bool open = false;
    public void OpenOrClose()
    {
        if (open)
        {
            obj.SetActive(false);
            open = false;
        }
        else
        {
            obj.SetActive(true);
            open = true;
        }
    }
    public void Close()
    {
        obj.SetActive(false);
    }
}

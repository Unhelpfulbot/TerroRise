using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucontroller : MonoBehaviour
{
    public GameObject Info1;
    public GameObject Info2;
    public GameObject HowToPlay;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackfromInfo1()
    {
        Info1.SetActive(false);
    }
    public void BackfromInfo2()
    {
        Info2.SetActive(false);
    }
    public void BackfromHow()
    {
        HowToPlay.SetActive(false);
    }
    public void Info1to2()
    {
        Info1.SetActive(false);
        Info2.SetActive(true);
    }
    public void Info2to1()
    {
        Info2.SetActive(false);
        Info1.SetActive(true);
    }

}

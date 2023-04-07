using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    
public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
}

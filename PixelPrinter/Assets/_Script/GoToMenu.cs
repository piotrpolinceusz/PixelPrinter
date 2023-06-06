using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    public void GotoLevelMenu ()
    {
        SceneManager.LoadScene(1);
        
    }

    public void GotoMainMenu ()
    {
        SceneManager.LoadScene(0);
        
    }
}

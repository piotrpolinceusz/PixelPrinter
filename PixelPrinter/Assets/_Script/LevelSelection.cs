using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelection : MonoBehaviour
{
    public static LevelSelection instance;
   [SerializeField] private bool Unlocked; // domyslnie zablokowane
    public Image unlockImage;
    public GameObject[] stars;
    public int levelIndex;
    public Sprite starSprite;

    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

   private void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;

        if (int.Parse(gameObject.name) == 1)
        {
            Unlocked = true;
        }

        if (int.Parse(gameObject.name) >= 2 && PlayerPrefs.GetInt("Lvl" + previousLevelNum) >= 1)
        {
            Unlocked = true;
        }

        if (int.Parse(gameObject.name) >= 2 && PlayerPrefs.GetInt("Lvl" + previousLevelNum) == 0)
        {
            Unlocked = false;
        }

        Debug.Log("Level: " + levelIndex + ", Unlocked: " + Unlocked);
    }

    private void UpdateLevelImage () 
    {
        if(!Unlocked)//MARKER means cant play    
        {
           unlockImage.gameObject.SetActive(true);
           for(int i = 0; i < stars.Length ; i++) 
           {
                stars[i].gameObject.SetActive(false);
            }
        }    
        else// can play
        {
            unlockImage.gameObject.SetActive(false);
            for(int i = 0; i < stars.Length ; i++) 
            {
                stars[i].gameObject.SetActive(true);
            }
            // for(int i = 0; i < PlayerPrefs.GetInt("Lvl1" ); i++) 
            // {
            //     stars[i].gameObject.GetComponent<Image>().sprite=starSprite;
            // }
            for(int i = 0; i < PlayerPrefs.GetInt("Lvl" + gameObject.name); i++) 
            {
                stars[i].gameObject.GetComponent<Image>().sprite=starSprite;
            }

        }     
    }
    
    public void PressSelection (string _LevelName)
    {
        if (Unlocked)
        {
            SceneManager.LoadScene(_LevelName);
            PlayerPrefs.SetInt("ActualLevel",levelIndex); 
        }
    }
    
}




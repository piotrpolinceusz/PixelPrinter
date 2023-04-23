using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject MapSelectionPanel;
    public GameObject[] LevelSelectionPanels;

    [Header("Licznik Gwiazdek")]
    public int Stars;
    public TextMeshProUGUI startText;
    public MapSelection[] mapSelections;
    public TextMeshProUGUI[] questStarTexts;
    public TextMeshProUGUI[] lockedStarTexts;
    public TextMeshProUGUI[] unlockStarTexts;
    public bool GameActive;
    float TimeRemaininig;
    float EndTiming;
    public float MaxTime = 10f;
    public float Sec3 = 3f;


    public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //MapSelectionPanel.gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}


 void Start()
    {
        GameActive=false;
        TimeRemaininig = MaxTime;
        EndTiming = Sec3;
    }


    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
            
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        UpdateStarUI();
        UpdateLockedStarUI();
        UpdateUnLockedStarUI(); 
        PlayGame ();

    }

    private void UpdateLockedStarUI() // update stars in lokde view
    {
        for(int i = 0; i < mapSelections.Length; i++)
        {
            questStarTexts[i].text=mapSelections[i].Questnumber.ToString();    //star to reach to unlock
            if(mapSelections[i].MapIsUnlock == false)  // if one of map is locked
            {
               lockedStarTexts[i].text = Stars.ToString() + "/" + mapSelections[i].EndLevel*3; 
            }
        }
    }

    private void UpdateUnLockedStarUI ()  // update stars in unlokde view
    {
        for(int i = 0; i < mapSelections.Length; i++) 
        {
            unlockStarTexts[i].text = Stars.ToString() + "/" + mapSelections[i].EndLevel * 3;
        }
    }

    private void UpdateStarUI()  // update main count stars
    {
        startText.text = Stars.ToString();
    }

    public void PressMapButton (int _mapIndex )  //go to map
    {
        if (mapSelections[_mapIndex].MapIsUnlock==true)   // you can play map
        {
            LevelSelectionPanels[_mapIndex].gameObject.SetActive(true);
            MapSelectionPanel.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Locked. Colect moor stars");
        }
    }

    public void BackToMapsButton () 
    {
        MapSelectionPanel.gameObject.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            LevelSelectionPanels[i].gameObject.SetActive(false);
        }
    }

    public void SceneTransition (string _sceneName) 
    {
        GameActive=true;
        MapSelectionPanel.gameObject.SetActive(false);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            LevelSelectionPanels[i].gameObject.SetActive(false);
        }
        SceneManager.LoadScene(_sceneName);
        
    }

    public void PlayGame () 
    {
       if(GameActive==true && TimeRemaininig>0)
       {
            TimeRemaininig -= Time.deltaTime;
            
            MapSelectionPanel.gameObject.SetActive(false);
            Debug.Log("gram");
       }
       else
       {
            MapSelectionPanel.gameObject.SetActive(true);
            GameActive=false;
            Debug.Log("koniec gry");
       }
    }
}

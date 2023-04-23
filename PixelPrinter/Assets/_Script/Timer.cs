using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Timer : MonoBehaviour
{
    
    public static Timer instance;
    public GameObject GameOverText;
    public GameObject YouWinText;
    public Image TimerForeground;
    float TimeRemaininig;
    float EndTiming;
    public float MaxTime = 10f;
    public float Sec3 = 3f;
    private PlaceObjectOnGrid PlaceObjectOnGrid;
    public List<GameObject> boxlist;
    public Transform cube;
    public List<Vector3> LevelTemplatePosition = new List<Vector3>();
    public bool WinLevel = false;
    public List<Vector3> BoxListPositionToCheck = new List<Vector3>();
    public bool GameActive;

     

    // Start is called before the first frame update
    void Start()
    {
        
        TimeRemaininig = MaxTime;
        EndTiming = Sec3;
        WinLevel = false;
        LevelTemplate();
    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
        BoxListPositionToCheck=PlaceObjectOnGrid.BoxListPosition;  
        CheckWin();

        if(TimeRemaininig>0 && WinLevel == false)
        {
            TimeRemaininig -= Time.deltaTime;
            TimerForeground.fillAmount = TimeRemaininig / MaxTime;
            Debug.Log("Have Time");
        }
        if(TimeRemaininig>0 && WinLevel == true)
        {
            if (EndTiming>0)
            {
            Debug.Log("YOU WIN");
            YouWinText.SetActive(true);
            EndTiming -= Time.deltaTime;
            
            }
            else
            {
            SceneManager.LoadScene(1);
            //GameActive=false; 
            
            } 
        }
        if(TimeRemaininig<0 && WinLevel == false)
        {
            GameOverText.SetActive(true);
            if (EndTiming>0)
            {
               EndTiming -= Time.deltaTime;
                Debug.Log("GAME OVER");
                
                
            }
            else
            {
            SceneManager.LoadScene(1);
            //GameActive=false;
            
            }

        // if(Input.GetMouseButtonUp(0))
        // {
        //     boxlist = new List <GameObject> (); 
        //     //print(PlaceObjectOnGrid);
        //     //Debug.Log("box");
        // }
    
           
        }
    }

    void checkBox(object cube)
    {
        Debug.Log("box");
    }


    public class BoxOK
    {
        public bool IsOnPlace;
        public Vector3 PositionBoxOK;
    

        public BoxOK(bool IsOnPlace, Vector3 PositionBoxOK)
        {
            this.IsOnPlace = IsOnPlace;
            this.PositionBoxOK = PositionBoxOK;
        }
     }
    
    
    private void LevelTemplate()
    {
        
        LevelTemplatePosition.Add(new Vector3(x:1,y:0.5f,z:1));
        LevelTemplatePosition.Add(new Vector3(x:2,y:0.5f,z:1));
        LevelTemplatePosition.Add(new Vector3(x:2,y:1.5f,z:1));
    }


    public void CheckWin()
{
    bool allMatch = true;

    if (LevelTemplatePosition.Count != BoxListPositionToCheck.Count) {
        return;
    }

    foreach (Vector3 item in LevelTemplatePosition)
    {
        bool matchFound = false;
        foreach (Vector3 obj in BoxListPositionToCheck) 
        {
            if (item.x == obj.x && item.y == obj.y && item.z == obj.z)
            {
                matchFound = true;
                break;
            }
        }
        if (!matchFound) {
            allMatch = false;
            break;
        }
    }

    if (allMatch) {
        WinLevel = true;
        Debug.Log("Match");
    } else {
        Debug.Log("NOT Match");
    }
}








    
//     public void CheckWin()
//     {

        
//         //  if (LevelTemplatePosition.Count == BoxListPositionToCheck.Count)
//         //  {

        
//             foreach (Vector3 item in LevelTemplatePosition)
//             {
//                 //TemplateBool = false;
//                 foreach(Vector3 obj in BoxListPositionToCheck) 
//                 {
//                     //BOXBool = false;
//                     if (item.x == obj.x && item.y == obj.y && item.z == obj.z)
//                     {
//                         WinLevel = true;
//                         Debug.Log("Match");
//                         //BOXBool=true;
//                     }
//                     else
//                     {
                        
//                         Debug.Log("NOT Match");
//                     }
//                 }   
//             }
//         //  }
//     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using System.IO;
using Microsoft.Win32;
using System.Globalization;

public class Timer : MonoBehaviour
{
    
    public static Timer instance;
    LevelManager levelstemplate;
    public GameObject GameOverText;
    public GameObject YouWinMenu;
    public GameObject GameElements;
    public TextMeshProUGUI RewardText;
    public TextMeshProUGUI BestScoreText;
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
    public int RewardStar =0;
    public int StarsCount =0;
    public int Stars =0;
    private int currentStarNumber=0;
    public int levelIndex;
    public int LevelSelectionLevelIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        LevelSelectionLevelIndex = PlayerPrefs.GetInt("ActualLevel",levelIndex); 

        //YouWinMenu.SetActive(false);
        TimeRemaininig = MaxTime;
        RewardStar =0;
        EndTiming = Sec3;
        WinLevel = false;
         
        Debug.Log("funkcja template: ");
        //levelstemplate = GameObject.FindGameObjectWithTag("time").GetComponent<LevelManager>();
        //levelstemplate.getLevelTemplates(LevelSelectionLevelIndex);
        // LevelTemplate();
        // Deg.Log("lista template: ");
        // Debug.Log(LevelTemplatePosition);
        Debug.Log("=======level: "+ LevelSelectionLevelIndex +" =============");
        Debug.Log("=======obecnie level gwiazdek: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber)+"=========");
        Debug.Log("Level: "+LevelSelectionLevelIndex);
    }
    //     void Update()
    // {
    //     PlaceObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
    //     BoxListPositionToCheck=PlaceObjectOnGrid.BoxListPosition;  
    //     CheckWin();

    //     if(TimeRemaininig>0 && WinLevel == false)
    //     {
    //         //YouWinMenu.SetActive(false);
    //         //UIManager.instance.DontDestroyOnLoad.SetActive(true);

    //         TimeRemaininig -= Time.deltaTime;
    //         TimerForeground.fillAmount = TimeRemaininig / MaxTime;
    //         Debug.Log("Have Time");
    //     }
    //     if(TimeRemaininig>0 && WinLevel == true)
    //     {
    //         if (EndTiming>0)
    //         {
    //         Debug.Log("YOU WIN");
    //         YouWinMenu.SetActive(true);
    //         //EndTiming -= Time.deltaTime;
    //         RewardStar=8;
    //         PlayerPrefs.SetInt("Reward",RewardStar);
    //         //UIManager.instance.Stars= UIManager.instance.Stars+8;
    //         }
    //         else
    //         {
    //         //SceneManager.LoadScene(1);
    //         //GameActive=false; 
            
    //         } 
    //     }
    //     if(TimeRemaininig<0 && WinLevel == false)
    //     {
    //         GameOverText.SetActive(true);
    //         if (EndTiming>0)
    //         {
    //             EndTiming -= Time.deltaTime;
    //             Debug.Log("GAME OVER");
    //             RewardStar=0;
    //             PlayerPrefs.SetInt("Reward",RewardStar); 
                
    //         }
    //         else
    //         {
    //         SceneManager.LoadScene(1);
    //         //GameActive=false;
            
    //         }

    //     // if(Input.GetMouseButtonUp(0))
    //     // {
    //     //     boxlist = new List <GameObject> (); 
    //     //     //print(PlaceObjectOnGrid);
    //     //     //Debug.Log("box");
    //     // }
    
           
    //     }
    // }



    // Update is called once per frame
    void Update()
    {
        
        LevelSelectionLevelIndex = PlayerPrefs.GetInt("ActualLevel",levelIndex); 

        
        //levelManager.getLevelTemplate(1);
        getLevelTemplates(LevelSelectionLevelIndex);
    
        PlaceObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
        BoxListPositionToCheck=PlaceObjectOnGrid.BoxListPosition;  
        //LevelTemplate();
        CheckWin();
        CountAndManu();

    }    
    private void CountAndManu()
    {    
        if(TimeRemaininig>0 && WinLevel == false)
            {
                    //YouWinMenu.SetActive(false);
                    //UIManager.instance.DontDestroyOnLoad.SetActive(true);

                TimeRemaininig -= Time.deltaTime;
                TimerForeground.fillAmount = TimeRemaininig / MaxTime;
                Debug.Log("Have Time");
            }    
        if(TimeRemaininig>0 && WinLevel == true)
            {
                if (EndTiming>0)
                {
                    Debug.Log("YOU WIN");
                
                    Debug.Log("TimeRemaininig:"+TimeRemaininig);
                    YouWinMenu.SetActive(true);
                    GameElements.SetActive(false);
                    EndTiming -= Time.deltaTime;

                    if (TimeRemaininig>(MaxTime*0.6))
                    {
                        Debug.Log("czas na 3gwiazdki:"+MaxTime*0.6);

                        int LvlSTarSave=PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber);
                        currentStarNumber=3;

                        if(LvlSTarSave==0)
                        {
                            Debug.Log("currentStarNumber:"+currentStarNumber);
                            Debug.Log("Save level star number"+LevelSelectionLevelIndex);
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                } 
                            RewardStar=3;
                            RewardText.text="Reward "+RewardStar.ToString()+" stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 3 3");
                            Debug.Log("gwiazdki"+RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                        }    
                        if (LvlSTarSave==1)
                        {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=2;
                            RewardText.text="Reward "+RewardStar.ToString()+" stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 3 2");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                        } 
                        if(LvlSTarSave==2)
                        {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=1;
                            RewardText.text="Reward "+RewardStar.ToString()+" stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 3 1");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                        }
                        if(LvlSTarSave==3)
                            {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            
                            RewardStar=0;
                            RewardText.text="You have all stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 3 0");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                            }
                    }
                        
                    if((MaxTime*0.4)<TimeRemaininig & TimeRemaininig<(MaxTime*0.6))      
                    {
                        Debug.Log("czas na 2gwiazdki od:"+MaxTime*0.4+ " - "+MaxTime*0.6);

                        int LvlSTarSave=PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber);
                        currentStarNumber=2;
                        if(LvlSTarSave==0)
                            {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                } 
                            RewardStar=2;
                            RewardText.text="Reward "+RewardStar.ToString()+" stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 2 2");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                            }
                        if(LvlSTarSave==1)
                            {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=1;
                            RewardText.text="Reward "+RewardStar.ToString()+" stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 2 1");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                            }
                        if(LvlSTarSave==2)
                            {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=0;
                            RewardText.text="1 stars left";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 2 0");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                            }
                    }
                    if((MaxTime*0.2)<TimeRemaininig & TimeRemaininig<(MaxTime*0.4))      
                    {
                        Debug.Log("czas na 1gwiazdke od:"+MaxTime*0.2+ " - "+MaxTime*0.4);
                        int LvlSTarSave=PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber);
                        currentStarNumber=1;
                        if(LvlSTarSave==0)
                            {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=1;
                            RewardText.text="Reward "+RewardStar.ToString()+" stars";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 1 1");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                            }
                        if(LvlSTarSave==1)
                            {
                            Debug.Log("currentStarNumber"+currentStarNumber);
                            Debug.Log("Save level star number"+LvlSTarSave);
                            Debug.Log(PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber));
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=0;
                            RewardText.text="2 stars left";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 1 0");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                            }
                    }
                    if((MaxTime*0.2)>TimeRemaininig)   
                    {
                            int LvlSTarSave=PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber);
                            currentStarNumber=0;
                            Debug.Log("currentStarNumber: "+currentStarNumber);
                            Debug.Log("Save level star number: "+LvlSTarSave);
                            if(currentStarNumber>LvlSTarSave)
                                {
                                    PlayerPrefs.SetInt("Lvl"+LevelSelectionLevelIndex,currentStarNumber); 
                                }
                            RewardStar=0;
                            RewardText.text="3 stars left";
                            BestScoreText.text="Best Score: "+PlayerPrefs.GetInt("Lvl"+LevelSelectionLevelIndex).ToString()+" stars";
                            Debug.Log("otrzymane 0 0");
                            Debug.Log(RewardStar);
                            PlayerPrefs.SetInt("Reward",RewardStar); 
                                
                    }        
                        
                        
                    
                    
                    //UIManager.instance.Stars= UIManager.instance.Stars+8;
                    
                    else
                        {
                        //SceneManager.LoadScene(1);
                        //GameActive=false; 
                        
                        } 
                }
            }
        if(TimeRemaininig<0 && WinLevel == false)
            {
            GameOverText.SetActive(true);
            if (EndTiming>0)
                {
                    EndTiming -= Time.deltaTime;
                    Debug.Log("GAME OVER");
                    RewardStar=0;
                    PlayerPrefs.SetInt("Reward",RewardStar); 
                        
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
        // UpdateStarCount();
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
        
        foreach (Vector3 position in LevelTemplatePosition)
        {
        Debug.Log(position.ToString());
        }
    }
    // private void LevelTemplate1()
    // {
        
    //     LevelTemplatePosition.Add(new Vector3(x:1,y:0.5f,z:1));
    //     LevelTemplatePosition.Add(new Vector3(x:2,y:0.5f,z:1));
    //     LevelTemplatePosition.Add(new Vector3(x:3,y:0.5f,z:1));
    // }

    public void CheckWin()
    {
        bool allMatch = true;

        if (LevelTemplatePosition.Count != BoxListPositionToCheck.Count) 
        {
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
            if (!matchFound) 
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch) 
        {
            WinLevel = true;
            Debug.Log("Match");
        } 
        else 
        {
            Debug.Log("NOT Match");
        }
    }

    public void UpdateStarCount () 
    {
        Stars=PlayerPrefs.GetInt("Stars");
        StarsCount=Stars+RewardStar;
       
        Debug.Log(StarsCount);
        PlayerPrefs.SetInt("Stars",StarsCount);
    }


   

 public void getLevelTemplates (int level) 
  {
    LevelTemplatePosition.Clear();

    if(level==1)
        {
            LevelTemplatePosition.Add(new Vector3(x:0,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:1,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:2,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:1,y:1.5f,z:1));
        }
    else if(level==2)
        {
            LevelTemplatePosition.Add(new Vector3(x:1,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:2,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:3,y:0.5f,z:1));
        }
    else if(level==3)
        {
            LevelTemplatePosition.Add(new Vector3(x:1,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:2,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:3,y:0.5f,z:1));
        }

    else
        {
            // Jeśli level nie jest ani 1, ani 2, wyczyść listę LevelTemplatePosition
            LevelTemplatePosition.Clear();
            Debug.Log("Pusta lista template");  
        }  

  }


// private void LevelTemplate1(int levelNumber)
//     {
//         string filePath = Application.dataPath+"/_Script/Level.txt";
//         Debug.Log(filePath);
//         if (File.Exists(filePath))
//         {
//             StreamReader reader = new StreamReader(filePath);
//             string line;
//             // Przeszukiwanie pliku linia po linii
//         while ((line = reader.ReadLine()) != null)
//         {
//             // Sprawdzenie, czy linia zawiera informacje o danym poziomie
//             if (line.StartsWith("Level: " + levelNumber.ToString()))
//             {
//                 Debug.Log("Linia:" + line);
//                 // Przesunięcie na kolejną linię
//                 line = reader.ReadLine();
//                 Debug.Log("Linia:" + line);
//                 // Odczytywanie współrzędnych, dopóki nie napotkamy linii rozpoczynającej się od "Level: "
//                 while (line != null && !line.StartsWith("Level: "))
//                 {
//                         string[] coordinates = line.Split(',');

//                         if (coordinates.Length == 3)
//                         {
//                             float x, y, z;

//                             if (float.TryParse(coordinates[0], out x) && float.TryParse(coordinates[1], out y) && float.TryParse(coordinates[2], out z))
//                             {
//                                 LevelTemplatePosition.Add(new Vector3(x, y, z));
//                             }
//                             else
//                             {
//                                 Debug.LogError("to 1 Invalid line format in file " + filePath);
//                             }
                            
//                             // Wyświetlenie wyniku podziału linii
//                             Debug.Log("Coordinates: " + string.Join(", ", coordinates));
//                         }
//                         else
//                         {
//                             Debug.LogError(" to 2 Invalid line format in file " + filePath);
//                             break;
//                         }
                        
//                         // Przesunięcie na kolejną linię
//                         line = reader.ReadLine();
//                 }

//                 // Zakończenie pętli, gdy odczytane zostały wszystkie współrzędne dla danego poziomu
//                 break;
//             }


                
//             else
//             {
//                 Debug.LogError("File not found: " + filePath);
//             }
            

            
//         }
//     }
//     }

//     public void CheckWin1()
//     {
//         LevelTemplate(); // Wywołanie funkcji LevelTemplate

//         bool allMatch = true;

//         if (LevelTemplatePosition.Count != BoxListPositionToCheck.Count)
//         {
//             return;
//         }

//         foreach (Vector3 item in LevelTemplatePosition)
//         {
//             bool matchFound = false;
//             foreach (Vector3 obj in BoxListPositionToCheck)
//             {
//                 if (item.x == obj.x && item.y == obj.y && item.z == obj.z)
//                 {
//                     matchFound = true;
//                     break;
//                 }
//             }
//             if (!matchFound)
//             {
//                 allMatch = false;
//                 break;
//             }
//         }

//         if (allMatch)
//         {
//             WinLevel = true;
//             Debug.Log("Match");
//         }
//         else
//         {
//             Debug.Log("NOT Match");
//         }
//     }

// private void PrintList(List<Vector3> list)
// {
//     foreach (Vector3 position in list)
//     {
//         Debug.Log(position.ToString());
//     }
// }
    





    
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

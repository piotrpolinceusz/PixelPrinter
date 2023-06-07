using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
     public static LevelManager instance;
     public List<Vector3> LevelTemplatePosition = new List<Vector3>();

      
       
  public void getLevelTemplates (int level) 
  {
    LevelTemplatePosition.Clear();

    if(level==1)
        {
            LevelTemplatePosition.Add(new Vector3(x:1,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:2,y:0.5f,z:1));
            LevelTemplatePosition.Add(new Vector3(x:2,y:1.5f,z:1));
        }
    else if(level==2)
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



}

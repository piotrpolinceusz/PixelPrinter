using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public GameObject GameOverText;
    public Image TimerForeground;
    float TimeRemaininig;
    float EndTiming;
    public float MaxTime = 10f;
    public float Sec3 = 3f;

    // Start is called before the first frame update
    void Start()
    {
        TimeRemaininig = MaxTime;
        EndTiming = Sec3;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeRemaininig>0)
        {
            TimeRemaininig -= Time.deltaTime;
            TimerForeground.fillAmount = TimeRemaininig / MaxTime;
        }
        else
        {
            GameOverText.SetActive(true);
            if (EndTiming>0)
            {
               EndTiming -= Time.deltaTime;
            }
            else
            {
            SceneManager.LoadScene(0);   
            }
            
        }
        
            
    }
    
    
}

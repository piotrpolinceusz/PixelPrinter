using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLload : MonoBehaviour


{
public static SaveLload instance;
public int StarsCount=0;
public int Stars=0;
public int RewardStar =0;

void Start()
    {
        Stars=PlayerPrefs.GetInt("Stars");
        RewardStar=PlayerPrefs.GetInt("Reward");
    }

    public void SaveStars () {
        Stars=PlayerPrefs.GetInt("Stars");
        //StarsCount=Stars+RewardStar;
        PlayerPrefs.SetInt("Stars",StarsCount);
    }
    public void UpdateStarCount () {
        
        
        StarsCount=Stars+RewardStar;
        Debug.Log(StarsCount);
        PlayerPrefs.SetInt("Stars",StarsCount);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public static UIManager instance;
    public bool MapIsUnlock = false;
    public GameObject LockGo;
    public GameObject UnLockGo;

    public int MapIndex; // index of this map
    public int Questnumber; // how many stars reach to unlock map
    public int StartLevel;
    public int EndLevel;



    private void Update()
    {
        UpdateMapStatus();//potem wywal ale tylko dla testow
        UnlockMap();
    }
    
    private void UpdateMapStatus()
    {
        if (MapIsUnlock)//possible to game
        {
            UnLockGo.gameObject.SetActive(true);
            LockGo.gameObject.SetActive(false);
        }
        else //unlock privious maps
        {
            UnLockGo.gameObject.SetActive(false);
            LockGo.gameObject.SetActive(true);
        }

    }

    private void UnlockMap() // if you reach stars number you unlock map
    {
        if(UIManager.instance.Stars >= Questnumber)
        {
           MapIsUnlock = true;
        }
        else
        {
            MapIsUnlock = false;
        }
    }


}

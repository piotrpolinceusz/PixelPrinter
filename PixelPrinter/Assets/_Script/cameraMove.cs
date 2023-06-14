using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Camera TopCamera;
    public Camera TreeDCamera;
    public GameObject Plate;
    public int levelIndex;
    public int LevelSelectionLevelIndex;
    public PlaceObjectOnGrid placeObjectOnGrid;

    void Start()
    {
        LevelSelectionLevelIndex = PlayerPrefs.GetInt("ActualLevel",levelIndex);

    }
    void Update ()
    {
      CameraPositionBySize ();   
      PlatePosition();
    }

    public void CameraPosition(float x, float z, float size)
    {// Przesuń kamerę 1 do określonego punktu
        Vector3 newPosition1 = new Vector3(x, 10f, z);
        TopCamera.transform.position = newPosition1;
        Vector3 newRotation1 = new Vector3(90f, 0f, 0f);
        TopCamera.transform.rotation = Quaternion.Euler(newRotation1);
        TopCamera.orthographicSize=size;

        // Ustaw rotację kamery 2
        Vector3 newRotation2 = new Vector3(20f, 45f, 0f);
        TreeDCamera.transform.rotation = Quaternion.Euler(newRotation2);
    }

    public void CameraPositionBySize () 
    {
        
        if(placeObjectOnGrid.width==9)
        {
            CameraPosition(4f,6f,10); 
        } 
        if(placeObjectOnGrid.width==8)
        {
            CameraPosition(3.5f,5f,9); 
        } 
        if(placeObjectOnGrid.width==7)
        {
            CameraPosition(3f,4f,8); 
        } 
        if(placeObjectOnGrid.width==6)
        {
            CameraPosition(2.5f,4f,7); 
        } 
        if(placeObjectOnGrid.width==5)
        {
            CameraPosition(2f,3f,6); 
        } 
        if(placeObjectOnGrid.width==4)
        {
            CameraPosition(1.5f,2.5f,5); 
        }
        if(placeObjectOnGrid.width==3)
        {
            CameraPosition(1f,1.5f,4); 
        }  


    }
    public void PlatePosition()
    {
        if(placeObjectOnGrid.width==9)
        {
            Plate.transform.position=new Vector3(4.5f,-0.1f,4.5f); 
        } 
        if(placeObjectOnGrid.width==8)
        {
            Plate.transform.position=new Vector3(4f,-0.1f,4f); 
        } 
        if(placeObjectOnGrid.width==7)
        {
           Plate.transform.position=new Vector3(3f,-0.1f,3f); 
        } 
        if(placeObjectOnGrid.width==6)
        {
            Plate.transform.position=new Vector3(2.5f,-0.1f,225f); 
        } 
        if(placeObjectOnGrid.width==5)
        {
           Plate.transform.position=new Vector3(2f,-0.1f,2f); 
        } 
        if(placeObjectOnGrid.width==4)
        {
            Plate.transform.position=new Vector3(1.5f,-0.1f,1.5f); 
        }
        if(placeObjectOnGrid.width==3)
        {
            Plate.transform.position=new Vector3(1f,-0.1f,1f); 
        }  

    }

}

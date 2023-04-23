using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowMouse : MonoBehaviour
{
    private PlaceObjectOnGrid PlaceObjectOnGrid;
    private Node node;
    private Node[,] nodesbase;
    public int zPosition;
    public bool isOnGrid;
    
    // Start is called before the first frame update
    void Start()
    {
        PlaceObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
        var level=zPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnGrid)
        
        //{
        //foreach (var node in nodesbase)
        {
        var levelbox=zPosition+0.5f;  
            
        transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(x:0,y:levelbox,z:0);
        //transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(x:0,y:0.5f,z:0);
        //print(transform.position);
        //}
        }
    }
}

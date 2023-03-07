using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowMouse : MonoBehaviour
{
    private PlaceObjectOnGrid PlaceObjectOnGrid;
    public bool isOnGrid;

    // Start is called before the first frame update
    void Start()
    {
        PlaceObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnGrid)
        {
        transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(x:0,y:0.5f,z:0);
        //print(transform.position);
        }
    }
}

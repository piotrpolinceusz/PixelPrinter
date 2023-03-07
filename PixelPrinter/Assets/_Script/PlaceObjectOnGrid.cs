using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform cube;
    public Transform OnMousePrefabe;

    [SerializeField]private int height;
    [SerializeField] int width;

    public Vector3 smootMousePosition;
    private Vector3 mousePosition;
    private Node[,] nodes;
    private Plane plane;



    void Start()
    {
        CreateGrid();
        plane = new Plane(inNormal:Vector3.up,inPoint:transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePositionOnGrid();
        ClickAndDestroy();

    }

    void ClickAndDestroy()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    smootMousePosition = mousePosition;
                    mousePosition.y = 0;
                    mousePosition = Vector3Int.RoundToInt(mousePosition);
                    Destroy(bc.gameObject);
                    foreach (var node in nodes)
                    {
                        if (node.cellPosition == mousePosition && node.isPlaceble==false)
                        {
                            node.isPlaceble = true;
                        }
                        
                    }
                    
                } 
        
            }
        }
    }

    void GetMousePositionOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out var enter))
        {
            mousePosition = ray.GetPoint(enter);
            print(mousePosition);
            smootMousePosition = mousePosition;
            mousePosition.y = 0;
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            foreach (var node in nodes)
            {
                if (node.cellPosition == mousePosition && node.isPlaceble)
                {
                    if(Input.GetMouseButtonUp(0) && OnMousePrefabe !=null)
                    {
                        node.isPlaceble = false;
                        OnMousePrefabe.GetComponent<ObjectFollowMouse>().isOnGrid = true;
                        OnMousePrefabe.position = node.cellPosition + new Vector3(x:0,y:0.5f,z:0);
                        OnMousePrefabe = null;
                    }
                }
            }
        }
    }

    public void OnMouseClickOnUI()
        {
            if(OnMousePrefabe == null)
            {
                OnMousePrefabe = Instantiate(cube,mousePosition,Quaternion.identity);
            }
        }
    

    private void CreateGrid()
    {
        nodes= new Node[width, height];
        var name = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(x:i,y:0,z:j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell " + name;
                nodes[i,j]= new Node(isPlaceble:true, worldPosition, obj);
                name++;
            }
        }
    }
}


public class Node
{
    public bool isPlaceble;
    public Vector3 cellPosition;
    public Transform obj;

    public Node(bool isPlaceble, Vector3 cellPosition, Transform obj)
    {
        this.isPlaceble = isPlaceble;
        this.cellPosition = cellPosition;
        this.obj = obj;
    }
}

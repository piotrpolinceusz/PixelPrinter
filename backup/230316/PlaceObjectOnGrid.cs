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
    private Plane plane1;
    List<int> nodenames = new List<int>();
    private int L1 = 0;
    public MeshRenderer PLS;

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
                        Vector3 StuckNodePosition = node.cellPosition + new Vector3(x:0,y:1f,z:0);
                            Transform obj = Instantiate(gridCellPrefab,StuckNodePosition, Quaternion.identity);
                            //var L1 = 0;
                            //print(lastname);
                            //var name=lastname+1;
                            //print(name);
                            obj.name = "Cell H1" + L1;
                            nodes[1,1]= new Node(isPlaceble:true, StuckNodePosition, obj,havebase:true,1);
                            PLS.enabled=false;
                            L1=L1+1;
                            //nodenames.Add(name);
                        
                    }
                }
            }
        }
        if (plane1.Raycast(ray, out var enter1))
        {
            mousePosition = ray.GetPoint(enter1);
            print(mousePosition);
            smootMousePosition = mousePosition;
            mousePosition.y = 1;
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            
            foreach (var node in nodes)
            {
                if (node.cellPosition == mousePosition && node.isPlaceble)
                {
                    if(Input.GetMouseButtonUp(0) && OnMousePrefabe !=null)
                    {
                        node.isPlaceble = false;
                        OnMousePrefabe.GetComponent<ObjectFollowMouse>().isOnGrid = true;
                        OnMousePrefabe.position = node.cellPosition + new Vector3(x:0,y:1.5f,z:0);
                        OnMousePrefabe = null;
                        Vector3 StuckNodePosition = node.cellPosition + new Vector3(x:0,y:1f,z:0);
                            Transform obj = Instantiate(gridCellPrefab,StuckNodePosition, Quaternion.identity);
                            //var L1 = 0;
                            //print(lastname);
                            //var name=lastname+1;
                            //print(name);
                            obj.name = "Cell H2" + L1;
                            nodes[1,1]= new Node(isPlaceble:true, StuckNodePosition, obj,havebase:true,2);
                            L1=L1+1;
                            //nodenames.Add(name);
                        
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
        nodenames.Add(name);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(x:i,y:0,z:j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell " + name;
                nodes[i,j]= new Node(isPlaceble:true, worldPosition, obj,havebase:false,0);
                name++;
                nodenames.Add(name);
                
            }
        }
    }
}


public class Node
{
    public bool isPlaceble;
    public Vector3 cellPosition;
    public Transform obj;
    public bool havebase;
    public int zPosition;
    

    public Node(bool isPlaceble, Vector3 cellPosition, Transform obj,bool havebase, int zPosition)
    {
        this.isPlaceble = isPlaceble;
        this.cellPosition = cellPosition;
        this.obj = obj;
        this.havebase = havebase;
        this.zPosition = zPosition;
    }
}

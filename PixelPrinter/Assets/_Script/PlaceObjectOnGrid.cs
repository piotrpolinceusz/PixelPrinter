using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlaceObjectOnGrid : MonoBehaviour
{
   
    public Transform gridCellPrefab;
    public Transform cube;
    public Transform OnMousePrefabe;
    List<GameObject> cubeList = new List<GameObject>();
    
    //public Transform GameObject;

    public int cosheight;
    public int coswidth;
    private int gridheight=7;
    private int gridwidth=7;
    //private int level;

    public Vector3 smootMousePosition;
    private Vector3 mousePosition;
    private Node[,] nodesbase;
    private Plane plane;
    private Plane plane1;
    public static List<Vector3> BoxListPosition = new List<Vector3>();
    public List<Vector3> BoxPoints{ get; set; }
    public int LevelSelectionLevelIndex;
    public int levelIndex;
    //public List<GameObject> boxes = new List<GameObject>();
    //private int L1 = 0;
    

    void Start()
    {
     
        LevelSelectionLevelIndex = PlayerPrefs.GetInt("ActualLevel",levelIndex); 
        Debug.Log("Mam level: "+LevelSelectionLevelIndex);
        PlateSize(LevelSelectionLevelIndex);
        CreateGrid();
        plane = new Plane(inNormal:Vector3.up,inPoint:transform.position);
        BoxListPosition.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePositionOnGrid();
        
        ClickAndDestroy();
        
        // Debug.Log("lista cell");
        // foreach(var cells in nodenames)
        // {
        // print(cells.name);
        // }

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
                    Vector3 destroyedPosition = bc.transform.position;
                    smootMousePosition = mousePosition;
                    mousePosition.y = 0;
                    mousePosition = Vector3Int.RoundToInt(mousePosition);
                    Destroy(bc.gameObject);

                    
                    foreach (var node in nodesbase)
                    {
                        if (node.cellPosition == mousePosition && node.isPlaceble==false && node.zPosition!=0)
                        { 
                            var level = node.zPosition;
                            node.zPosition= level-1;
                            BoxListPosition.Remove(new Vector3(mousePosition.x, destroyedPosition.y, mousePosition.z));
                        }
                        if (node.cellPosition == mousePosition && node.isPlaceble==false && node.zPosition==0)
                        { 
                            node.isPlaceble = true;
                            BoxListPosition.Remove(new Vector3(mousePosition.x, destroyedPosition.y, mousePosition.z));
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
            
            //print(mousePosition);
            smootMousePosition = mousePosition;
            mousePosition.y = 0;
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            foreach (var node in nodesbase)
            {
            
                if (node.cellPosition == mousePosition && node.isPlaceble )
                {
                    
                    if(Input.GetMouseButtonUp(0) && OnMousePrefabe !=null)
                    {   
                        
                        node.isPlaceble = false;
                        
                        OnMousePrefabe.GetComponent<ObjectFollowMouse>().isOnGrid = true;
                        OnMousePrefabe.position = node.cellPosition + new Vector3(x:0,y:0.5f,z:0);
                        BoxListPosition.Add(OnMousePrefabe.position);
                        //print(BoxListPosition);
                        OnMousePrefabe = null;
                        node.zPosition=1;
                        PrintPoints();
                        //cubeList.Add(OnMousePrefabe.gameObject);  
                        
                       
                        
                    }
                  
                }
            }
        }
        if (plane.Raycast(ray, out var enter1))
         {
            
             mousePosition = ray.GetPoint(enter1);
             //print(mousePosition);
             smootMousePosition = mousePosition;
             mousePosition.y = 0;
             mousePosition = Vector3Int.RoundToInt(mousePosition);
            foreach (var node in nodesbase)
             {
             
                if (node.cellPosition == mousePosition && node.isPlaceble==false && node.zPosition!=0)
                {
                    if(Input.GetMouseButtonUp(0) && OnMousePrefabe !=null)
                    {
                        var level = node.zPosition;
                        var level1=0.5f+level;
                        print(level1);
                        OnMousePrefabe.GetComponent<ObjectFollowMouse>().isOnGrid = true;
                        OnMousePrefabe.position = node.cellPosition + new Vector3(x:0,y:level1,z:0);
                        BoxListPosition.Add(OnMousePrefabe.position);
                        //print(BoxListPosition);
                        OnMousePrefabe = null;
                        node.zPosition++;
                        PrintPoints();
                        
                        
                    }
                }
             }
        }
    }

    // public void PrintObject()
    //     {
    //         foreach (var SpecificBox in BoxListPosition)
    //         {
    //             //Debug.Log(SpecificBox.Name);
    //             Debug.Log(SpecificBox.x);
    //             Debug.Log(SpecificBox.y);
    //             Debug.Log(SpecificBox.z);
    //         }
                
            
    //     }


    public void PrintPoints()
        {
            foreach (Vector3 v in BoxListPosition)
            {
        Debug.Log(v);
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
        
        
        nodesbase= new Node[gridwidth, gridheight];
        var CellBaseNumber = 0;
        
        
        for (int i = 0; i <gridwidth; i++)
        {
            for (int j = 0; j < gridheight; j++)
            {
                Vector3 worldPosition = new Vector3(x:i,y:0,z:j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                
                obj.name = "Cell " + CellBaseNumber;
                nodesbase[i,j]= new Node(isPlaceble:true, worldPosition, obj,havebase:false,0);
                CellBaseNumber++;
                
                
                
            }
        }
    }
    // public void GetCubePosition()
    // {
    //     GameObject myGameObject = GameObject.Find(Cube);

    //     // Pobierz listę komponentów
    //     Component[] components = myGameObject.GetComponents<Component>();

    //     // Wyświetl nazwy komponentów w konsoli
    //     foreach (Component component in components)
    //     {
    //         Debug.Log(component.GetType().Name);
    
    //     }
    // }

    public void PlateSize(int Level)
    {
        if(Level==1)
        {
            gridwidth=3;
            gridheight=3;
            Debug.Log(gridwidth+", "+gridheight);
        
        } 
        if(Level==2)
        {
            gridwidth=4;
            gridheight=4;
            Debug.Log(gridwidth+", "+gridheight);
        } 
        else
        {
            gridwidth=5;
            gridheight=5;
            Debug.Log("Ta trzecia opcja 5x5");
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
    






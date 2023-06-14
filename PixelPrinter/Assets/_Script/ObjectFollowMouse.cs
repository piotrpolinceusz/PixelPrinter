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
    // public Color32 startColor = new Color32(255, 255, 255, 255); // Kolor początkowy (poziom 0)
    // public Color32 endColor = new Color32(102, 102, 102, 255); // Kolor końcowy (najwyższy poziom)
    // public Renderer boxRenderer; // Referencja do komponentu Renderer

    
    // Start is called before the first frame update
    void Start()
    {
        PlaceObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
        var level=zPosition;
        // boxRenderer = GetComponent<Renderer>();
        // boxRenderer.material.color = startColor;
    }

    // Update is called once per frame

    // =============NIEDZIALA WSTAWIANIE ALE KOLOR SIE ZMIENIA I WSKAKUJE NA NASTEPNY POZIOM=================
// void Update()
// {
//     if (!isOnGrid)
//     {
//         RaycastHit hit;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//         if (Physics.Raycast(ray, out hit))
//         {
//             var otherBox = hit.collider.GetComponent<ObjectFollowMouse>();

//             if (otherBox != null && otherBox.isOnGrid && otherBox.zPosition >= zPosition)
//             {
//                 zPosition = otherBox.zPosition + 1;
//             }
//         }

//         var levelbox = zPosition + 0.5f;
//         transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(0, levelbox, 0);
//         boxRenderer.material.color = CalculateColor();
//     }
// }

// private Color CalculateColor()
// {
//     float t = (float)zPosition / (float)PlaceObjectOnGrid.maxLevel; // Obliczanie wartości normalizowanej dla poziomu
//     return Color.Lerp(Color.white, Color.grey, t); // Interpolacja liniowa między białym (#FFFFFF) a szarym (#666666) na podstawie wartości t
// }

//===================================================================================================================

//===============dzialajacy z kolorem ale wolno=================
// void Update()
// {
//     if (!isOnGrid)
//     {
//         RaycastHit hit;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//         if (Physics.Raycast(ray, out hit))
//         {
//             var otherBox = hit.collider.GetComponent<ObjectFollowMouse>();

//             if (otherBox != null && otherBox.isOnGrid && otherBox.zPosition >= zPosition)
//             {
//                 zPosition = otherBox.zPosition + 1;
//             }
//         }

//         var levelbox = zPosition + 0.5f;
//         transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(0, levelbox, 0);

//         // Oblicz wartość interpolacji
//         float t = (float)zPosition / (float)(PlaceObjectOnGrid.maxLevel + 1);
//         renderer.material.color = Color32.Lerp(startColor, endColor, t);
//     }
// }
//===============================================


    //===========DZIALAJACY Z CHATA=================
//    void Update()
//     {
//         if (!isOnGrid)
//         {
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//             if (Physics.Raycast(ray, out hit))
//             {
//                 var otherBox = hit.collider.GetComponent<ObjectFollowMouse>();

//                 if (otherBox != null && otherBox.isOnGrid && otherBox.zPosition >= zPosition)
//                 {
//                     zPosition = otherBox.zPosition + 1;
//                 }
//             }

//             var levelbox = zPosition + 0.5f;
//             transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(0, levelbox, 0);
//         }
//     }
//==============================================


    //============dzoialajacy================ORGINALNY
    void Update()
    {
        if (!isOnGrid)
        
        //{
        // foreach (var node in nodesbase)
        {
        var levelbox=zPosition+0.5f;  
            
        transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(x:0,y:levelbox,z:0);
        // transform.position = PlaceObjectOnGrid.smootMousePosition + new Vector3(x:0,y:0.5f,z:0);
        //print(transform.position);
        //}
        }
    }
    // //=====================================
}

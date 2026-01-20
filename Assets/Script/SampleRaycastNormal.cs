using UnityEngine;

public class SampleRaycastNormal : MonoBehaviour
{

    public Transform objectToPlace;
    public Camera GameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit))
        {
            objectToPlace.position = hit.point; 
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
}

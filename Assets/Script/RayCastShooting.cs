using UnityEngine;

public class RayCastShooting : MonoBehaviour
{
    public Camera PlayerCamera;
    public float distance = 100f;
    public LayerMask TargetMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("LEFT CLICK");
            shoot();
        }
    }
    public void shoot()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, TargetMask))
        {
           

            
            
                hit.collider.GetComponentInParent<FiringGameEnemy>().Hit();

           

            Debug.DrawLine(ray.origin, hit.point, Color.yellow, 0.2f);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.grey, 0.2f);
        }
    }
}
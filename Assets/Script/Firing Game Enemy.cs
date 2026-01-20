using UnityEngine;
using UnityEngine.TestTools;

public class FiringGameEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public  int Scorevalue = 10;
    Vector3 startPos;
    bool hit;
   public bool lockhit;
    void Start()
    {
        startPos = transform.position;
        FiringGame.Instance.RegisterTarget(this);
    }

    void Update()
    {
        if (hit) return;

        float x = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = startPos + new Vector3(x, 0, 0);
    }

    public void Hit()
    {
        if (hit) return;

        hit = true;
        FiringGame.Instance.AddScore(Scorevalue);
        FiringGame.Instance.TargetHit();
        Debug.Log("ENEMY HIT");

        gameObject.SetActive(false); 
    }
    public void ResetTarget()
    {
        hit = false;
        transform.position = startPos;
        gameObject.SetActive(true);
    }
}

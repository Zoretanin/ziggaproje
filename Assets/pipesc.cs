using UnityEngine;

public class pipesc : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}


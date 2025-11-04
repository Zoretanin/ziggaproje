using UnityEngine;

public class coinSC : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    void Start()
    {

    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}

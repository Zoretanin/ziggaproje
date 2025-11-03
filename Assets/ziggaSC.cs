using Unity.VisualScripting;
using UnityEngine;

public class ziggaSC : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpForce;
    public LogicManager logic;
    public bool isAlive = true;
    public float deadZoneY = -7;
    
    void Start()
    {
      logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * jumpForce;
        }
    
        if (transform.position.y < deadZoneY && isAlive == true)
        {
            logic.gameOver();
            isAlive = false;
        }


    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
      logic.gameOver();
      isAlive = false;

    }









}

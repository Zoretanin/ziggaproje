using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ziggaSC : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpForce;
    public LogicManager logic;
    public bool isAlive = true;
    public float deadZoneY = -7;
    private int coinCounter = 0;
    public Text counterText;
    
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
        if (collision.gameObject.CompareTag("pipe"))
        {
           logic.gameOver();
           isAlive = false;
        }
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter += 1;
            counterText.text = "Coins: " + coinCounter;
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0) + 1);
        }
    }








}

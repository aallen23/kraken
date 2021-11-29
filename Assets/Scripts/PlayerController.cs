using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float speed = 8.0f;
    public float xRange = 8;
    public float yRange = 4;
    public GameObject squidInkPrefab;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //keeps player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, 0);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, 0);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, 0);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, 0);
        }


        //gives left to right movement to the player
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //gives forward and backword movement to the player
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile pizza from the player
            Instantiate(squidInkPrefab, transform.position, transform.rotation);
        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("Collided");

        if (!other.gameObject.CompareTag("SquidInk"))
        {
            if (other.gameObject.CompareTag("Ship"))
            {
                gameManager.UpdateScore(10);
            }

            if (other.gameObject.CompareTag("Bullet"))
            {
                gameManager.UpdateHealth();
            }

            Destroy(other.gameObject);
        }


    }



}

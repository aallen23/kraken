using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    //movement script tied to ship objects


    public float speed = 3.0f;
    private float xRange = 15;
    private float yRange = 12;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            Destroy(gameObject);
            gameManager.UpdateHealth();
        }

        if (transform.position.y < -yRange || transform.position.y > yRange)
        {
            Destroy(gameObject);
            gameManager.UpdateHealth();
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("SquidInk"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(10);
        }


    }
}

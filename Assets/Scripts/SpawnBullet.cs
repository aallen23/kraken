using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    //spawns bullets on a regular spawn rate from enemy ships

    public GameObject bullet;
    public GameObject shipObject;
    private Rigidbody2D bulletRb;
    private Vector3 spawnPos;
    public float bulletSpawnRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        shipObject = this.gameObject;
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.AddForce(Vector3.forward * 500);
        StartCoroutine(Bullet());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator Bullet()
    {
        yield return new WaitForSeconds(bulletSpawnRate);
        spawnPos = shipObject.transform.position;
        Instantiate(bullet, spawnPos, shipObject.transform.rotation);
    }
}

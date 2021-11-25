using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    //spawns bullets on a regular spawn rate from enemy ships

    public GameObject bullet;
    public GameObject shipObject;
    private Rigidbody bulletRb;
    private Vector3 spawnPos;
    public float bulletSpawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        shipObject = this.gameObject;
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(Vector3.forward * 1000);
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

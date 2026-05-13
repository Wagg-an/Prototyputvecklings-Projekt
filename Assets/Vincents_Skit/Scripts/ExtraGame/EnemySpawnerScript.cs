using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerScript : MonoBehaviour
{
    
    public GameObject corner1;
    public GameObject corner2;
    public GameObject enemySmall;
    public GameObject enemyBig;

    public float force = 10f;
    Transform spawnPoint; 
    public float waitTime = 2f;

    bool done = true;

    public bool play = false;

    void Start()
    {   
        Transform temp = transform;
        spawnPoint = temp;
    }

    
    void Update()
    {
        handleSpawn();
    }


    void handleSpawn()
    {
        while(play)
        {
            if(done)
            {
                spawnEnemy(enemySmall);
                done = false;
            }
        }
    }

    void spawnEnemy(GameObject type)
    {
        Vector3 xPoint = new Vector3(Random.Range(corner1.transform.position.x, corner2.transform.position.x),spawnPoint.position.y,spawnPoint.position.z);
        spawnPoint.position = xPoint;
        GameObject enemy = Instantiate(type, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        rb.AddForce(-spawnPoint.up * force, ForceMode.Impulse);
        StartCoroutine(WaitTimer());
    }

    IEnumerator WaitTimer()
    { 
        yield return new WaitForSeconds(waitTime);
        done = true;
    }

}

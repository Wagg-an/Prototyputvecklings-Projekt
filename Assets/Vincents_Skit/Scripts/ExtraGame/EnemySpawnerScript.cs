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
    public float waitTime = 3f;

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


    void OnEnable() 
    {
        waitTime = 3f;
        done = true;
    }


    void handleSpawn()
    {
        if(done)
        {
            int randNum = Random.Range(1, 6);
            if(randNum >=2)
            {
                spawnEnemy(enemySmall);
                done = false;
            }
            else if(randNum < 2)
            {
                spawnEnemy(enemyBig);
                done = false;
            }
            waitTime -= 0.03f;
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

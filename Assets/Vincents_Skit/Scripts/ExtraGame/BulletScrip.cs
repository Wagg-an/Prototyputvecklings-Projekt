using UnityEngine;

public class BulletScrip : ShotBaseClass
{
    public GameObject enemy;
    string enemyTag;

    void Start()
    {
        enemyTag = enemy.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == enemyTag)
        {
            col.gameObject.GetComponent<ShotBaseClass>().shot();
        }
        else
        {
            //Destoy(gameObject);
        }
    }

    
}

using UnityEngine;

public class BulletScrip : ShotBaseClass
{
    public GameObject enemy;
    string enemyTag;

    public GameObject roof;
    string roofTag;

    void Start()
    {
        enemyTag = enemy.tag;
        roofTag = roof.tag;
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
            Destroy(gameObject);

        }
        else if(col.gameObject.tag == roofTag)
        {
            Destroy(gameObject);
        }
    }

    
}

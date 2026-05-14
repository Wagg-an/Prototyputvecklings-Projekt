using UnityEngine;

public class BulletScrip : MonoBehaviour 

{

    public GameObject roof;
    string roofTag;

    void Start()
    {
        roofTag = roof.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.tag == roofTag)
        {
            Destroy(gameObject);
        }
    }

    
}

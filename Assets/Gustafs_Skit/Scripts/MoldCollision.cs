using UnityEngine;

public class MoldCollision : MonoBehaviour
{
    public GameObject WholeKeyMold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "KeyMold2")
        {
            Instantiate(WholeKeyMold, transform.position, Quaternion.identity);


            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}

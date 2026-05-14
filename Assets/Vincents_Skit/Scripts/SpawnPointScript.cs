using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    Vector3 startingPos;
    public GameObject killplane;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == killplane.name)
        {
            transform.position = startingPos;
        }
    }
}

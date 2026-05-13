using UnityEngine;

public class BowlCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject nextBowl; // Bowl2 or Bowl3 depending on prefab

    public bool hasFlour = false;
    public bool hasOliveOil = false;

    

    void OnCollisionEnter(Collision col)
    {
        string objName = col.gameObject.name;

        bool hitFlour = objName.Contains("Flour");
        bool hitOil = objName.Contains("OliveOil");

        if (!hitFlour && !hitOil) return;

        // Prevent adding same object twice
        if (hitFlour && hasFlour) return;
        if (hitOil && hasOliveOil) return;

      

        // Destroy colided object
        Destroy(col.gameObject);

        GameObject newBowl = Instantiate(nextBowl, transform.position, transform.rotation);

        BowlCollision bc = newBowl.GetComponent<BowlCollision>();
        if (bc != null)
        {
            bc.hasFlour = hasFlour || hitFlour;
            bc.hasOliveOil = hasOliveOil || hitOil;
        }

        Destroy(gameObject);
    }
}

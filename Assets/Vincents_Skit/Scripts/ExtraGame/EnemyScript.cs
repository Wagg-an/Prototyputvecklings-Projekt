using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour 
{
    public ParticleSystem particle;
    public int Life = 1;
    public int value = 100;

    public GameObject bullet;
    string bulletTag;

    void Start()
    {
        bulletTag = bullet.tag;
    }

    
    void Update()
    {
        if(GamemOdeSpaceShit.instance.life <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void shot()
    {
        Life -= 1;
        //particle.Play();
        if(Life <= 0)
        {
            if(GamemOdeSpaceShit.instance != null)
            {

                GamemOdeSpaceShit.instance.addScore(value);
            }
            Destroy(gameObject);
        }

        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == bulletTag)
        {
            shot();
            Destroy(col.gameObject);
        }
        else
        {
            GamemOdeSpaceShit.instance.hurting();
            Destroy(gameObject);
        }

        
    }


}

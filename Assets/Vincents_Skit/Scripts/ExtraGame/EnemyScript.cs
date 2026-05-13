using UnityEngine;
using TMPro;

public class EnemyScript : ShotBaseClass
{

    public ParticleSystem particle;
    public int Life = 1;
    public int value = 100;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    override public void shot()
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


}

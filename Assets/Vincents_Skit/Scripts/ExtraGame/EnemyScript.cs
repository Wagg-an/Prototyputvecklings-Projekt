using UnityEngine;
using TMPro;

public class EnemyScript : ShotBaseClass
{

    public ParticleSystem particle;
    public int Life = 1;
    public int value = 100;
    public TMP_Text scoreDisp;
    
    int score;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    override public void shot()
    {
        Life -= 1;
        particle.Play();
        if(Life <= 0)
        {
            int.TryParse(scoreDisp.text, out score);
            score += value;
            scoreDisp.text += score;
            Destroy(gameObject);
        }

        
    }

}

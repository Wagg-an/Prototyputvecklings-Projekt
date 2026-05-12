using UnityEngine;

public class GamemOdeSpaceShit : MonoBehaviour
{
    public GameObject hud;
    public Camera thisCam;


    void Start()
    {
        
    }

    void Update()
    {
        if(thisCam.targetDisplay == 0)
        {
            startGame();
        }
    }

    void startGame()
    {

    }

    void loose()
    {

    }

    

}

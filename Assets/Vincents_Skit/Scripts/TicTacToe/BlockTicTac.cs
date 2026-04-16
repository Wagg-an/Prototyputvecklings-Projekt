using UnityEngine;

public class BlockTicTac : MonoBehaviour
{
    public Camera cameraGM;
    TicTacGM gameMode;
    
    public bool win;

    private void Start()
    {
        gameMode = cameraGM.GetComponent<TicTacGM>();
        GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(gameMode.playing)
        {
            GetComponent<Renderer>().enabled = true;
            if(Input.GetMouseButtonDown(0))
            {
                gameMode.endGM(win);
                if(!win)
                {
                    Invoke("exit", 2f);
                }
               
            }
            
        }
        
    }

    void OnMouseExit()
    {

        if (gameMode.playing)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
    void exit()
    {
        GetComponent<Renderer>().enabled = false;
    }
}

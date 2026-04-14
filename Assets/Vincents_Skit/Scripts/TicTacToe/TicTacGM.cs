using UnityEngine;

public class TicTacGM : MonoBehaviour
{
    bool once = false;
    public bool hasWon = false;

    public Camera selfCamera;

    public GameObject circleBlock;
    public GameObject player;
    public GameObject firstCanvas;
    public GameObject GMCanvas;

    public bool playing = false;

    public GameObject gate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selfCamera.targetDisplay == 0)
        {
            if(!once)
            {
                once = true;
                if(hasWon)
                {
                    startGame();
                }
                else
                {
                    startGame();
                    playing = true;
                }
                
            }
        }
        

    }


    void startGame()
    {
        player.SetActive(false);
        firstCanvas.SetActive(false);
        GMCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

    }

    public void endGM(bool win)
    {
        playing = false;
        if(win)
        {
            Debug.Log("Victory");
            hasWon = true;
            circleBlock.SetActive(true);
            Invoke("backToPlayer", 2f);
            gate.GetComponent<GateOpenScript>().Interact();
        }
        else
        {
            Invoke("backToPlayer", 2f);
        }
    }

    public void backToPlayer()
    {
        selfCamera.targetDisplay = 1;
        Cursor.lockState = CursorLockMode.Locked;
        player.SetActive(true);
        firstCanvas.SetActive(true);
        GMCanvas.SetActive(false);

        once = false;
    }
}

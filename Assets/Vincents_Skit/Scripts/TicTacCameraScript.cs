using UnityEngine;

public class TicTacCameraScript : MonoBehaviour
{
    bool isActive = false;
    public Camera selfCamera;

    public GameObject player;
    public GameObject canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selfCamera.targetDisplay == 0)
        {
            isActive = true;
        }

        if (isActive)
        {
            startGame();    
        }

    }

    void startGame()
    {
        player.SetActive(false);
        canvas.SetActive(false);

        Cursor.lockState = CursorLockMode.None;

    }
}

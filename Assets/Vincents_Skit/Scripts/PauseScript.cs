using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject panel;
    
    void Start()
    {
        panel.SetActive(false);
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isGamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        Cursor.lockState = CursorLockMode.None;
        panel.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
  
    public void mainMenu()
    {
        
    }

}

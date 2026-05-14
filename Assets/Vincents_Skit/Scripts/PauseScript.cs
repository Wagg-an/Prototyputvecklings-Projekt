using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject panel;
    
    void Start()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        
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
        Cursor.visible = true;
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
        SceneManager.LoadScene("MainMenu");
    }

}

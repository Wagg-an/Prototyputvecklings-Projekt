using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene("Sprint3");
    }
    public void quit()
    {
        Application.Quit();
    }
}

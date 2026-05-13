using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject player;
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == player.name)
        {
            Time.timeScale = 0f;
            //SceneManager.LoadScene("Win");
            winPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

}

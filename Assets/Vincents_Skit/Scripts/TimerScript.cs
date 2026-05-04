using UnityEngine;
using TMPro;


public class TimerScript : MonoBehaviour
{
    public TMP_Text timer;
    public GameObject LoosePanel;
    string time;

    float temp = 0;

    float min;
    float sec;
    
    bool endTime = false;

    void Start()
    {
        min = 10f;
        sec = 00f;

        time = min.ToString() + "." + sec.ToString();
        timer.text = time;

        LoosePanel.SetActive(false);
    }


    void Update()
    {
        if(!endTime)
        {
            timeChange();

            time = min.ToString() + "." + sec.ToString();
            timer.text = time;
            

        }
        
        if(min <= 0 && sec <= 0)
        {
            endTime = true;
            GameOver();
        }
    }

    void timeChange()
    {
        temp = temp + (1f * Time.deltaTime);

        Debug.Log(Mathf.Floor(temp));
        if(Mathf.Floor(temp) >= 1)
        {
            sec = 60 - ((Mathf.Floor(temp)) % 60);

            min = 9 - Mathf.Floor(((Mathf.Floor(temp)) / 60));
        }

        if(sec == 60)
        {
            sec = 0;
            min += 1;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        LoosePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }


}

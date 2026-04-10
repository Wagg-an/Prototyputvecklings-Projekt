using UnityEngine;

public class BlockTicTac : MonoBehaviour
{
    bool playing = true;
    
    private void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void OnMouseOver()
    {
        if(playing)
        {
            GetComponent<Renderer>().enabled = true;
        }
        
    }

    void OnMouseExit()
    {

        if (playing)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}

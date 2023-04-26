using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mute : MonoBehaviour
{
    
    private Text me;
    private Color32 white, normal, clicked;
    private Vector3 origScale;
    private bool canClick = false;
    private bool isMuted = false;
    private Text mytxt;


    void Start()
    {
        me = this.GetComponent<Text>();
        normal = me.color;
        clicked = new Color32(118,118,118,255);
        white = new Color32(255,255,255,255);
        origScale = transform.localScale;
        mytxt = this.GetComponent<Text>();
        isMuted = false;
    }
    public void OnMouseEnter()
    {
        me.color = white;
        transform.localScale = origScale + (Vector3.one/10);
    }  

    public void OnMouseExit()
    {
        me.color = normal;
        transform.localScale = origScale;
        canClick = false;
    } 

    public void OnMouseDown()
    {
        me.color = clicked;
        transform.localScale = origScale - (Vector3.one/10);
        canClick = true;
    }

    public void OnMouseUp()
    {
        me.color = normal;
        transform.localScale = origScale;

        if(canClick)
        {
            ToggleMute();
        }
        canClick = false;
    }

    void ToggleMute()
    {
        if(isMuted)
        {
            AudioListener.pause = false;
            mytxt.text = "MUTE";
        }
        else
        {
            AudioListener.pause = true;
            mytxt.text = "UNMUTE";
        }
        isMuted = !isMuted;
    }
}

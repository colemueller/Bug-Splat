using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    public Transform titleGroup;
    public Transform ingameGroup;
    public Transform endGroup;
    private Text me;
    private Color32 white, normal, clicked;
    private Vector3 origScale;
    private bool canClick = false;

    public static UnityEvent startClicked;
    public static UnityEvent endGame;
    private float startTime;
    private bool doMove = false;
    private bool doEndMove = false;
    private AudioSource clickSfx;
    public AudioSource music;

    void Start()
    {
        me = this.GetComponent<Text>();
        normal = me.color;
        clicked = new Color32(118,118,118,255);
        white = new Color32(255,255,255,255);
        origScale = transform.localScale;
        startClicked = new UnityEvent();
        endGame = new UnityEvent();
        endGame.AddListener(EndGame);
        clickSfx = this.GetComponent<AudioSource>();
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
        //transform.localScale = origScale;

        if(canClick)
        {
            doMove = true;
            startClicked.Invoke();
            startTime = Time.time;
            clickSfx.Play();
            music.Play();
        }
        canClick = false;
    }

    public void Update()
    {
        if(doMove)
        {

            float t = (Time.time - startTime) / 0.7f;
            if(titleGroup.localPosition.x > -1600)
            {
                titleGroup.localPosition = new Vector3(Mathf.SmoothStep(0f, -1650f, t),0,0);
            }
            if(ingameGroup.localPosition.x > 5)
            {
                ingameGroup.localPosition = new Vector3(Mathf.SmoothStep(1923f, 0f, t),0,0);
            }
            else
            {
                doMove=false;
            }
        }

        if(doEndMove)
        {
            float t = (Time.time - startTime) / 0.7f;
            if(endGroup.localPosition.x > 5)
            {
                endGroup.localPosition = new Vector3(Mathf.SmoothStep(1923f, 0f, t),0,0);
            }
            else
            {
                doEndMove=false;
            }
        }
    }

    public void EndGame()
    {
        print("GAMEOVER");
        doEndMove = true;
        startTime = Time.time;
    }
}

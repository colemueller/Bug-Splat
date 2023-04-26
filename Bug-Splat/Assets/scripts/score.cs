using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class score : MonoBehaviour
{
    public static int _score = 0;
    public static UnityEvent changeScore;
    public static UnityEvent rampUp;

    private Text scoreTxt;

    void Start()
    {
        scoreTxt = this.GetComponent<Text>();
        changeScore = new UnityEvent();
        rampUp = new UnityEvent();
        changeScore.AddListener(UpdateScore);
    }

    void Update()
    {
        scoreTxt.text = "SCORE: " + _score.ToString();
    }

    public void UpdateScore()
    {
        score._score += 100;

        if(_score == 1500 || _score == 3000 || _score == 6000 || _score == 12000 || _score == 24000)
        {
            rampUp.Invoke();
            print("GET HARDER!");
        }
        
    }
    
}

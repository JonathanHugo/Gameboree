using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    private bool loop;
    public TMP_Text tmTimeLeft;
    public TMP_Text tmShot;
    public TMP_Text tmTime;
    private bool fired;
    private int time;
    private int MAX_TIME = 130;
    private int num = 0;
    private int bestTime;

    // Start is called before the first frame update
    void Start()
    {
        time = MAX_TIME;
        loop = true;
        
        
    }


    private void UpdateLabels()
    {
        tmTimeLeft.text = "Time Left: " + time;
    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabels();

        //begins timer when phone is 90 degrees downwards
        if (num == 0)
        if (Input.acceleration.y > 0.9) {
            num++;
            StartCoroutine("timer");
        }

        if (Input.acceleration.y <= -0.03)
        {
            tmShot.text = "SHOT FIRED";
            bestTime = time;
            tmTime.text = "HighScore:" + bestTime;
            loop = false;
        }   

        Debug.Log(Input.acceleration.y);
        
    }

    IEnumerator timer()
    {
        while (loop)
        {
            yield return new WaitForSeconds(1);
            time--;

            if (time <= 0)
                break;
        }


    }

}

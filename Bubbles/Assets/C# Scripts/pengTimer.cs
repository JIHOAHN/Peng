using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pengTimer : MonoBehaviour {

    public Text timerText;
    private float startTime;

	void Start ()
    {
        startTime = Time.time;
	}
	
	void Update ()
    {
        float t = Time.time - startTime;
        string minute = ((int)t / 60).ToString();
        string second = (t % 60).ToString("f2");

        timerText.text = minute + " : " + second;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliminationText : MonoBehaviour {

	Text text;
	public static int eliminationAmount;

	void Start ()
	{
		text = GetComponent<Text>();
	}
		
	void Update ()
	{
		text.text = eliminationAmount.ToString();
	}
}

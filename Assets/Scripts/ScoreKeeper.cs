using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int points = 0;





	private Text myText;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
	}
	
	
	public void Score(int scoreValue) {
		points += scoreValue;
		myText.text = points.ToString();
	}
	
	public void Reset(){
		points = 0;
		myText.text = points.ToString();
	}
	
}

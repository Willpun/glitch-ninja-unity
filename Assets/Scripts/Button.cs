using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Defender defenderPrefab;
	public static Defender selectedDefender;
	
	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
	
}

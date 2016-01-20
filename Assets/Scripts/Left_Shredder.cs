using UnityEngine;
using System.Collections;

public class Left_Shredder : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D collider){
		
		if (collider.gameObject.GetComponent<Attacker>()) {
			Destroy (collider.gameObject);
		}
	}
}
using UnityEngine;
using System.Collections;

public class Right_Shredder : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider){

		if (collider.gameObject.GetComponent<Projectile>()) {
			Destroy (collider.gameObject);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	private float maxHealth;
	
	public void SetMaxHealth (float max) {
		maxHealth = max;
	}
	
	public void UpdateDisplay(float currentHealth) {
		float fillAmount = currentHealth/ maxHealth;
		Image barImage = GetComponent<Image>();
		Color lerpedColor = Color.Lerp (Color.red, Color.yellow, fillAmount);
		
		barImage.fillAmount = fillAmount;
		if (fillAmount >= 1) {
			barImage.color = Color.green;
		} else { barImage.color = lerpedColor; }
		
	}
}

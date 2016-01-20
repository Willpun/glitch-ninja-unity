using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public Projectile projectile;
	public GameObject gun;
	
	private GameObject projectileParent;
	private Spawner[] spawnerArray;
	private Spawner spawnerInMyLane;
	private Defender myDefender;
	
	void Start () {
		spawnerArray = GameObject.FindObjectsOfType<Spawner>();
	
		projectileParent = GameObject.Find("Projectiles");
		
		if (!projectileParent)
			projectileParent = new GameObject("Projectiles");
			
		myDefender = GetComponent<Defender>();
	}
	
	void Update () {
	
		if (IsAttackerAhead()) {
		
			print ("Attack is ahead");
		
			if (!myDefender.isMoving) { myDefender.SetAttack(true); }
		} else {
			myDefender.SetAttack(false);
		}
	}
	
	private bool IsAttackerAhead(){
		foreach (Spawner thisSpawner in spawnerArray) {
			if (thisSpawner.transform.position.y == transform.position.y) {
				spawnerInMyLane = thisSpawner;
			}
		}
	
		if (spawnerInMyLane.transform.childCount <= 0) {
			return false;
		}
		Attacker[] attackerArray = spawnerInMyLane.GetComponentsInChildren<Attacker>();
		foreach (Attacker thisAttacker in attackerArray) {
			if (thisAttacker.transform.position.x >= transform.position.x &&
				thisAttacker.transform.position.x < 10f) {
				return true;
			}
		}
		
		return false;
	}
	
	private void Fire (){

			Projectile newProjectile = Instantiate (projectile) as Projectile;
			newProjectile.transform.parent = projectileParent.transform;
			newProjectile.transform.position = gun.transform.position;

	}
}

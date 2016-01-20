using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_UNLOCKED_KEY = "level_unlocked_";
	
	public static void DeleteAll () {
		PlayerPrefs.DeleteAll();
	}
		
	public static void SetMasterVolume(float volume){
		if(volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master Volume: out of range");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void SetDifficulty(float diff){
		if(diff >= 1f && diff <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
		} else {
			Debug.LogError("Difficulty: out of range");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
	public static void SetLevelUnlocked(int level){
		if(level < Application.levelCount - 1) { 
			PlayerPrefs.SetInt(LEVEL_UNLOCKED_KEY + level.ToString(), 1); // use 1 for true
		} else {
			Debug.LogError("Trying to unlock level not in build order");
		}
	}
	
	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCKED_KEY + level.ToString());
		bool isUnlocked = (levelValue == 1);
	
		if(level < Application.levelCount - 1) {
			return isUnlocked;
		} else {
			Debug.LogError("Trying to query level not in build order");
			return false;
		}
	}
}

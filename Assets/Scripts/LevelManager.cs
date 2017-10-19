using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name){
		Debug.Log ("Requested to load this level: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("Request to quit the game");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
	
}

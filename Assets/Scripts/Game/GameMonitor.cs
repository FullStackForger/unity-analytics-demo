using UnityEngine;
using System.Collections;

public class GameMonitor : Singleton<GameMonitor> {

	private int currentLevel = 0;

	private bool canCompleteOrFail { get { return currentLevel != 0; } }			
	private bool canStartNewLevel { get { return currentLevel == 0; } }		

	public void StartLevel(int levelNumber) {
		if (!canStartNewLevel) { 
			Debug.LogError("You are playing level: " + currentLevel.ToString() + ". Finish it before starting new level.");
			return;
		}
		currentLevel = 0;
	}

	public void CompleteLevel() {
		if (!canCompleteOrFail) { 
			Debug.LogError("You can't complete the level before starting it");
			return;
		}

	}

	public void FailLevel() {
		if (!canCompleteOrFail) { 
			Debug.LogError("You can't fail the level before starting it");
			return;
		}
	}

}
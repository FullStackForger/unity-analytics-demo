using UnityEngine;
using System.Collections;

public class GameMonitor : Singleton<GameMonitor> {



	public const string COMPLETED_LEVELS_PREF = "completedLevels";
	public const string LAST_PLAYED_LEVEL_PREF = "completedLevels";

	private int currentLevel = 0;
	
	private bool canCompleteOrFail { get { return currentLevel != 0; } }			
	private bool canStartNewLevel { get { return currentLevel == 0; } }		

	public void StartLevel(int levelNumber) {
		if (!canStartNewLevel) { 
			Debug.LogError("You are playing level: " + currentLevel.ToString() + ". Finish it before starting new level.");
			return;
		}
		currentLevel = levelNumber;
	}

	public void CompleteLevel() {
		if (!canCompleteOrFail) { 
			Debug.LogError("You can't complete the level before starting it");
			return;
		}

		SaveLastPlayedLevel();
		SaveCompletedLevel();
	}

	public void FailLevel() {
		if (!canCompleteOrFail) { 
			Debug.LogError("You can't fail the level before starting it");
			return;
		}
	}

	public int GetCurrentLevel() { 
		return currentLevel; 
	}

	public int GetCompletedLevels() { 
		return PlayerPrefs.GetInt(COMPLETED_LEVELS_PREF); 
	}

	public int GetLastPlayedLevel() { 
		return PlayerPrefs.GetInt(LAST_PLAYED_LEVEL_PREF); 
	}

	private void SaveCompletedLevel() {
		if (currentLevel < PlayerPrefs.GetInt(COMPLETED_LEVELS_PREF)) {
			PlayerPrefs.SetInt(COMPLETED_LEVELS_PREF, currentLevel);
			PlayerPrefs.Save();
		}		
	}

	private void SaveLastPlayedLevel() {
		PlayerPrefs.SetInt(LAST_PLAYED_LEVEL_PREF, currentLevel);
		PlayerPrefs.Save();
	}

}
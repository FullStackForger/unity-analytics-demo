using UnityEngine;
using System.Collections;

public class GameMonitor : Singleton<GameMonitor> {

	public delegate void OnLevelStartedHandler(int levelNumber);
	public delegate void OnLevelCompleteHandler(int levelNumber);
	public delegate void OnLevelFailedHandler(int levelNumber);
	public delegate void OnDataResetHandler();

	public event OnLevelStartedHandler OnLevelStarted;
	public event OnLevelCompleteHandler OnLevelCompleted;
	public event OnLevelFailedHandler OnLevelFailed;
	public event OnDataResetHandler OnDataReset;

	public const string COMPLETED_LEVELS_PREF = "completedLevels";
	public const string LAST_PLAYED_LEVEL_PREF = "lastPlayedLevel";
	public const string CREDITS = "credits";
	
	public int currentLevel { get; private set; }
	public int completedLevels { get { return PlayerPrefs.GetInt(COMPLETED_LEVELS_PREF); } }	
	public int lastPlayedLevel { get { return  PlayerPrefs.GetInt(LAST_PLAYED_LEVEL_PREF); } }
	private bool canCompleteOrFail { get { return currentLevel != 0; } }			
	private bool canStartNewLevel { get { return currentLevel == 0; } }		

	public void StartLevel(int levelNumber) {
		if (!canStartNewLevel) { 
			Debug.LogError("You are playing level: " + currentLevel.ToString() + ". Finish it before starting new level.");
			return;
		}
		currentLevel = levelNumber;

		if (OnLevelStarted != null) OnLevelStarted(currentLevel);
	}

	public void CompleteLevel() {
		if (!canCompleteOrFail) { 
			Debug.LogError("You can't complete the level before starting it");
			return;
		}	

		SaveLastPlayedLevel();
		SaveCompletedLevel();
		currentLevel = 0;

		if (OnLevelCompleted != null) OnLevelCompleted(lastPlayedLevel);
	}

	public void FailLevel() {
		if (!canCompleteOrFail) { 
			Debug.LogError("You can't fail the level before starting it");
			return;
		}

		SaveLastPlayedLevel();
		currentLevel = 0;

		if (OnLevelFailed != null) OnLevelFailed(lastPlayedLevel);
	}

	public void ResetStoredData() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();

		if (OnDataReset != null) OnDataReset();
	}

	private void SaveCompletedLevel() {
		if (currentLevel > PlayerPrefs.GetInt(COMPLETED_LEVELS_PREF)) {
			PlayerPrefs.SetInt(COMPLETED_LEVELS_PREF, currentLevel);
			PlayerPrefs.Save();
		}		
	}

	private void SaveLastPlayedLevel() {
		PlayerPrefs.SetInt(LAST_PLAYED_LEVEL_PREF, currentLevel);
		PlayerPrefs.Save();
	}

}
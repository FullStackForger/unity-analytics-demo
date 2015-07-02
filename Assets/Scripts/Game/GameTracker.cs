using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class GameTracker : MonoBehaviour {

	GameMonitor Monitor { get { return GameMonitor.Instance; } }

	void Awake () {
		Analytics.CustomEvent("gameStart", new Dictionary<string, object> {
			{ "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
		});
	}

	void Start () {
		AssignDelegates();
	}

	void AssignDelegates() {
		Monitor.OnLevelCompleted += HandleOnLevelCompleted;
		Monitor.OnLevelFailed += HandleOnLevelFailed;
		Monitor.OnLevelStarted += HandleOnLevelStarted;
	}

	void HandleOnLevelStarted (int levelNumber) {
		Analytics.CustomEvent("levelStart", new Dictionary<string, object> {
			{ "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
		});
	}

	void HandleOnLevelFailed (int levelNumber) {
		Analytics.CustomEvent("levelFailure", new Dictionary<string, object> {
			{ "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
		});
	}

	void HandleOnLevelCompleted (int levelNumber) {
		Analytics.CustomEvent("levelComplete", new Dictionary<string, object> {
			{ "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
		});
	}
}

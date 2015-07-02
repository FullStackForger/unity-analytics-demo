using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILevelTrackerBuilder : MonoBehaviour {

	private GameMonitor Monitor { get { return GameMonitor.Instance; } }

	public Button startLevelBtn;
	public Button completeLevelBtn;
	public Button failLevelBtn;

	private int _levelNumber;
	public int levelNumber { 
		get { return _levelNumber; }
		set { _levelNumber = value; updateButtons (value); } 
	}

	// Use this for initialization
	void Start () {
		Monitor.OnLevelStarted += handleMonitorEvent;
		Monitor.OnLevelCompleted += handleMonitorEvent;
		Monitor.OnLevelFailed += handleMonitorEvent;
		Monitor.OnDataReset += handleMonitorEvent;
	}

	private void updateButtons(int value) {
		updateBtnLabels(value);
		updateBtnControllers(value);
		updateBtnStates();
	}

	private void handleMonitorEvent() { updateBtnStates(); 	}
	private void handleMonitorEvent(int value) { updateBtnStates();	}

	private void updateBtnStates() {
		startLevelBtn.interactable = Monitor.currentLevel == 0 && levelNumber <= Monitor.completedLevels + 1;
		completeLevelBtn.interactable = this.levelNumber == Monitor.currentLevel;
		failLevelBtn.interactable = this.levelNumber == Monitor.currentLevel;
	}

	private void updateBtnLabels(int value) {
		startLevelBtn.GetComponentInChildren<Text>().text = "Start Level " + value.ToString();
		completeLevelBtn.GetComponentInChildren<Text>().text = "Complete Level " + value.ToString();
		failLevelBtn.GetComponentInChildren<Text>().text = "Fail Level " + value.ToString();
	}

	private void updateBtnControllers(int value) {
		startLevelBtn.GetComponentInChildren<UITrackerBtnCtrl>().levelNumber = value;
		completeLevelBtn.GetComponentInChildren<UITrackerBtnCtrl>().levelNumber = value;
		failLevelBtn.GetComponentInChildren<UITrackerBtnCtrl>().levelNumber = value;
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILevelTrackerBuilder : MonoBehaviour {

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
	
	}

	private void updateButtons(int value) {
		updateBtnLabels(value);
		updateBtnControllers(value);
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

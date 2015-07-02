using UnityEngine;
using System.Collections;

public class UIGameTrackerBuilder : MonoBehaviour {

	public int numOfLevels = 10;
	public UILevelTrackerBuilder levelTracker;

	void Start () {
		DestroyChildren();
		GenerateLevelTrackers();
	}

	void DestroyChildren() {
		foreach(Transform t in transform) {
			Destroy(t.gameObject);
		}
	}

	void GenerateLevelTrackers() {
		UILevelTrackerBuilder levelTrackerBuilder;
		int levelNumber = 0;
		while (levelNumber < numOfLevels) {
			levelTrackerBuilder = Instantiate<UILevelTrackerBuilder>(levelTracker);
			levelTrackerBuilder.levelNumber = ++levelNumber;
			levelTrackerBuilder.transform.parent = transform;
		}
	}
}
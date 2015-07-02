using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


[RequireComponent(typeof(Button))]
public class UITrackerBtnCtrl : MonoBehaviour, IPointerClickHandler {
	
	public enum TrackingType { None, StartLevel, CompleteLevel, FailLevel }
	private GameMonitor Monitor { get { return GameMonitor.Instance; } }
	private Button button;

	public int levelNumber = 0;
	public TrackingType trackingType = TrackingType.None;

	void Start () {
		button = GetComponent<Button>();
	}

	public void OnPointerClick (PointerEventData eventData) {
		if (!button.IsInteractable()) return;

		switch(trackingType) {
		case TrackingType.StartLevel:
			Monitor.StartLevel(levelNumber);
			break;

		case TrackingType.CompleteLevel:
			Monitor.CompleteLevel();
			break;

		case TrackingType.FailLevel:
			Monitor.FailLevel();
			break;

		case TrackingType.None:
			Debug.LogError("Tracking Type is not selected", this);
			break;
		}
	}
}
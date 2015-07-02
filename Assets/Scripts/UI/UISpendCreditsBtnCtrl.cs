using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UISpendCreditsBtnCtrl : MonoBehaviour, IPointerClickHandler {

	public int creditsToSpend = 10;
	
	void Start () {
		GetComponentInChildren<Text>().text = "- " + creditsToSpend.ToString() + " credits";
	}

	public void OnPointerClick(PointerEventData eventData) {
		int credits = PlayerPrefs.GetInt(GameMonitor.CREDITS) - creditsToSpend;
		if (credits < 0) {
			Debug.LogError("Not enough credits.");
			return;
		}
		PlayerPrefs.SetInt(GameMonitor.CREDITS, credits);
		PlayerPrefs.Save();
	}
}
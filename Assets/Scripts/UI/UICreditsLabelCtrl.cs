using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class UICreditsLabelCtrl : MonoBehaviour {

	Text text;

	void Start () {
		text = GetComponentInChildren<Text>();
	}

	void Update () {
		text.text = "Credits: " + PlayerPrefs.GetInt(GameMonitor.CREDITS).ToString();
	}
}

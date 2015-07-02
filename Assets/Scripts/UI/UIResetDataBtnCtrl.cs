using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class UIResetDataBtnCtrl : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData) {
		GameMonitor.Instance.ResetStoredData();
	}
}

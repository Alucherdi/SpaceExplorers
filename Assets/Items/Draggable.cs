using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector3 positionReturn;
	public Sprite OriginalIcon; // Itself
	public Sprite sprite;
	public int slot;

	public void OnBeginDrag(PointerEventData eventData){
		positionReturn = transform.position;
		sprite = OriginalIcon;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		slot = transform.parent.parent.GetComponent<InventorySlot> ().slotNumber;
	}

	public void OnDrag(PointerEventData eventData){
		//Debug.Log ("Draging");
		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		transform.position = positionReturn;
		//OriginalIcon.sprite = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

}

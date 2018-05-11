using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : UnityEngine.MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    UnityEngine.Transform parentToReturnTo = null;

    public enum Slot { ACTION, POWER, INVENTORY};
    public Slot typeOfCard = Slot.ACTION;

    public Transform ParentToReturnTo
    {
        get
        {
            return parentToReturnTo;
        }

        set
        {
            parentToReturnTo = value;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {

        ParentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<UnityEngine.CanvasGroup>().blocksRaycasts = false;
	}
	
	public void OnDrag(PointerEventData eventData) {

        this.transform.position = eventData.position;
	}

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(ParentToReturnTo);
        GetComponent<UnityEngine.CanvasGroup>().blocksRaycasts = true;
    }
}

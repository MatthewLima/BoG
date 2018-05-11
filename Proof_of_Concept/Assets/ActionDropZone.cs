using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ActionDropZone : UnityEngine.MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Draggable.Slot typeOfCard = Draggable.Slot.INVENTORY;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (typeOfCard == d.typeOfCard || typeOfCard == Draggable.Slot.INVENTORY)
            {
                d.ParentToReturnTo = this.transform;
            }

        }
    }

}

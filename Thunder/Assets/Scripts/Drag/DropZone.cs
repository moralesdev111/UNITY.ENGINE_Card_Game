using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
     [SerializeField] Hand hand;
     [SerializeField] Transform battlefieldParent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) return;

        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        if(drag !=null)
        {
            drag.placeHolderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) return;

        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        if(drag !=null && drag.placeHolderParent == this.transform)
        {
            drag.placeHolderParent = drag.defaultParent;
        }
    }

    public void OnDrop(PointerEventData eventData)
{
    Drag drag = eventData.pointerDrag.GetComponent<Drag>();
    if (drag != null)
    {
        drag.defaultParent = this.transform;

        if (hand != null)
        {
            if (drag.placeHolderParent != this.transform)
            {
                // Card left the hand and didn't return
                hand.Container.Remove(drag.GetComponent<CardUI>().card);
            }
            else if (this.gameObject.CompareTag("Battlefield"))
            {
                // Card moved from the battlefield to the hand
                hand.Container.Remove(drag.GetComponent<CardUI>().card);
            }
             else if(this.gameObject.CompareTag("Hand"))
            {
                if(hand.CurrentSize < hand.ContainerSizeLimit)
                {
                    hand.Container.Add(drag.GetComponent<CardUI>().card);
                }
                else
                {
                    drag.defaultParent = battlefieldParent;
                    return;
                }
            }
        }
    }
}
}



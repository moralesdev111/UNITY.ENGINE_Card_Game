using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
     [SerializeField] Hand hand;
     [SerializeField] Transform battlefieldParent;
     [SerializeField] ManaManager manaManager;
     

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) return;

        SetPlaceholderParent(eventData.pointerDrag);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) return;

         ResetPlaceholderParent(eventData.pointerDrag);
    }

     
    public void OnDrop(PointerEventData eventData)
{
    Drag drag = eventData.pointerDrag.GetComponent<Drag>();
    if (drag != null && manaManager.GreenLight(eventData.pointerDrag.GetComponent<CardInstance>().card))
    {
        drag.defaultParent = this.transform;

        if (hand != null)
        {
            if (drag.placeHolderParent != this.transform)
            {
                // Card left the hand and didn't return
                hand.Container.Remove(drag.GetComponent<CardInstance>().card);
            }
            else if (this.gameObject.CompareTag("Battlefield"))
            {
                eventData.pointerDrag.GetComponent<CardInstance>().currentCardState = CardInstance.CardState.battlefield;
                hand.Container.Remove(drag.GetComponent<CardInstance>().card);
                 manaManager.ManaDecrease(eventData.pointerDrag.GetComponent<CardInstance>().card.manaCost);
            }
             else if(this.gameObject.CompareTag("Hand"))
            {
                if(hand.CurrentSize < hand.ContainerSizeLimit)
                {
                    eventData.pointerDrag.GetComponent<CardInstance>().currentCardState = CardInstance.CardState.hand;
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

private void SetPlaceholderParent(GameObject pointerDrag)
    {
        Drag drag = pointerDrag.GetComponent<Drag>();
        if (drag != null)
        {
            drag.placeHolderParent = transform;
        }
    }

    private void ResetPlaceholderParent(GameObject pointerDrag)
    {
        Drag drag = pointerDrag.GetComponent<Drag>();
        if (drag != null && drag.placeHolderParent == transform)
        {
            drag.placeHolderParent = drag.defaultParent;
        }
    }
}



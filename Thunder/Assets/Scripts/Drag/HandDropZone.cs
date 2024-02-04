using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Hand hand;
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
       Drag drag = eventData.pointerDrag.GetComponent<Drag>();
       if(drag != null)
       {
        drag.parentToReturnTo = this.transform;
        hand.Container.Add(drag.GetComponent<CardUI>().card);
       }
    }
}

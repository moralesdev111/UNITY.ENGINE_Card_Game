using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] CreatePlaceHolder createPlaceHolder;
    [SerializeField] SetSiblingIndex setSiblingIndex;
    public Transform defaultParent = null;
    public Transform placeHolderParent = null;
   

    public void OnBeginDrag(PointerEventData eventData)
    {
        createPlaceHolder.CreatePlaceHolderObject();

        createPlaceHolder.placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        defaultParent = this.transform.parent;
        placeHolderParent = defaultParent;
        this.transform.SetParent(this.transform.root);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if (createPlaceHolder.placeHolder.transform.parent != placeHolderParent)
            createPlaceHolder.placeHolder.transform.SetParent(placeHolderParent);

        setSiblingIndex.SetSiblingIndexOnRuntime();
    }

    

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(defaultParent);
        this.transform.SetSiblingIndex(createPlaceHolder.placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(createPlaceHolder.placeHolder);
    }
}

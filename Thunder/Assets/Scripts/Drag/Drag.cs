using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform defaultParent = null;
    public Transform placeHolderParent = null;
    GameObject placeHolder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = 125;
        le.preferredHeight = 200;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        defaultParent = this.transform.parent;
        placeHolderParent = defaultParent;
        this.transform.SetParent(this.transform.root);
        
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if(placeHolder.transform.parent != placeHolderParent)
            placeHolder.transform.SetParent(placeHolderParent);

        int newSiblingIndex = placeHolderParent.childCount;

        for(int i = 0; i < placeHolderParent.childCount; i++)
        {
            if(this.transform.position.x < placeHolderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if(placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(defaultParent);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeHolder);
    }
}

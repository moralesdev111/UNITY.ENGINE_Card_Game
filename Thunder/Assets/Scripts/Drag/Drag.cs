using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] PlaceHolder placeHolder;
    [SerializeField] SetSiblingIndex setSiblingIndex;
    public Transform defaultParent = null;
    public Transform placeHolderParent = null;
    private bool canDrag = false;
    private ManaManager manaManager;
    private CardUI cardDetails;


    public void OnBeginDrag(PointerEventData eventData)
    {
        GetCardDetails();
        //check if instantiated card currentstate is battlefield
        if (manaManager.GreenLight(cardDetails.cardInstance))
        {
            canDrag = true;
            placeHolder.CreatePlaceHolderObject();
            placeHolder.ManagePlaceHolderObjectParenting();
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            canDrag = false;
            return;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag)
        {
            this.transform.position = eventData.position;

            if (placeHolder.placeHolder.transform.parent != placeHolderParent)
            {
                placeHolder.placeHolder.transform.SetParent(placeHolderParent);
            }
                setSiblingIndex.SetSiblingIndexOnRuntime();
        }
        else
        {
            return;
        } 
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            manaManager.ManaDecrease(cardDetails.cardInstance.manaCost);
            placeHolder.DestroyPlaceHolder();
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            return;
        } 
    }

    private void GetCardDetails()
    {
        manaManager = FindObjectOfType<ManaManager>();
        cardDetails = GetComponent<CardUI>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceHolder : MonoBehaviour
{
    [SerializeField] Drag drag;
    public GameObject placeHolder = null;

    
   public void CreatePlaceHolderObject()
    {
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = 200;
        le.preferredHeight = 300;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;
    }

    public void ManagePlaceHolderObjectParenting()
    {
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        drag.defaultParent = this.transform.parent;
        drag.placeHolderParent = drag.defaultParent;
        this.transform.SetParent(this.transform.root);
    }

     public void DestroyPlaceHolder()
    {
        this.transform.SetParent(drag.defaultParent);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        Destroy(placeHolder);
    }
}

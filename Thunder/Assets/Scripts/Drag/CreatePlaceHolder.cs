using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlaceHolder : MonoBehaviour
{
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
}

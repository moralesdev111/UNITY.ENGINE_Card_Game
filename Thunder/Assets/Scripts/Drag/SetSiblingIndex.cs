using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSiblingIndex : MonoBehaviour
{
    [SerializeField] Drag drag;
    [SerializeField] PlaceHolder createPlaceHolder;

    public void SetSiblingIndexOnRuntime()
    {
        int newSiblingIndex = drag.placeHolderParent.childCount;

        for (int i = 0; i < drag.placeHolderParent.childCount; i++)
        {
            if (this.transform.position.x < drag.placeHolderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if (createPlaceHolder.placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;            }
        }
        createPlaceHolder.placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }
}

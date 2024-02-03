using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlotContainer : MonoBehaviour
{
    public int ContainerSizeLimit { get; protected set; }
    [SerializeField] private int currentSize;
    public int CurrentSize 
    {
        get{return container.Count;}
        protected set{currentSize = value;}
    }
    protected List<Card> container;
    public List<Card> Container
    {
        get { return container; }
    }

    public abstract void RandomizeContainer();
}

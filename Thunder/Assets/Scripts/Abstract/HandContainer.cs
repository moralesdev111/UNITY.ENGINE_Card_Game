using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandContainer : MonoBehaviour
{
    [SerializeField] private int currentSize;
    public int CurrentSize 
    {
        get{return container.Count;}
        protected set{currentSize = value;}
    }
    public int ContainerSizeLimit { get; private set; } = 15;

    protected List<Card> container;
    public List<Card> Container
    {
        get { return container; }
    }

    public abstract void RandomizeContainer();
}

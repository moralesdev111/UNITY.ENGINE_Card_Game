using UnityEngine;
using UnityEngine.EventSystems;

public class FindTarget : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CardInstance target = null;
    public CardInstance attacker = null;
    public bool targetsAcquired;
    private BattleManager battleManager;
    private AudioManager audioManager;

    private void OnEnable()
    {
        targetsAcquired = false;
        battleManager = FindObjectOfType<BattleManager>();
        attacker = GetComponentInParent<CardInstance>();
        audioManager = FindObjectOfType<AudioManager>();
        battleManager.battlingCards[0]= attacker;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CardInstance card = collision.GetComponent<CardInstance>();

        // Check if the collision is with a card and not with the arrow trigger's descendants
        if (card != null && !IsGrandChild(collision.gameObject) && card.tag == "Opponent" && card.transform.parent == battleManager.battlefieldParent)
        {
            audioManager.PlaySFX("attack");
            target = card;
            battleManager.battlingCards[1]= target;
            Debug.Log("Target: " + target.name);
            Destroy(gameObject);
        }
        else if(!IsGrandChild(collision.gameObject) && collision.tag == "OpponentHero")
        {
            audioManager.PlaySFX("attack");
            OpponentHealth enemyHealth = collision.GetComponent<OpponentHealth>();
            enemyHealth.currentHealth -= attacker.card.attack;
            attacker.GetComponent<Attack>().canAttack = false;
            Destroy(gameObject);
        }
    }

    private bool IsGrandChild(GameObject obj)
    {
        // Check if the GameObject is a grandchild of the arrow trigger
        Transform currentTransform = obj.transform;
        while (currentTransform != null)
        {
            if (currentTransform.parent == transform.parent.parent)
            {
                return true;
            }
            currentTransform = currentTransform.parent;
        }
        return false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        targetsAcquired = true;
        Destroy(gameObject);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

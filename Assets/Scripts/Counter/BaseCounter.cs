using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenobjectHolder
{
    [SerializeField] private GameObject selectedCounter;
    public virtual void Interact(Player player)
    {
        Debug.LogWarning("Métodos interativos não são substituídos.");
    }
    public virtual void InteractOperate(Player player) 
    {
        
    }

    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }

}

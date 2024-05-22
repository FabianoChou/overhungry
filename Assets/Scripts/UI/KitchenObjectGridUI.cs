using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{

    [SerializeField] private KitchenObjectconUI iconTemplateUI;

    private void Start()
    {
        iconTemplateUI.Hide();
    }
    public void ShowKitchenObjectUI(KitchenObjectSO kitchenObjectSO) 
    {
        KitchenObjectconUI newIconUI = GameObject.Instantiate(iconTemplateUI, transform);
        newIconUI.Show(kitchenObjectSO.sprite);
    }
}

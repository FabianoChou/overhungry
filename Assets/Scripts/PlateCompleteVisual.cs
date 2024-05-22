using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{

    [Serializable]
    public class KitchenObjectSO_Model {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject model;
        
    }
    [SerializeField] private List<KitchenObjectSO_Model> modelMap;

    public void ShowKitchenObject(KitchenObjectSO kitchenObjectSO) 
    {
        foreach(KitchenObjectSO_Model item in modelMap) 
        {
            if(item.KitchenObjectSO == kitchenObjectSO) 
            {
                item.model.SetActive(true);return;
            }
        }
    }

}

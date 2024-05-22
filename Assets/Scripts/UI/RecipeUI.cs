using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI recipleNameText;
    [SerializeField] private Transform kitchenObjectParent;
    [SerializeField] private Image iconUITemplate;

    private void Start()
    {
        iconUITemplate.gameObject.SetActive(false);
    }
    public void UpdateUI (RecipSO recipSO)
    {
        recipleNameText.text = recipSO.recipleName;
        foreach (KitchenObjectSO kitchenObjectSO in recipSO.kitchenObjectSOList) 
        {
           Image newIcon = GameObject.Instantiate(iconUITemplate);
            newIcon.transform.SetParent(kitchenObjectParent);
            newIcon.sprite = kitchenObjectSO.sprite;
            newIcon.gameObject.SetActive(true);
        }
    }

}

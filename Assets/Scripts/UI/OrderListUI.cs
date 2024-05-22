using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{

    [SerializeField] private Transform recipeParent;
    [SerializeField] private RecipeUI recipeUITemplate;

    private void Start()
    {
        recipeUITemplate.gameObject.SetActive(false);
        OrderManager.Instance.OnRecipeSpawned += OrderManager_OnRecipeSpawned;
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
    }
    
    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e) 
    {
        UpdateUI();
    }
    private void OrderManager_OnRecipeSpawned(object sender, System.EventArgs e) 
    {
        UpdateUI();
    }
    private void UpdateUI() 
    {
        foreach (Transform child in recipeParent) 
        {
            if (child != recipeUITemplate.transform) 
            {
                Destroy(child.gameObject);
            }
        }

        List<RecipSO> recipeSOList =  OrderManager.Instance.GetOrderList();
        foreach (RecipSO recipSO in recipeSOList) 
        {
            RecipeUI recipeUI = GameObject.Instantiate(recipeUITemplate);
            recipeUI.transform.SetParent(recipeParent);
            recipeUI.gameObject.SetActive(true);
            recipeUI.UpdateUI(recipSO);
        }

    }

}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance {  get; private set; }

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeSuccessed;
    public event EventHandler OnRecipeFailed;

   [SerializeField] private RecipeListSO recipeSOList;
   [SerializeField] private int orderMaxCount = 5;
   [SerializeField] private float orderRate = 2;

   private List<RecipSO> orderRecipeSOList= new List<RecipSO>();

   private float orderTimer = 0;
   private bool isStartOrder=false;
   private int orderCount = 0;
   private int successDeliveryCount = 0;

    private void Awake() 
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlayingState())
        {
            StartSpawnOrder();
        }
    }

    private void Update()
    {
        if (isStartOrder) 
        {
            OrderUpdate();
        }
    }
    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer >= orderRate)
        {
            orderTimer = 0;
            OrderNewRecipe();
        }
    }

    private void OrderNewRecipe() 
    {
        if (orderCount >= orderMaxCount) return;
        orderCount++;
        int index = UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);
        orderRecipeSOList.Add(recipeSOList.recipeSOList[index]);
        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject) 
    {
        RecipSO correctRecipe = null;
        foreach(RecipSO recipe in orderRecipeSOList)
        {
            if (IsCorrect(recipe, plateKitchenObject)) 
            {
                correctRecipe = recipe; break;
            }
        }
        if (correctRecipe == null) 
        {
            print("Servido falhado");
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        }
        else 
        {
            orderRecipeSOList.Remove(correctRecipe);
            OnRecipeSuccessed?.Invoke(this, EventArgs.Empty);
            successDeliveryCount++;
            print("Servido com sucesso");
        }
    }

    private bool IsCorrect(RecipSO recipe, PlateKitchenObject plateKitchenObject ) 
    {
        List<KitchenObjectSO> list1 = recipe.kitchenObjectSOList;
        List<KitchenObjectSO> list2 = plateKitchenObject.GetKitchenObjectSOList();

        if (list1.Count !=list2.Count) return false;

        foreach (KitchenObjectSO kitchenObjectSO in list1) 
        {
            if (list2.Contains(kitchenObjectSO) == false) 
            {
                return false;
            }
        }
        return true;
    }

    public List<RecipSO> GetOrderList() 
    {
        return orderRecipeSOList;
    }
    public void StartSpawnOrder()
    {
        isStartOrder = true;
    }
    public int GetSuccessDeliveryCount()
    {
        return successDeliveryCount;
    }
}

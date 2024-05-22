using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Rendering.CameraUI;

public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnCut;

    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;

    [SerializeField] private ProgressBarUI progressBarUI;

    [SerializeField] private CuttingCounterVisual cuttingCounterVisual;

    private int cuttingCount = 0;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//Tenha ingredientes em mãos
            if (IsHaveKitchenObject() == false)
            {//Atualmente não há nada no balcão
                cuttingCount = 0;
                TransferKitchenObject(player, this);
            }
            else
            {//Atualmente ja tem coisa no balcão

            }
        }
        else
        {//Nao tenha
            if (IsHaveKitchenObject() == false)
            {//Atualmente não há nada no balcão

            }
            else
            {//Atualmente ja tem coisa no balcão
                TransferKitchenObject(this, player);
                progressBarUI.Hide();
            }
        }
    }
    public override void InteractOperate(Player player)
    {
            if(cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe))
            {
                Cut();

            progressBarUI.UpdateProgress( (float) cuttingCount / cuttingRecipe.cuttingCountMax);

                if(cuttingCount == cuttingRecipe.cuttingCountMax)
            {

                DestroyKitchenObject();
                CreateKitchenObject(cuttingRecipe.output.prefab);
            }

            

        }
    }

    private void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);
        cuttingCount++;
        cuttingCounterVisual.PlayCut();
    }
    public static void ClearStaticData()
    {
        OnCut = null;
    }
}

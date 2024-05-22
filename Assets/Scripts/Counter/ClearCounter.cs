using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//Tenha KitchenObject em mãos

            if(player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
            {//Tenha plate na mao
                if (IsHaveKitchenObject() == false)
                {//Atualmente não há nada no balcão
                    TransferKitchenObject(player, this);
                }
                else
                {//Atualmente ja tem coisa no balcão
                    bool isSuccess = plateKitchenObject.AddKitchenObjectSO(GetKitchenObjectSO());
                    if(isSuccess)
                    {
                        DestroyKitchenObject();
                    }

                }
            }
            else
            {//Tenha alimento na mao
             if (IsHaveKitchenObject() == false)
             {//Atualmente não há nada no balcão
                 TransferKitchenObject(player, this);
             }
             else
             {//Atualmente ja tem coisa no balcão
                if(GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plateKitchenObject))
                {
                    if(plateKitchenObject.AddKitchenObjectSO( player.GetKitchenObjectSO()))
                        {
                            player.DestroyKitchenObject();
                        }
                }
             }
            }
            //if (IsHaveKitchenObject() == false)
            //{//Atualmente não há nada no balcão
            //    TransferKitchenObject(player, this);
            //}
            //else
            //{//Atualmente ja tem coisa no balcão
            //
            //}
        }
        else
        {//Nao tenha
            if (IsHaveKitchenObject() == false)
            {//Atualmente não há nada no balcão

            }
            else
            {//Atualmente ja tem coisa no balcão
                TransferKitchenObject(this, player);
            }
        }
    }

}

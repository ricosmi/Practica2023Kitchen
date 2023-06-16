using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    


   
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //There is no KitchenObject here
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this); 

            }
            else
            {
                //Player is no carrying something
            }
        }
        else
        {
            //there is a KO here
            if(player.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                //Player is no carrying something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

        /*if (HasKitchenObject())
        {
            if (player.HasKitchenObject() == false)
                GetKitchenObject().SetKitchenObjectParent(player);
        }*/
        
        

    }
   

}

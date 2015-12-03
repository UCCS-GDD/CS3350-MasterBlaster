using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Event to handle pickups being collected
/// </summary>
/// <param name="pickupImage">sprite of the pickup Object</param>
public delegate void CollectPickupEventHandler(Sprite pickupImage);

public static class CollectPickupEvent{

    static event CollectPickupEventHandler collectPickupEventHandlers;

    public static void RegisterCollectPickupEventHandler(CollectPickupEventHandler pickupEventIsFired)
    {
        collectPickupEventHandlers += pickupEventIsFired;
    }
    
    public static void FireCollectPickupEventHandler(Sprite pickupImage)
    {
        if (collectPickupEventHandlers != null)
        {
            collectPickupEventHandlers(pickupImage);
        }
    }
    
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Shoot Pickups from UI
/// </summary>
/// <param name="pickupName">name of pickup being shot</param>
public delegate void ShootPickupEventHandler(Image pickupImage);

public static class ShootPickupEvent {

    static event ShootPickupEventHandler shootPickupHandlers;

    public static void HandleShootPickupEventHandler(ShootPickupEventHandler ShootPickup)
    {
        shootPickupHandlers += ShootPickup;
    }

    public static void FireShootPickpEventHandler(Image pickupImage)
    {
        if (shootPickupHandlers != null)
        {
            shootPickupHandlers(pickupImage);
        }
    }
    public static void DeregisterShootPickupEventHandler(ShootPickupEventHandler shootPickup)
    {
        shootPickupHandlers -= shootPickup;
    }
}

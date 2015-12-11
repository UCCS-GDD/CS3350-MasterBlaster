using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
    List<Image> pickupImages = new List<Image>();
    int inventoryCount = 0;

    // Use this for initialization
	void Start () {
        // get all the buttons on the UI canvas and the images on the buttons
        Transform[] uiSlots = transform.GetComponentsInChildren<Transform>();
        //print(uiSlots.Length);
        for (int i = 0; i < uiSlots.Length; i++)
        {
            if (uiSlots[i].tag == "InventorySlot")
            {
                pickupImages.Add(uiSlots[i].GetComponentsInChildren<Image>()[1]);
            }
        }

        //print(pickupImages.Count);

    }


    // Update is called once per frame
    void Update () {
	

	}
    // activate add the sprite to the UI icon if the pick up event is fired
    public void HandlePickupEvent(Sprite pickupIcon)
    {
        if (inventoryCount <= 4)
        {
            pickupImages[inventoryCount].enabled = true;
            pickupImages[inventoryCount].sprite = pickupIcon;
            inventoryCount++;
        }
    }
    void OnEnable()
    {
        CollectPickupEvent.RegisterCollectPickupEventHandler(HandlePickupEvent);
        
    }
    public void ShootPickup(Image pickupImage)
    {

        ShootPickupEvent.FireShootPickpEventHandler(pickupImage);
        pickupImage.enabled = false;
        inventoryCount--;
        
    }
    public void OnDisable()
    {
        CollectPickupEvent.DeRegisterCollectPickupEventHandler(HandlePickupEvent);
    }
    
}

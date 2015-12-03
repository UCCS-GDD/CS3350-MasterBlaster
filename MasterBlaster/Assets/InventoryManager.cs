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
                pickupImages.Add(uiSlots[i].GetComponentInChildren<Image>());
            }
        }

        //print(pickupImages.Count);

    }


    // Update is called once per frame
    void Update () {
	

	}
    // this isn't running for some reason
    public void HandlePickupEvent(Sprite pickupIcon)
    {
        pickupImages[inventoryCount].sprite = pickupIcon;
        pickupImages[inventoryCount].gameObject.SetActive(true);
        inventoryCount++;
    }
    void OnEnable()
    {
        CollectPickupEvent.RegisterCollectPickupEventHandler(HandlePickupEvent);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPickupScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        InteractionStart();
    }

    public void InteractionStart()
    {
        Inventory.hasKeycard = true;
        Destroy(this.gameObject);
    }
}

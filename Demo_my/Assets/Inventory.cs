using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject eqKeycardImage;
    public static bool hasKeycard { get; set; } = false;

    public void updateInventory()
    {
        eqKeycardImage.SetActive(hasKeycard);
    }

    // TMP, update is in Interaction script, but script do not work on Editor Play testing
    private void Update()
    {
        updateInventory();
    }

}

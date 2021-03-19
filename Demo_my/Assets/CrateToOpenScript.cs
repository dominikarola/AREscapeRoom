using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateToOpenScript : MonoBehaviour
{
    bool opened = false;
    public Animation animation;
    public GameObject objectToShow;
    // Start is called before the first frame update
    void Start()
    {
        objectToShow.SetActive(false);
    }

    private void OnMouseDown()
    {
        InteractionStart();
    }

    public void InteractionStart()
    {
        if (!opened && hasKeycard())
        {
            openCrate();
            objectToShow.SetActive(true);
        }
    }

    private bool hasKeycard()
    {
        return Inventory.hasKeycard;
    }

    private void openCrate()
    {
        animation.Play("Crate_Open");
        Inventory.hasKeycard = false;
        opened = true;
    }

    public void InteractionEnd()
    {
    }
}

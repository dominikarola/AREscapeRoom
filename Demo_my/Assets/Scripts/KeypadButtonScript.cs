using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButtonScript : MonoBehaviour
{
    [SerializeField]
    private SimonSayLogicScript simonSayLogic;

    [SerializeField]
    private Material selected;

    [SerializeField]
    private Material notSelected;

    [SerializeField]
    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh.material = notSelected;
    }

    private void OnMouseDown()
    {
        InteractionStart();
    }

    private void OnMouseUp()
    {
        InteractionEnd();
    }

    public void InteractionStart() {
        buttonDown();
    }

    public void InteractionEnd() {
        buttonUp();
    }


    public void displayPress(bool show) {
        if (show)
        {
            mesh.material = selected;
        }
        else {
            mesh.material = notSelected;
        }
    }

    void buttonDown() {
        displayPress(true);
    }

    void buttonUp() {
        displayPress(false);
        simonSayLogic.buttonInteracted(this);
    }
}

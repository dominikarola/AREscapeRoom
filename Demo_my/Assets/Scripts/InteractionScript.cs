using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject selector;

    [SerializeField]
    private float rayDistanceFromCamera = 10.0f;

    private Transform interactedObject = null;

    [SerializeField]
    private Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    interactedObject = hitObject.transform;
                    sendMessage(interactedObject.gameObject, "InteractionStart");
                    // code
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (interactedObject != null)
                {
                    sendMessage(interactedObject.gameObject, "InteractionEnd");
                    interactedObject = null;
                }
            }
        }
        else {
            if (interactedObject != null)
            {
                sendMessage(interactedObject.gameObject, "InteractionEnd");
                interactedObject = null;
            }
        }
    }

    private void sendMessage(GameObject gameObject, string msg)
    {
        gameObject.SendMessage(msg);
        inventory.updateInventory();
    }
}

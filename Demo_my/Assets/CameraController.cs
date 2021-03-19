using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camSpeed = 20f; // speed of camera
    public float camBorderThickness = 10f;
    public Vector2 camLimit;

    public float scrollSpeed = 10f;
    public float minY = 10f;
    public float maxY = 30f;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("a") || Input.mousePosition.y >= Screen.height - camBorderThickness)

        {
            pos.z += camSpeed * Time.deltaTime;
        }

        if (Input.GetKey("w") || Input.mousePosition.y <= camBorderThickness)

        {
            pos.z -= camSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.x >= Screen.width - camBorderThickness)

        {
            pos.x += camSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x <= camBorderThickness)

        {
            pos.x -= camSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;


        pos.x = Mathf.Clamp(pos.x, -camLimit.x, camLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -camLimit.y, camLimit.y);


        transform.position = pos;
    }
}
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 30f;
    [SerializeField] private  float panBorderThickness = 10f;
    private float scrollSpeed = 5f;
    private float minY = 10f;
    private float maxY = 80f;

    private void Update()
    {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}

using UnityEngine;

public class Player_Cam : MonoBehaviour
{
    public bool canMouseMove = true;
    private CharacterController controller;
    public float speedY = 1f;
    public float speedX = 1f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public Transform camTransform;
    public float vertClampMin = 20f;
    public float vertClampMax = 28f;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        HorizontalMove();
        verticalMove();
    }

    public void HorizontalMove()
    {
        if (canMouseMove == false) { return; }
        yaw += speedX * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, yaw, 0);
    }

    public void verticalMove()
    {
        if (canMouseMove == false) { return; }
        pitch -= speedY * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, vertClampMin, vertClampMax);
        camTransform.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
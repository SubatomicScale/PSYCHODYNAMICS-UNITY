using UnityEngine;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private float currentTilt = 0f;
    private Tweener tiltTween;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        // Incorporate the currentTilt into the final rotation
        this.transform.rotation = Quaternion.Euler(xRotation, yRotation, currentTilt);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void DoFov(float endValue)
    {
        GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    }

    public void DoTilt(float zTilt)
    {
        // Kill any existing tilt tween to prevent conflicts
        if (tiltTween != null && tiltTween.IsActive())
        {
            tiltTween.Kill();
        }
        // Use DOTween to smoothly update the currentTilt value
        tiltTween = DOTween.To(() => currentTilt, x => currentTilt = x, zTilt, 0.25f);
    }
}
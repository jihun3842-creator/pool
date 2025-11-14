using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;           // 플레이어
    public float distance = 6f;        // 캐릭터와의 거리
    public float height = 3f;          // 카메라 높이
    public float mouseSensitivity = 100f;
    public float rotationSmoothTime = 0.05f;

    private float yaw;    // 좌우 회전값
    private float pitch;  // 상하 회전값
    private Vector3 currentRotation;
    private Vector3 smoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
    }

    void LateUpdate()
    {
        if (!target) return;

        // 마우스 입력값
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -20f, 60f); // 위아래 시야 제한

        // 회전값 보간으로 부드럽게
        Vector3 targetRotation = new Vector3(pitch, yaw);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref smoothVelocity, rotationSmoothTime);

        // 회전 반영
        transform.eulerAngles = currentRotation;

        // 위치 계산 (타겟 기준 뒤쪽)
        Vector3 targetPos = target.position - transform.forward * distance + Vector3.up * height;
        transform.position = targetPos;
    }
}

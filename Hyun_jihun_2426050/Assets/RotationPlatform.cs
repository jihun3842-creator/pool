using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    [Header("회전 설정")]
    public Vector3 rotationAxis = Vector3.up; // 회전 방향 (기본: Y축)
    public float rotationSpeed = 100f;        // 초당 회전 속도
    public float pushForce = 10f; // 밀어내는 힘

    void Start()
    {
        if (Random.value > 0.5f)
            rotationSpeed = -rotationSpeed; // 50% 확률로 반대 방향 회전
    }


    void Update()
    {
        // 일정 속도로 회전
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            Vector3 pushDir = transform.right; // 회전 방향 기준
            rb.AddForce(pushDir * pushForce, ForceMode.VelocityChange);
        }
    }


}

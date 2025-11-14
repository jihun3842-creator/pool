using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    [Header("회전 설정")]
    public Vector3 rotationAxis = Vector3.forward; // 회전축 (Z축 기준)
    public float swingAngle = 30f;                 // 최대 회전 각도
    public float swingSpeed = 2f;                  // 왕복 속도
    public float phaseOffset = 0f;                 // 시간차(랜덤 타이밍)

    [Header("플레이어 밀어내기 힘")]
    public float pushForce = 12f;      // 기본 밀어내기
    public float upwardForce = 4f;     // 살짝 떠오르게

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed + phaseOffset) * swingAngle;
        transform.localRotation = startRotation * Quaternion.AngleAxis(angle, rotationAxis);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            Vector3 forceDir = (collision.transform.position - transform.position).normalized;

            rb.AddForce(forceDir * 20f, ForceMode.Impulse);
        }
    }
}

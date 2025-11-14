using UnityEngine;

public class HammerManager : MonoBehaviour
{
    [Header("관리할 망치들")]
    public HammerSwing[] hammers;

    [Header("랜덤 설정 범위")]
    public float minSpeed = 1.5f;
    public float maxSpeed = 3.5f;
    public float minAngle = 25f;
    public float maxAngle = 40f;

    void Start()
    {
        foreach (HammerSwing hammer in hammers)
        {
            hammer.swingSpeed = Random.Range(minSpeed, maxSpeed);
            hammer.swingAngle = Random.Range(minAngle, maxAngle);
            hammer.phaseOffset = Random.Range(0f, Mathf.PI * 2f); // 랜덤 시간차
        }
    }
}

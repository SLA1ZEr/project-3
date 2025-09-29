using UnityEngine;

public class Cube : MonoBehaviour
{
    public int currentValue = 0;
    private bool valueReported = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb == null) return;

        if (rb.linearVelocity.magnitude < 0.01f && currentValue > 0 && !valueReported)
        {
            valueReported = true;
            Debug.Log("✅ " + name + " выпало: " + currentValue);

            if (DiceManager.Instance != null)
            {
                DiceManager.Instance.ReportDiceStopped(currentValue, name);
            }
        }

        if (rb.linearVelocity.magnitude > 0.1f)
        {
            valueReported = false;
        }
    }

    public void ResetDice()
    {
        currentValue = 0;
        valueReported = false;
    }
}
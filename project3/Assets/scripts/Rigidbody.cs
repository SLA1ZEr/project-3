using UnityEngine;

public class RigidBody : MonoBehaviour, IControllable
{
    private Rigidbody rb;
    private Cube cubeScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cubeScript = GetComponent<Cube>();
    }

    public void Move(Vector3 direction) { }

    public void Jump()
    {
        RollDice();
    }

    private void RollDice()
    {
        if (cubeScript != null)
        {
            cubeScript.ResetDice();
        }

        Vector3 randomTorque = new Vector3(
            Random.Range(-100f, 100f),
            Random.Range(-100f, 100f),
            Random.Range(-100f, 100f)
        );

        Vector3 randomDirection = new Vector3(
            Random.Range(-3f, 3f),
            12f,
            Random.Range(-3f, 3f)
        );

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(randomDirection, ForceMode.Impulse);
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        if (DiceManager.Instance != null)
        {
            DiceManager.Instance.PrepareForThrow();
        }
    }
}
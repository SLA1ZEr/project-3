using UnityEngine;

public class Number : MonoBehaviour
{
    public int faceValue = 1;
    public Cube parentCube;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Platform" && parentCube != null)
        {
            // УБИРАЕМ противоположное значение - используем прямое!
            // Если грань "2" касается платформы → выпало 2
            parentCube.currentValue = faceValue;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Platform" && parentCube != null)
        {
            parentCube.currentValue = 0;
        }
    }
}
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager Instance;
    private int totalScore = 0;
    private int throwCount = 0;
    private int[] diceValues = new int[2];
    private int currentDiceIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    public void ReportDiceStopped(int value, string diceName)
    {
        if (currentDiceIndex < diceValues.Length)
        {
            diceValues[currentDiceIndex] = value;
            currentDiceIndex++;

            if (currentDiceIndex == diceValues.Length)
            {
                ShowResult();
            }
        }
    }

    void ShowResult()
    {
        int sum = diceValues[0] + diceValues[1];
        totalScore += sum;
        throwCount++;

        Debug.Log("═══════════════════════════════════════");
        Debug.Log("🎯 РЕЗУЛЬТАТ БРОСКА " + throwCount + ":");
        Debug.Log("🟦 Кубик 1: " + diceValues[0]);
        Debug.Log("🟨 Кубик 2: " + diceValues[1]);
        Debug.Log("💰 СУММА: " + diceValues[0] + " + " + diceValues[1] + " = " + sum);
        Debug.Log("🏆 ОБЩИЙ СЧЕТ: " + totalScore);
        Debug.Log("═══════════════════════════════════════");

        ResetForNextThrow();
    }

    void ResetForNextThrow()
    {
        diceValues = new int[2];
        currentDiceIndex = 0;
    }

    public void PrepareForThrow()
    {
        ResetForNextThrow();
    }
}
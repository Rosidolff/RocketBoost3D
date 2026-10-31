using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/PowerUp Data")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField] private string powerUpType;
    [SerializeField] private int powerUpValue;

    public string PowerUpType { get => powerUpType; }
    public int PowerUpValue { get => powerUpValue; }
}

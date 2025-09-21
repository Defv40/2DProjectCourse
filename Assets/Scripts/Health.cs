using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    
    public int CurrentHealth =>  health;
    public int MaxHealth => maxHealth;
}


using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health health;

    private void Awake()
    {
        Debug.Log(health.CurrentHealth);
        Debug.Log(health.MaxHealth);
    }
}

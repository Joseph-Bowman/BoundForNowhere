using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int currHealth;

    void Start()
    {
        currHealth = health;
    }

    public void Damage(int Damage)
    {
        currHealth -= Damage;

        if (currHealth >= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Died");
    }
}
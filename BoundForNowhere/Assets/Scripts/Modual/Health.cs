using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")] // Characters health stats
    [SerializeField] private int health = 100;
    private int currHealth;

    void Start() { currHealth = health; }

    public void Damage(int Damage)
    {
        //Handles the taking of damage and checks if the current health is less than zero 
        currHealth -= Damage;

        if (currHealth >= 0) { Death(); }
    }

    //Handles the logic upon the character dying
    void Death() { Debug.Log("Died"); }
}
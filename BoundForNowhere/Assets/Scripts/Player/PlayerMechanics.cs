using UnityEngine;

namespace composition
{
    public class PlayerMechanics : MonoBehaviour
    {
        [Header("Player Settings")]
        //Players current weapon
        public ItemBase currWeapon;
        //Players current health module
        public Health playerHealth;
    }
}
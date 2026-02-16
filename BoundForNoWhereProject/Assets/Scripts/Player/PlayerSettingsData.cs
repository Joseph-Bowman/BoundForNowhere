using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettingsData", menuName = "PlayerSettingsData", order = 0)]
public class PlayerSettingsData : ScriptableObject {
    
    public int sensitivity;
    public bool invert;
}

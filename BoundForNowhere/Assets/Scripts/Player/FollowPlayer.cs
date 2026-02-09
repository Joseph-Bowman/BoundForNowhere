using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
 
    //sets the position to the camera position
    void Update() { transform.position = cameraPos.position; }
}

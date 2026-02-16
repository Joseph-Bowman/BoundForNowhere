using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
 
    //sets the position to the camera position
    void LateUpdate() { transform.position = cameraPos.position; }
}

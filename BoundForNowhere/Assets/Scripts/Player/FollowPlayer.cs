using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
 
    void Update()
    {
        transform.position = cameraPos.position;
    }
}

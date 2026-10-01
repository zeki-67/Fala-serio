
using UnityEngine;

public class POVCamera : MonoBehaviour
{
    public Transform player;
   
   void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
    }

}

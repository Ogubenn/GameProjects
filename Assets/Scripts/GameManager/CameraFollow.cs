using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;

    public Transform target;

    #region LateUpdate Kamera
    void LateUpdate() 
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed* Time.deltaTime);
    }
    #endregion
    // Slerp = İki vectör arası yumuşak geçişi sağlar.
}//class

using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayerInter
{
    public float speed = 5f;
    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (h, 0, v).normalized;
        transform.Translate (direction*speed);
        Debug.Log("Player Movement normally."); 
    }
}

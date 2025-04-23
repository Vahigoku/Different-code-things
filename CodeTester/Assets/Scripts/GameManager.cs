using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BasePlayer basePlayer = FindObjectOfType<BasePlayer>();
        SpeedDecorator speedBoost = basePlayer.gameObject.AddComponent<SpeedDecorator>();
        speedBoost.SetPlayer(basePlayer);
        speedBoost.Move();
        //Destroy(speedBoost);
    }

    
}

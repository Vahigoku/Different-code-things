using UnityEngine;

public class SpeedDecorator : PlayerWrapperDecorator
{
    public override void Move()
    {
        decoratePlayer.Move();
        Debug.Log("SpeedBoost Applied! Kachow(?)!");
    }
}

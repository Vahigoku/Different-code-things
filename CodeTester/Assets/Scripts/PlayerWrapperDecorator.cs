using UnityEngine;

public abstract class PlayerWrapperDecorator : MonoBehaviour, IPlayerInter
{
    protected IPlayerInter decoratePlayer;
    public void SetPlayer(IPlayerInter player)
    {
        decoratePlayer = player;
    }
    public virtual void Move()
    {
        decoratePlayer.Move();
    }
}

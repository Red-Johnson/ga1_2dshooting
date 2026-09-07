using UnityEngine;

public class MoveSpeedUpItem : Item
{
    protected override void Effect(GameObject targetPlayer)
    {
        if (targetPlayer.TryGetComponent<PlayerMove>(out PlayerMove moveScript))
        {
            if (moveScript.Speed <= 6f)
            {
                if (moveScript.Speed + 0.5f > 6f)
                {
                    moveScript.Speed = 6f;
                }
                else
                {
                    moveScript.Speed += 0.5f;
                }

                Debug.Log($"[이동속도 증가]");
            }
        }
    }
}
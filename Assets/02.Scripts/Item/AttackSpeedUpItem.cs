using UnityEngine;

public class AttackSpeedUpItem : Item
{
    protected override void Effect(GameObject targetPlayer)
    {
        if (targetPlayer.TryGetComponent<PlayerFire>(out PlayerFire fireScript))
        {
            if (fireScript.AttackCoolDown >= 0)
            {
                if (fireScript.AttackCoolDown - 0.1f < 0.3f)
                {
                    fireScript.AttackCoolDown = 0.3f;
                }
                else
                {
                    fireScript.AttackCoolDown -= 0.1f;
                }

                Debug.Log($"[공격속도 증가]");
            }
        }
    }
}
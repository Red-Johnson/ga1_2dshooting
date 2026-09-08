using UnityEngine;

public class HealthUpItem : Item
{
    protected override void Effect(GameObject targetPlayer)
    {
        if (targetPlayer.TryGetComponent<Player>(out Player healthScript))
        {
            healthScript.Heal();
        }
    }
}
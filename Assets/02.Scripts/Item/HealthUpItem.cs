using UnityEngine;

public class HealthUpItem : Item
{
    protected override void Effect(GameObject targetPlayer)
    {

        if (targetPlayer.TryGetComponent<Player>(out Player healthScript))
        {
            if (healthScript._health < 100)
            {
                if (healthScript._health + 10 > 100)
                {
                    healthScript._health = 100;
                }
                else
                {
                    healthScript._health += 10;
                }
                
                Debug.Log($"[체력 회복]");
                
            }
        }
        
    }
}

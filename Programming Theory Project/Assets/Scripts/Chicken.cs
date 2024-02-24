using UnityEngine;

public class Chicken : Animal
{
    // Override Run function for chickens
    public override void Run()
    {
        // Get the direction from the player to the chicken
        Vector3 playerDirection = transform.position - Player.instance.transform.position;
        playerDirection.y = 0f;

        // Calculate the distance to the player
        float distanceToPlayer = playerDirection.magnitude;

        // Check if the player is in front and within 5m or from behind and within 2m
        if (Vector3.Dot(transform.forward, playerDirection.normalized) > 0 && distanceToPlayer < 5f)
        {
            Debug.Log("Chicken detected player in front and is running!");
        }
        else if (Vector3.Dot(transform.forward, playerDirection.normalized) < 0 && distanceToPlayer < 2f)
        {
            Debug.Log("Chicken detected player from behind and is running!");
        }
    }
}

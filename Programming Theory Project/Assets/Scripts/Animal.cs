using System.Collections;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    // Encapsulated attributes
    private string _animalName;
    private float _wanderSpeed = 2f;
    private float _changeDirectionInterval = 3f;

    // Public properties with getter and setter methods // ENCAPSULATION
    public string AnimalName
    {
        get { return GetAnimalName(); }
        set { SetAnimalName(value); }
    }

    public float WanderSpeed
    {
        get { return GetWanderSpeed(); }
        set { SetWanderSpeed(value); }
    }

    public float ChangeDirectionInterval
    {
        get { return GetChangeDirectionInterval(); }
        set { SetChangeDirectionInterval(value); }
    }

    // Components
    protected Rigidbody rb;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Start wandering coroutine
        StartCoroutine(Wander());
    }

    // Coroutine for wandering
    private IEnumerator Wander()
    {
        while (true)
        {
            // Generate a random direction
            Vector3 randomDirection = Random.insideUnitSphere * 10f;

            // Flatten the direction to stay on the same plane as the ground
            randomDirection.y = 0f;

            // Normalize the direction to ensure consistent speed
            randomDirection.Normalize();

            // Move the animal in the random direction
            rb.velocity = randomDirection * WanderSpeed;

            // Wait for a random interval before changing direction again
            yield return new WaitForSeconds(Random.Range(ChangeDirectionInterval * 0.5f, ChangeDirectionInterval * 1.5f));
        }
    }

    // Getters and setters using methods
    private string GetAnimalName()
    {
        return _animalName;
    }

    private void SetAnimalName(string value)
    {
        _animalName = value;
    }

    private float GetWanderSpeed()
    {
        return _wanderSpeed;
    }

    private void SetWanderSpeed(float value)
    {
        _wanderSpeed = value;
    }

    private float GetChangeDirectionInterval()
    {
        return _changeDirectionInterval;
    }

    private void SetChangeDirectionInterval(float value)
    {
        _changeDirectionInterval = value;
    }

    // Abstract method representing the running behavior //ABSTRACTION
    public abstract void Run();
}

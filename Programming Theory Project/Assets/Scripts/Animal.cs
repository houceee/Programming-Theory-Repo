using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Attributes
    private bool isSelected = false;
    private bool isEating = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize any necessary values
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Check for user input to select or eat
        CheckInput();
    }

    void Move()
    {
        // Implement movement logic
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Adjust position based on input
        transform.Translate(new Vector3(horizontal, 0f, vertical) * Time.deltaTime * 5f);

        // Jump with space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Implement jump logic
        // For example, apply force to Rigidbody for realistic jumping
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 500f);
        }
    }

    void CheckInput()
    {
        // Check for left mouse button click to select
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }

        // Check for 'E' key to initiate eating
        if (Input.GetKeyDown(KeyCode.E))
        {
            Eat();
        }
    }

    void Select()
    {
        // Toggle the selected state
        isSelected = !isSelected;

        // Perform actions based on selection state
        if (isSelected)
        {
            Debug.Log("Animal selected!");
        }
        else
        {
            Debug.Log("Animal deselected.");
        }
    }

    void Eat()
    {
        // Check if the animal is in a cage
        // Implement logic to initiate eating when in a cage
        if (isInCage())
        {
            isEating = true;
            Debug.Log("Animal is eating.");
        }
    }

    bool isInCage()
    {
        // Implement logic to check if the animal is in a cage
        // For example, check if the animal's position is within a specific range or collider
        // Return true if the animal is in a cage, otherwise return false
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private float walkingSpeed = 0.3f;
    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    private bool forward = false;
    private bool backwards = false;
    private bool right = false;
    private bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Get selected character from previous scene
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        
        if(player1 != null && player2 != null)
        {
            if (selectedCharacter == 0)
            {
                player1.SetActive(true);
                player2.SetActive(false);
            }
            else
            {
                player1.SetActive(false);
                player2.SetActive(true);
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController != null)
        {
            if (forward)
            {
                moveDirection = transform.TransformDirection(Vector3.forward * walkingSpeed * Time.deltaTime);
                characterController.Move(moveDirection);
            }
            else if (backwards)
            {
                moveDirection = transform.TransformDirection(Vector3.back * walkingSpeed * Time.deltaTime);
                characterController.Move(moveDirection);
            }
            else if (right)
            {
                Vector3 rotation = new Vector3(0, 1 * rotationSpeed * Time.deltaTime, 0);
                transform.Rotate(rotation);
            }
            else if (left)
            {
                Vector3 rotation = new Vector3(0, -1 * rotationSpeed * Time.deltaTime, 0);
                transform.Rotate(rotation);
            }
        }
    }

    public void setWalkingF(bool moving)
    {
        forward = moving;
    }

    public void setWalkingB(bool moving)
    {
        backwards = moving;
    }

    public void setRotateR(bool rotate)
    {
        right = rotate;
    }

    public void setRotateL(bool rotate)
    {
        left = rotate;
    }

    public void togglePlayer()
    {
        if (player1 != null && player2 != null)
        {
            if (player1.activeSelf)
            {
                player1.SetActive(false);
                player2.SetActive(true);
            }
            else
            {
                player1.SetActive(true);
                player2.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTableController : MonoBehaviour
{
    [SerializeField]
    public GameObject character;

    [SerializeField]
    public float rotationSpeed = 50f;

    [SerializeField]
    public GameObject speedSlider;
    [SerializeField]
    public GameObject rotationSlider;

    private SelectionAnimationStateController sasc;
    private int pose;
    private bool isSpinning;
    private Slider sSlider;
    private Slider rSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(character != null)
        {
            sasc = character.GetComponent<SelectionAnimationStateController>();
            sasc.setWalkingF(false);
        }

        // first pose = idle
        pose = 0;
        
        // selection screen starts in spinning state
        isSpinning = true;

        if(speedSlider != null)
        {
            sSlider = speedSlider.GetComponent<Slider>();
            sSlider.interactable = isSpinning;
            sSlider.value = rotationSpeed;
        }

        if(rotationSlider != null)
        {
            // rotation should not be controlled when automatic spinning is active
            rSlider = rotationSlider.GetComponent<Slider>();
            rSlider.interactable = !isSpinning;
        }
    }

    // fixed update for consistent rotation speed
    void FixedUpdate()
    {
        if(isSpinning)
        {
            RotatePlatform();   
        }
    }

    public void ToggleSpin()
    {
        isSpinning = !isSpinning;

        if (sSlider != null && rSlider != null)
        {
            sSlider.interactable = isSpinning;
        }

        if(rSlider != null)
        {
            rSlider.interactable = !isSpinning;

            float rotationDegrees = transform.rotation.eulerAngles.y;
            rSlider.value = rotationDegrees;
        }
    }

    public void RotatePlatform()
    {
        if(rSlider != null)
        {
            Vector3 rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
            transform.Rotate(rotation);
            rSlider.value = transform.rotation.eulerAngles.y;
        }
    }

    public void SetRotation()
    {
        if(rSlider != null) 
        {
            float sliderRotation = rSlider.value;
            Vector3 rotation = new Vector3(0, sliderRotation, 0);
            transform.eulerAngles = rotation;
        }
    }

    public void ChangeSpinSpeed()
    {
        if(sSlider != null)
        {
            float speed = sSlider.value;
            rotationSpeed = speed;
        }
    }

    public void TogglePose()
    {
        if(sasc != null)
        {
            switch (pose)
            {
                case 0:
                    pose = 1;
                    sasc.setWalkingF(true);
                    break;

                case 1:
                    pose = 0;
                    sasc.setWalkingF(false);
                    break;

                default:
                    break;
            }
        }
    }
}

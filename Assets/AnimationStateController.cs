using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    private int isWalkingFHash;
    private int isWalkingBHash;

    private bool forward = false;
    private bool backwards = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingFHash = Animator.StringToHash("isWalkingF");
        isWalkingBHash = Animator.StringToHash("isWalkingB");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            bool isWalking = (animator.GetBool(isWalkingFHash) || animator.GetBool(isWalkingBHash));

            if (!isWalking && forward)
            {
                // Change animation to walking forwards
                animator.SetBool(isWalkingFHash, true);
            }
            else if (isWalking && !forward)
            {
                // Change animation to idle
                animator.SetBool(isWalkingFHash, false);
                animator.SetBool(isWalkingBHash, false);
            }
            else if (!isWalking && backwards)
            {
                // Change animation to walking backwards
                animator.SetBool(isWalkingBHash, true);
            }
            else if (isWalking && !backwards)
            {
                // Change animation to idle
                animator.SetBool(isWalkingFHash, false);
                animator.SetBool(isWalkingBHash, false);
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
}

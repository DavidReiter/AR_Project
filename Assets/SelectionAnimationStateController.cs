using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingFHash;

    private bool forward = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingFHash = Animator.StringToHash("isWalkingF");
    }

    // Update is called once per frame
    void Update()
    {

        bool isWalking = animator.GetBool(isWalkingFHash);

        if (!isWalking && forward)
        {
            // Change animation to walking forwards
            animator.SetBool(isWalkingFHash, true);
        }
        if (isWalking && !forward)
        {
            // Change animation to idle
            animator.SetBool(isWalkingFHash, false);
        }
    }

    public void setWalkingF(bool moving)
    {
        forward = moving;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private Animator animator;

    [Header("Setting")]
    [SerializeField] private float moveSpeedMultipiler;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ManageAnimations(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            animator.SetFloat("moveSpeed", moveVector.magnitude * moveSpeedMultipiler);
            PlayRunAnimation();

            animator.transform.forward = moveVector.normalized;
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    private void PlayRunAnimation()
    {
        animator.Play("Run");
    }

    private void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }



}//Class

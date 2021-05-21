using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Anims_mov : MonoBehaviour
{
    public static Movement movement;
    public string CurrentState;
    public Vector2 orientation;

    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Front;
    [SerializeField] private GameObject Back;

    [Header("Animation Right")]
    public SkeletonAnimation skeletonAnimation_Right;
    public AnimationReferenceAsset Idle_Right, Walking_Right;

    [Header("Animation Left")]
    public SkeletonAnimation skeletonAnimation_Left;
    public AnimationReferenceAsset Idle_Left, Walking_Left;

    [Header("Animation Front")]
    public SkeletonAnimation skeletonAnimation_Front;
    public AnimationReferenceAsset Idle_Front, Walking_Front;

    [Header("Animation Back")]
    public SkeletonAnimation skeletonAnimation_Back;
    public AnimationReferenceAsset Idle_Back, Walking_Back;

    // Start is called before the first frame update
    void Start()
    {
        movement = Movement.instance;
        CurrentState = "idle";
        SetCharacterState(CurrentState);
    }

    // Update is called once per frame
    void Update()
    {
        orientation = movement.change;

        if (orientation.y == 1)
        {
            Back.SetActive(true);
            Front.SetActive(false);
            Right.SetActive(false);
            Left.SetActive(false);

        }
        else if (orientation.y == -1)
        {

            Front.SetActive(true);
            Right.SetActive(false);
            Left.SetActive(false);
            Back.SetActive(false);

        }
        else if (orientation.x == 1)
        {

            Right.SetActive(true);
            Left.SetActive(false);
            Back.SetActive(false);
            Front.SetActive(false);
        }
        else if (orientation.x == -1)
        {

            Left.SetActive(true);
            Back.SetActive(false);
            Front.SetActive(false);
            Right.SetActive(false);

        }
    }

    public void Setanim(AnimationReferenceAsset anim, bool loop, float timescale)
    {
        if (anim.name.Equals(CurrentState))
        {
            return;

        }
        CurrentState=anim.name;

        skeletonAnimation_Left.state.SetAnimation(0, anim, loop).TimeScale=timescale;
    }
    public void SetCharacterState(string state)
    {
        if (state.Equals("idle"))
        {
            Setanim(Idle_Left, true, 1f);
        }
        if (state.Equals("walking"))
        {
            Setanim(Walking_Left, true, 1f);
        }
    }

    public void CheckMove()
    {
        if (movement.change.x>0)
        {

        }
    }
}

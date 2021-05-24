using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Anim_Recolteur_enemy : MonoBehaviour
{
    public GameObject SideObject;
    public GameObject FrontObject;
    public GameObject BackObject;


    public bool Front;
    public bool Back;
    public bool Side;
    Movement movement;
    public SkeletonAnimation Skeleton;
    public SkeletonAnimation Skeleton_G;
    public SkeletonAnimation Skeleton_B;
    public SkeletonAnimation Skeleton_F;
    [Header("Animation side")]
    public AnimationReferenceAsset idle;
    public AnimationReferenceAsset marche;

    [Header("Atk")]

    public AnimationReferenceAsset Atk;

    [Header("Animation front")]
    public AnimationReferenceAsset idleF;
    public AnimationReferenceAsset marcheF;

    [Header("Atk")]

    public AnimationReferenceAsset AtkF;

    [Header("Animation back")]
    public AnimationReferenceAsset idleB;
    public AnimationReferenceAsset marcheB;

    [Header("Atk")]

    public AnimationReferenceAsset AtkB;

    public string CurrentState;
    public string CurrentAnim;
    public Vector2 direction;
    public Vector2 transformInit;


    private void Start()
    {
        transformInit = transform.localScale;
        Skeleton = Skeleton_F;
        movement = Movement.instance;
        CurrentState = "idle";
        SetCharacterState(CurrentState);
    }

    public void Update()
    {
        CheckDash();

        direction = this.GetComponentInParent<MovementIA>().Direction;
        if (this.GetComponentInParent<MovementIA>().InDistance)
        {
            if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
            {
                Skeleton = Skeleton_G;
                if (direction.x >= 0)
                {
                    Front = false;
                    Back = false;
                    transform.localScale = new Vector2(-transformInit.x, transformInit.y);
                    FrontObject.SetActive(false);
                    BackObject.SetActive(false);
                    SideObject.SetActive(true);
                }
                else
                {
                    Front = false;
                    Back = false;
                    transform.localScale = transformInit;
                    BackObject.SetActive(false);
                    FrontObject.SetActive(false);
                    SideObject.SetActive(true);
                }

                if (this.GetComponentInParent<MovementIA>().IsAtk == false)
                {
                    SetCharacterState("walking");
                }
            }
            else
            {
                if (direction.y >= 0)
                {
                    Front = false;
                    Back = true;
                    BackObject.SetActive(true);
                    FrontObject.SetActive(false);
                    SideObject.SetActive(false);
                    Skeleton = Skeleton_B;
                }
                else
                {
                    BackObject.SetActive(false);
                    FrontObject.SetActive(true);
                    SideObject.SetActive(false);
                    Front = true;
                    Back = false;
                    Skeleton = Skeleton_F;
                }
                if (this.GetComponentInParent<MovementIA>().IsAtk == false)
                {
                    SetCharacterState("walking");
                }
            }
        }
        else
        {
            if (this.GetComponentInParent<MovementIA>().IsAtk == false)
            {
                SetCharacterState("idle");
            }

        }
    }

    public void SetAnim(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        if (animation.name.Equals(CurrentAnim))
        {
            return;
        }
        Skeleton.state.SetAnimation(0, animation, loop).TimeScale = timescale;
        CurrentAnim = animation.name;
    }

    public void SetCharacterState(string state)
    {
        if (state.Equals("Atk"))
        {
            if (Front)
            {
                SetAnim(AtkF, true, 2f);
            }
            else if (Back)
            {
                SetAnim(AtkB, true, 2f);
            }
            else
            {
                SetAnim(Atk, true, 2f);
            }
        }
        else if (state.Equals("walking"))
        {
            if (Front)
            {
                SetAnim(marcheF, true, 2f);
            }
            else if (Back)
            {
                SetAnim(marcheB, true, 2f);
            }
            else
            {
                SetAnim(marche, true, 2f);
            }
        }
        else
        {

            if (Front)
            {
                SetAnim(idleF, true, 2f);
            }
            else if (Back)
            {
                SetAnim(idleB, true, 2f);
            }
            else
            {
                SetAnim(idle, true, 2f);
            }
        }
    }
    public void CheckDash()
    {
        if (this.GetComponentInParent<MovementIA>().IsAtk == true)
        {
            SetCharacterState("Atk");
        }

    }
}

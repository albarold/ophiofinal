using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class anim_mineur : MonoBehaviour
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

    [Header("charge")]
    public AnimationReferenceAsset set;
    public AnimationReferenceAsset charge;

    [Header("Animation front")]
    public AnimationReferenceAsset idleF;
    public AnimationReferenceAsset marcheF;

    [Header("charge")]
    public AnimationReferenceAsset setF;
    public AnimationReferenceAsset chargeF;

    [Header("Animation back")]
    public AnimationReferenceAsset idleB;
    public AnimationReferenceAsset marcheB;

    [Header("charge")]
    public AnimationReferenceAsset setB;
    public AnimationReferenceAsset chargeB;

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

        direction = this.GetComponentInParent<CicindellaIa>().Direction;
        if (this.GetComponentInParent<CicindellaIa>().InArea)
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

                if (this.GetComponentInParent<CicindellaIa>().Charge == false && this.GetComponentInParent<CicindellaIa>().IsLoading == false)
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
                if (this.GetComponentInParent<CicindellaIa>().Charge == false && this.GetComponentInParent<CicindellaIa>().IsLoading == false)
                {
                    SetCharacterState("walking");
                }
            }
        }
        else 
        {
            if (this.GetComponentInParent<CicindellaIa>().Charge == false && this.GetComponentInParent<CicindellaIa>().IsLoading == false)
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
        CurrentState = state;
        if (state.Equals("set"))
        {
            if (Front)
            {
                SetAnim(setF, true, 2f);
            }
            else if (Back)
            {
                SetAnim(setB, true, 2f);
            }
            else
            {
                SetAnim(set, true, 2f);
            }
        }
        else if (state.Equals("charge"))
        {
            if (Front)
            {
                SetAnim(chargeF, true, 2f);
            }
            else if (Back)
            {
                SetAnim(chargeB, true, 2f);
            }
            else
            {
                SetAnim(charge, true, 2f);
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
        if (this.GetComponentInParent<CicindellaIa>().Charge==true)
        {
            SetCharacterState("charge");
        }
        if (this.GetComponentInParent<CicindellaIa>().IsLoading== true)
        {
            SetCharacterState("set");
        }

    }
}

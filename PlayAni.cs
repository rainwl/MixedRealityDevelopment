using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayAni : MonoBehaviour
{
    public AnimationClip Playanim;
    public AnimationClip Endanim;
  
    public void Playani()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play(Playanim.name);
    }
    public void Endani()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play(Endanim.name);
    }
}

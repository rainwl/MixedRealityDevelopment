//该脚本可以用按钮的click事件控制动画clip的播放
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayAni : MonoBehaviour
{
    public AnimationClip Playanim;//开始的动画
    public AnimationClip Endanim; //结束的动画
  
    public void Playani()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play(Playanim.name);//播放这个名字的动画
    }
    public void Endani()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play(Endanim.name);
    }
}

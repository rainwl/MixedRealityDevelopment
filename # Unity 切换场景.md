# Unity 常用代码
[top]

## 切换场景
```csharp
UnityEngine.SceneManagement;
SceneManager.LoadScene("sceneName");
```

## 动态替换材质球
```csharp
public Material material;//更改后的材质球，可拖拽赋值
gameObject.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(material);//更改材质球
```
## 动态更换材质球的贴图
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightingTexture : MonoBehaviour
{    
    /// <summary>
    /// 渲染网格
    /// </summary>
    private MeshRenderer meshRenderer;
    /// <summary>
    /// 贴图数组
    /// </summary>
    private Texture[] texture;
    /// <summary>
    /// Resource文件夹下的存放贴图的子文件名
    /// </summary>
    private string materialTexture = "MaterialTexture";
    /// <summary>
    /// 贴图数量
    /// </summary>
    private int textureCount = 5;
    /// <summary>
    /// 一开始循环的索引
    /// </summary>
    private int index = 0;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        //定义获取贴图的数量
        texture = new Texture[textureCount];
        //动态加载贴图
        for (int i = 0; i < texture.Length; i++)
        {
            texture[i] = Resources.Load(materialTexture + "/texture" + (i + 1)) as Texture;
        }
    }

    public void Change()
    {
        meshRenderer.material.SetTexture("_MainTex", texture[index]);
        index = (index + 1) % texture.Length;
    }


}

```
写好这个脚本后，在`Assets`文件夹虾面新建一个文件夹`Resources`，在`Resources`下再建一个`MaterialTexture`文件夹，里面存入需要更改的贴图文件，依次命名为`texture1`,`texture2`,,,`etc`。然后新建一个材质球，赋给一个物体，材质球里`_MainTex`用前面提到的一个贴图就可以。然后给一个`button`挂代码，执行`Change（）`方法

## 动态修改材质球

需要改变材质球的对象挂上脚本`ColorChanger`
```csharp
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    /// <summary>
    /// Change the color of the material on a renderer.  Useful for visualizing button presses.
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/Examples/ColorChanger")]
    public class ColorChanger : MonoBehaviour
    {
        public MeshRenderer rend;
        public Material[] mats;
        public int cur;

        private void Start()
        {
            if (rend == null)
            {
                rend = GetComponent<MeshRenderer>();
            }
        }

        /// <summary>
        /// Increments to the next material in the input list of materials and applies it to the renderer.
        /// </summary>
        public void Increment()
        {
            if (mats != null && mats.Length > 0)
            {
                cur = (cur + 1) % mats.Length;
                if (rend != null)
                {
                    rend.material = mats[cur];
                }
            }
        }
        
        /// <summary>
        /// Decrements to the previous material in the input list of materials and applies it to the renderer.
        /// </summary>
        public void Decrement()
        {
            if (mats != null && mats.Length > 0)
            {
                cur = (cur - 1 + mats.Length) % mats.Length;
                if (rend != null)
                {
                    rend.material = mats[cur];
                }
            }
        }

        /// <summary>
        /// Sets a random color on the renderer's material.
        /// </summary>
        public void RandomColor()
        {
            rend.material.color = UnityEngine.Random.ColorHSV();
        }
    }
}
```
然后给`button`添加事件，调用`colorchanger`的`Increment`，就按着顺序改变材质了

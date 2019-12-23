演示视频地址
===========
https://v.youku.com/v_show/id_XNDQ3OTU0ODg1Ng==.html?spm=a2h3j.8428770.3416059.1
参考：https://pmlpml.github.io/unity3d-learning/12-AR-and-MR#3作业与练习
##### 环境准备
在vuforia上注册账号，创建证书，创建数据库，在数据库中添加一张图片。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223141428963.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223141446325.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
开启unity的AR支持。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223141622626.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
下载数据库，通过包导入unity。
##### 场景布置
删除原有的相机，添加vuforia的AR相机，再次运行时，可以看到game界面显示的是摄像头捕捉的画面。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223141844907.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
将vuforia网页上提供的证书序列粘贴到相机的configuration栏。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142002950.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
先前导入的数据库会自动添加。
在场景中新建一个image。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142047883.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
在场景中出现了数据库中的识别图。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142116647.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
导入asset store中的voxel animals包，将其中鸡的prefab绑定到imageTarget下，此时再运行，当摄像机捕捉到图片时，会显示鸡。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142315440.png)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142351724.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
给image添加一个虚拟按钮，由于虚拟按钮不会显示，需要给它添加一个带有mesh render的子对象，以便其显示，由于识别图片是白色的，为了方便观察，给按钮添加红色的material。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142555465.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/2019122314261573.png)
再次运行，按钮会在对应位置显示。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142643235.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
##### 设置按钮动作
在Animator中设置变量，设置状态转换条件。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223142759152.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/2019122314281315.png)
编写脚本，将其挂载在imageTarget上。

```c#
using UnityEngine;
using Vuforia;

public class butt : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbs;
    public Animator animator;

    void Start()
    {
        VirtualButtonBehaviour vbb = vbs.GetComponent<VirtualButtonBehaviour>();
        if (vbb)
        {
            vbb.RegisterEventHandler(this);
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Pressed");
        animator.SetBool("isjump", true);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Released");
        animator.SetBool("isjump", false);
    }
}

```
运行，按钮可以控制chiken的动作。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20191223143035517.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L0h1aUZlaURlVHVvTmlhb0da,size_16,color_FFFFFF,t_70)
项目地址[GitHub](https://github.com/Kate0516/3D-/edit/master/homework10)



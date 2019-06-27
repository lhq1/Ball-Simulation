using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 背景视差滚动脚本
/// </summary>
public class ScrollingScript : MonoBehaviour
{
    #region 变量

    /// <summary>
    /// 滚动速度
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);

    /// <summary>
    /// 移动方向
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    /// <summary>
    /// 相机是否运动
    /// </summary>
    public bool isLinkedToCamera = false;

    /// <summary>
    /// 背景是否循环
    /// </summary>
    public bool isLooping = false;

    /// <summary>
    /// 渲染对象名单
    /// </summary>
    private List<Transform> backgroundPart;

    #endregion

    // Use this for initialization
    void Start()
    {
        // 只循环背景
        if (isLooping)
        {
            // 获取该层渲染器的所有子集对象
            backgroundPart = new List<Transform>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                // 只添加可见子集
                if (child.GetComponent<Renderer>() != null)
                {
                    backgroundPart.Add(child);
                }
            }

            // 根据位置排序
            // Note: 根据从左往右的顺序获取子集对象
            // 我们需要增加一些条件来处理所有可能的滚动方向。
            backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 创建运动状态
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // 移动相机
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        // 循环
        if (isLooping)
        {
            // 获取第一个对象
            // 该列表的顺序是从左往右(基于x坐标)
            Transform firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                // 检查子集对象(部分)是否在摄像机前已准备好.
                // We test the position first because the IsVisibleFrom
                // method is a bit heavier to execute.
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    // 如果子集对象已经在摄像机的左侧,我们测试它是否完全在外面,以及是否需要被回收.
                    if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {
                        // 获取最后一个子集对象的位置
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

                        // 将被回收的子集对象作为最后一个子集对象
                        // Note: 当前只横向滚动.
                        firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

                        // 将被回收的子集对象设置到backgroundPart的最后位置.
                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
}
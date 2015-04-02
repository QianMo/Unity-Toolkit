//-----------------------------------------------【脚本说明】-------------------------------------------------------
//      脚本功能：   控制Contorller在场景中飞翔
//      使用语言：   C#
//      开发所用IDE版本：Unity4.5 06f 、Visual Studio 2010    
//      2014年12月 Created by 浅墨    
//      更多内容或交流，请访问浅墨的博客：http://blog.csdn.net/poem_qianmo
//---------------------------------------------------------------------------------------------------------------------

//-----------------------------------------------【使用方法】-------------------------------------------------------
//      第一步：在Unity中拖拽此脚本到场景的Controller之上，或在Inspector中[Add Component]->[浅墨's Toolkit]->[SetMaxFPS]
//      第二步：在面板中设置相关鼠标速度
//---------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//添加组件菜单
[AddComponentMenu("浅墨's Toolkit/FlyController")]
public class FlyController : MonoBehaviour
{
    //参数定义
    public float lookSpeed = 5.0f;
    public float moveSpeed = 1.0f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;


    void Update()
    {
        //获取鼠标偏移量
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        //鼠标控制视角
        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
        transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical");
        transform.position += transform.right * moveSpeed * Input.GetAxis("Horizontal");

        //I键，向上平移
        if (Input.GetKey(KeyCode.R))
            transform.position += transform.up * moveSpeed;
        //K键，向下平移
        if (Input.GetKey(KeyCode.F))
            transform.position -= transform.up * moveSpeed;
    }
}

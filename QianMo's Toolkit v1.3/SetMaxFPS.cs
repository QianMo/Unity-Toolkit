//-----------------------------------------------【脚本说明】-------------------------------------------------------
//      脚本功能：   在游戏运行时显示Logo
//      使用语言：   C#
//      开发所用IDE版本：Unity4.5 06f 、Visual Studio 2010    
//      2014年11月 Created by 浅墨    
//      更多内容或交流，请访问浅墨的博客：http://blog.csdn.net/poem_qianmo
//---------------------------------------------------------------------------------------------------------------------

//-----------------------------------------------【使用方法】-------------------------------------------------------
//      第一步：在Unity中拖拽此脚本到场景任意物体上，或在Inspector中[Add Component]->[浅墨's Toolkit]->[SetMaxFPS]
//      第二步：在面板中设置MaxFPSValue参数为需要的帧率值，以及其他参数
//---------------------------------------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

//垂直同步数
public enum VSyncCountSetting
{
    DontSync,
    EveryVBlank,
    EverSecondVBlank
}



[AddComponentMenu("浅墨's Toolkit/SetMaxFPS")]
public class SetMaxFPS : MonoBehaviour
{

    public VSyncCountSetting VSyncCount = VSyncCountSetting.DontSync;//用于快捷设置Unity Quanity设置中的垂直同步相关参数
    public bool MaxNoLimit = false;//不设限制，保持可达到的最高帧率
    public int MaxFPSValue = 80;//帧率的值



    void Awake()
    {
        //设置垂直同步相关参数
        switch (VSyncCount)
        {
            //默认设置，不等待垂直同步，可以获取更高的帧率数
            case VSyncCountSetting.DontSync:
                QualitySettings.vSyncCount = 0;
        	break;

            //EveryVBlank，相当于帧率设为最大60
            case VSyncCountSetting.EveryVBlank:
            QualitySettings.vSyncCount = 1;
            break;
            //EverSecondVBlank情况，相当于帧率设为最大30
            case VSyncCountSetting.EverSecondVBlank:
            QualitySettings.vSyncCount = 2;
            break;

        }

        //设置没有帧率限制，火力全开！
        if (MaxNoLimit)
        {
            Application.targetFrameRate = -1;
        }
        //设置帧率的值
        else
        {
            Application.targetFrameRate = MaxFPSValue - 1;
        }
       
    }
}

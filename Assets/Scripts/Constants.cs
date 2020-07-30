using UnityEngine;
using System.Collections;

#if UNITY_IOS
using UnityEngine.iOS;
#endif

/// <summary>
/// 定数定義クラス
/// </summary>
static public class Constants
{
    /// <summary>
    /// 基準とするスクリーンサイズの高さ（H）iPhone6を基準とする。
    /// </summary>
    public const float DefaultScreenHeight = 1334;

    /// <summary>
    /// 基準とするスクリーンサイズの幅（W）iPhone6を基準とする。
    /// </summary>
    public const float DefaultScreenWidth = 750;
    
    public static readonly float IosStatusBarHeight = 0f;
}
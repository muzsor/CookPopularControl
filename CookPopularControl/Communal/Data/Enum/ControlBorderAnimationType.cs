﻿/*
 * Copyright (c) 2021 All Rights Reserved.
 * Description：ControlBorderAni
 * Author： Chance_写代码的厨子
 * Create Time：2021-07-30 16:38:38
 */
namespace CookPopularControl.Communal.Data
{
    /// <summary>
    /// 表示<see cref="ControlBorderBehavior.AnimationType"/>枚举类型
    /// </summary>
    public enum ControlBorderAnimationType
    {
        /// <summary>
        /// 同时变化
        /// </summary>
        Thickness,
        /// <summary>
        /// 下,右,上,左有序变化
        /// </summary>
        OrderThickness,
        /// <summary>
        /// 路径
        /// </summary>
        Path,
    }
}

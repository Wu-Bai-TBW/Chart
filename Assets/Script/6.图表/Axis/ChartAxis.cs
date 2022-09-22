using System;
using System.Collections.Generic;
using UnityEngine;

namespace M_Chart
{
    public enum EScaleDataType
    {
        Value,      // 根据传输数据 动态修改所有刻度值
        Custom      // 自行设置每个刻度值
    }
    public abstract class ChartAxis
    {
        protected RectTransform m_RectTransform;


        [SerializeField] protected bool _AxisLine = true;                       // 是否启用轴线
        [SerializeField] protected float _AxisLineWight = 1;                    // 轴线宽度
        [SerializeField] protected float _AxisOffset = 0;                       // 轴线偏移值
        [SerializeField] protected Color _AxisColor = Color.white;              // 轴线颜色
        [SerializeField] protected bool _Inversion = false;                     // 是否翻转轴


        [SerializeField] protected bool _Scale = true;                          // 是否启用刻度
        [SerializeField] protected Font _Font;                                  // 字体
        [SerializeField] protected int _FontSize = 14;                          // 字体大小
        [SerializeField] protected Color _FontColor = Color.white;              // 字体颜色
        [SerializeField] protected EScaleDataType _EScaleDataType;              // 刻度值模式
        [SerializeField] protected int _ScaleDisNum = 3;                        // 刻度显示个数(中间)


        [SerializeField] protected bool _ScaleLine = false;                     // 是否启用刻度线
        [SerializeField] protected float _ScaleLineHeight;                      // 刻度线高度
        [SerializeField] protected float _ScaleLineWight;                       // 刻度线宽度
        [SerializeField] protected float _ScaleLineOffset;                      // 刻度线偏移值
        [SerializeField] protected Color _ScaleLineColor = Color.white;         // 刻度线颜色


        public bool _ScaleAuxiliaryLine = false;                                // 是否启用刻度辅助线
        [SerializeField] protected Color _ScaleAuxiliaryColor = Color.white;    // 刻度辅助线颜色


        public bool _Arrow = false;     // 是否启用箭头

        //===============================================================================

        public Color GetAxisColor => _AxisColor;
        public Color GetFontColor => _FontColor;
        public Color GetScaleLineColor => _ScaleLineColor;

        //===============================================================================

        /// <summary>
        /// 返回轴线绘制点
        /// </summary>
        /// <param name="_AxisLineWight"></param>
        /// <returns></returns>
        public abstract Vector2[] GetAxisPoint(Rect rect);
        /// <summary>
        /// 返回刻度线绘制点
        /// </summary>
        /// <param name="_TickMarkLineWight"></param>
        /// <returns></returns>
        public abstract List<Vector2[]> GetScaleLinePoint(Rect rect);
        /// <summary>
        /// 展示刻度文字
        /// </summary>
        public abstract void ShowScaleText(Rect rect);

        //===============================================================================

        protected float ScaleNumAvg(float num)
        {
            return num / (_ScaleDisNum + 1);
        }
    }
}
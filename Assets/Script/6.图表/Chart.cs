using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace M_Chart
{
    public class Chart : MaskableGraphic
    {
        [SerializeField] private float _LineWight;

        private ChartAxis_X chartAxis_X;
        private ChartAxis_Y chartAxis_Y;
        private ChartAxis_Z chartAxis_Z;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            AxisInit(rectTransform);

            //base.OnPopulateMesh(vh);
            vh.Clear();
            UIVertex[] Axis_X = GetUIVertices(color, chartAxis_X.GetAxisPoint(_LineWight));
            UIVertex[] Axis_Y = GetUIVertices(color, chartAxis_Y.GetAxisPoint(_LineWight));
            vh.AddUIVertexQuad(Axis_X);
            vh.AddUIVertexQuad(Axis_Y);
        }

        private UIVertex[] GetUIVertices(Color _Color, params Vector2[] points)
        {
            UIVertex[] uIVertices = new UIVertex[points.Length];
            for (int i = 0; i < uIVertices.Length; i++)
            {
                uIVertices[i] = SetUIVertex(_Color, points[i]);
            }
            return uIVertices;
        }

        private UIVertex SetUIVertex(Color _Color, Vector2 point)
        {
            return new UIVertex() { position = point, color = _Color, uv0 = Vector2.zero };
        }

        //================================================================================

        /// <summary>
        /// 轴向初始化
        /// </summary>
        /// <param name="_RectTransform"></param>
        private void AxisInit(RectTransform _RectTransform)
        {
            if (chartAxis_X == null)
            {
                chartAxis_X = new ChartAxis_X(_RectTransform);
            }
            if (chartAxis_Y == null)
            {
                chartAxis_Y = new ChartAxis_Y(_RectTransform);
            }
            if (chartAxis_Z == null)
            {
                chartAxis_Z = new ChartAxis_Z(_RectTransform);
            }
        }
    }
    public abstract class ChartAxis
    {
        protected RectTransform m_RectTransform;

        protected ChartAxis(RectTransform _RectTransform)
        {
            m_RectTransform = _RectTransform;
        }

        //===============================================================================

        /// <summary>
        /// 返回轴线绘制点
        /// </summary>
        /// <param name="_AxisLineWight"></param>
        /// <returns></returns>
        public abstract Vector2[] GetAxisPoint(float _AxisLineWight);
        /// <summary>
        /// 返回刻度线绘制点
        /// </summary>
        /// <param name="_TickMarkLineWight"></param>
        /// <returns></returns>
        public abstract Vector2[] GetTickMarkPoint(float _TickMarkLineWight);

        //===============================================================================
        /// <summary>
        /// 获取RectTransform
        /// </summary>
        /// <returns></returns>
        protected Rect GetTransformRect()
        {
            return m_RectTransform.rect;
        }
    }
    public class ChartAxis_X : ChartAxis
    {
        public ChartAxis_X(RectTransform _RectTransform) : base(_RectTransform)
        {

        }

        public override Vector2[] GetAxisPoint(float _AxisLineWight)
        {
            Rect rect = GetTransformRect();
            float width = rect.width;
            float height = rect.height;

            Vector2 r1 = new Vector2();
            Vector2 r2 = new Vector2();
            Vector2 r3 = new Vector2();
            Vector2 r4 = new Vector2();

            r1.x = -width * .5f;
            r1.y = -height * .5f;

            r2.x = -width * .5f;
            r2.y = height * .5f;

            r3.x = -width * .5f + _AxisLineWight;
            r3.y = height * .5f;

            r4.x = -width * .5f + _AxisLineWight;
            r4.y = -height * .5f;

            return new Vector2[] { r1, r2, r3, r4 };
        }
        public override Vector2[] GetTickMarkPoint(float _TickMarkLineWight)
        {
            return null;
        }
    }
    public class ChartAxis_Y : ChartAxis
    {
        public ChartAxis_Y(RectTransform _RectTransform) : base(_RectTransform)
        {

        }
        public override Vector2[] GetAxisPoint(float _AxisLineWight)
        {
            Rect rect = GetTransformRect();
            float width = rect.width;
            float height = rect.height;

            Vector2 r1 = new Vector2();
            Vector2 r2 = new Vector2();
            Vector2 r3 = new Vector2();
            Vector2 r4 = new Vector2();

            r1.x = -width * .5f;
            r1.y = -height * .5f;

            r2.x = -width * .5f;
            r2.y = -height * .5f + _AxisLineWight;

            r3.x = width * .5f;
            r3.y = -height * .5f + _AxisLineWight;

            r4.x = width * .5f;
            r4.y = -height * .5f;

            return new Vector2[] { r1, r2, r3, r4 };
        }
        public override Vector2[] GetTickMarkPoint(float _TickMarkLineWight)
        {
            return null;
        }
    }
    public class ChartAxis_Z : ChartAxis
    {
        public ChartAxis_Z(RectTransform _RectTransform) : base(_RectTransform)
        {

        }
        public override Vector2[] GetAxisPoint(float _AxisLineWight)
        {
            return null;
        }

        public override Vector2[] GetTickMarkPoint(float _TickMarkLineWight)
        {
            return null;
        }
    }

}
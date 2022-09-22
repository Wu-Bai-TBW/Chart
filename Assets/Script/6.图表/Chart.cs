using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace M_Chart
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class Chart : MaskableGraphic
    {
        [SerializeField] private float Padding_Left;    // 左内边距
        [SerializeField] private float Padding_Right;   // 右内边距
        [SerializeField] private float Padding_Top;     // 上内边距
        [SerializeField] private float Padding_Bottom;  // 下内边距


        [SerializeField] private ChartAxis_X chartAxis_X;
        [SerializeField] private ChartAxis_Y chartAxis_Y;
        [SerializeField] private ChartAxis_Z chartAxis_Z;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            Rect mainRect = GetMainRect();

            DrawAxis(vh, chartAxis_X.GetAxisColor, chartAxis_X.GetAxisPoint(mainRect));
            DrawAxis(vh, chartAxis_Y.GetAxisColor, chartAxis_Y.GetAxisPoint(mainRect));

            DrawScaleLine(vh, chartAxis_X.GetScaleLineColor, chartAxis_X.GetScaleLinePoint(mainRect));
            DrawScaleLine(vh, chartAxis_Y.GetScaleLineColor, chartAxis_Y.GetScaleLinePoint(mainRect));
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
        /// 获取主矩形
        /// </summary>
        private Rect GetMainRect()
        {
            Rect rect = rectTransform.rect;
            rect.width -= (Padding_Left + Padding_Right);
            rect.height -= (Padding_Top + Padding_Bottom);
            rect.x += Padding_Left;
            rect.y += Padding_Bottom;

            return rect;
        }

        /// <summary>
        /// 绘制轴
        /// </summary>
        /// <param name="vh"></param>
        /// <param name="_Color"></param>
        /// <param name="points"></param>
        private void DrawAxis(VertexHelper vh, Color _Color, Vector2[] points)
        {
            if (points == null)
            {
                return;
            }

            UIVertex[] Axis = GetUIVertices(_Color, points);
            vh.AddUIVertexQuad(Axis);
        }

        /// <summary>
        /// 绘制刻度线
        /// </summary>
        /// <param name="vh"></param>
        /// <param name="_Color"></param>
        /// <param name="points"></param>
        private void DrawScaleLine(VertexHelper vh, Color _Color, List<Vector2[]> points)
        {
            if (points == null)
            {
                return;
            }

            for (int i = 0; i < points.Count; i++)
            {
                UIVertex[] Axis = GetUIVertices(_Color, points[i]);
                vh.AddUIVertexQuad(Axis);
            }
        }
    }
}
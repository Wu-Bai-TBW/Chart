using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace M_Chart
{
    public enum EAxisDirection_Y
    {
        Left,
        Right
    }

    [Serializable]
    public class ChartAxis_Y : ChartAxis
    {
        [SerializeField] private EAxisDirection_Y _AxisLineDirection = EAxisDirection_Y.Left;
        [SerializeField] private EAxisDirection_Y _ScaleLineDirection = EAxisDirection_Y.Left;
        public override Vector2[] GetAxisPoint(Rect rect)
        {
            if (!_AxisLine)
            {
                return null;
            }

            Vector2 r1 = new Vector2();
            Vector2 r2 = new Vector2();
            Vector2 r3 = new Vector2();
            Vector2 r4 = new Vector2();

            switch (_AxisLineDirection)
            {
                case EAxisDirection_Y.Left:
                    r1.x = rect.xMin + _AxisOffset;
                    r2.x = rect.xMin + _AxisOffset;
                    r3.x = rect.xMin + _AxisLineWight + _AxisOffset;
                    r4.x = rect.xMin + _AxisLineWight + _AxisOffset;
                    break;
                case EAxisDirection_Y.Right:
                    r1.x = rect.xMin + rect.width - _AxisOffset - _AxisLineWight;
                    r2.x = rect.xMin + rect.width - _AxisOffset - _AxisLineWight;
                    r3.x = rect.xMin + rect.width - _AxisOffset;
                    r4.x = rect.xMin + rect.width - _AxisOffset;
                    break;
                default:
                    break;
            }

            if (_Inversion)
            {
                r1.y = rect.yMax;
                r2.y = rect.yMin;
                r3.y = rect.yMin;
                r4.y = rect.yMax;
            }
            else
            {
                r1.y = rect.yMin;
                r2.y = rect.yMax;
                r3.y = rect.yMax;
                r4.y = rect.yMin;
            }

            return new Vector2[] { r1, r2, r3, r4 };
        }
        public override List<Vector2[]> GetScaleLinePoint(Rect rect)
        {
            if (!_ScaleLine)
            {
                return null;
            }

            float avg = ScaleNumAvg(rect.height);

            List<Vector2[]> vector2s = new List<Vector2[]>();

            Vector2 r1 = new Vector2();
            Vector2 r2 = new Vector2();
            Vector2 r3 = new Vector2();
            Vector2 r4 = new Vector2();

            for (int i = 0; i <= _ScaleDisNum + 1; i++)
            {
                float disNum = avg * i;


                switch (_ScaleLineDirection)
                {
                    case EAxisDirection_Y.Left:
                        r1.x = rect.xMin + _ScaleLineOffset;
                        r2.x = rect.xMin + _ScaleLineOffset;
                        r3.x = rect.xMin + _ScaleLineHeight + _ScaleLineOffset;
                        r4.x = rect.xMin + _ScaleLineHeight + _ScaleLineOffset;
                        break;
                    case EAxisDirection_Y.Right:
                        r1.x = rect.xMax - _ScaleLineHeight - _ScaleLineOffset;
                        r2.x = rect.xMax - _ScaleLineHeight - _ScaleLineOffset;
                        r3.x = rect.xMax - _ScaleLineOffset;
                        r4.x = rect.xMax - _ScaleLineOffset;
                        break;
                    default:
                        break;
                }
                r1.y = rect.yMin + disNum - _ScaleLineWight * .5f;
                r2.y = rect.yMin + disNum + _ScaleLineWight * .5f;
                r3.y = rect.yMin + disNum + _ScaleLineWight * .5f;
                r4.y = rect.yMin + disNum - _ScaleLineWight * .5f;
                vector2s.Add(new Vector2[] { r1, r2, r3, r4 });
            }

            return vector2s;
        }
        public override void ShowScaleText(Rect rect)
        {
            if (!_Scale)
            {
                return;
            }

            float avg = ScaleNumAvg(rect.height);
            for (int i = 0; i <= _ScaleDisNum + 1; i++)
            {
                //new Text()
            }
        }
    }
}

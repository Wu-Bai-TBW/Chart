using System;
using System.Collections.Generic;
using UnityEngine;

namespace M_Chart
{
    public enum EAxisDirection_X
    {
        Top,
        Bottom
    }

    [Serializable]
    public class ChartAxis_X : ChartAxis
    {
        [SerializeField] private EAxisDirection_X _AxisLineDirection = EAxisDirection_X.Bottom;
        [SerializeField] private EAxisDirection_X _ScaleLineDirection = EAxisDirection_X.Bottom;

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
                case EAxisDirection_X.Top:
                    r1.y = rect.yMin + rect.height - _AxisOffset - _AxisLineWight;
                    r2.y = rect.yMin + rect.height - _AxisOffset;
                    r3.y = rect.yMin + rect.height - _AxisOffset;
                    r4.y = rect.yMin + rect.height - _AxisOffset - _AxisLineWight;
                    break;
                case EAxisDirection_X.Bottom:
                    r1.y = rect.yMin + _AxisOffset;
                    r2.y = rect.yMin + _AxisLineWight + _AxisOffset;
                    r3.y = rect.yMin + _AxisLineWight + _AxisOffset;
                    r4.y = rect.yMin + _AxisOffset;
                    break;
                default:
                    break;
            }

            if (_Inversion)
            {
                r1.x = rect.xMax;
                r2.x = rect.xMax;
                r3.x = rect.xMin;
                r4.x = rect.xMin;
            }
            else
            {
                r1.x = rect.xMin;
                r2.x = rect.xMin;
                r3.x = rect.xMax;
                r4.x = rect.xMax;
            }
            return new Vector2[] { r1, r2, r3, r4 };
        }
        public override List<Vector2[]> GetScaleLinePoint(Rect rect)
        {
            if (!_ScaleLine)
            {
                return null;
            }

            float avg = ScaleNumAvg(rect.width);

            List<Vector2[]> vector2s = new List<Vector2[]>();

            Vector2 r1 = new Vector2();
            Vector2 r2 = new Vector2();
            Vector2 r3 = new Vector2();
            Vector2 r4 = new Vector2();

            for (int i = 0; i <= _ScaleDisNum+1 ; i++)
            {
                float disNum = avg * i;


                switch (_ScaleLineDirection)
                {
                    case EAxisDirection_X.Top:
                        r1.y = rect.yMax - _ScaleLineHeight - _ScaleLineOffset;
                        r2.y = rect.yMax - _ScaleLineOffset;
                        r3.y = rect.yMax - _ScaleLineOffset;
                        r4.y = rect.yMax - _ScaleLineHeight - _ScaleLineOffset;
                        break;
                    case EAxisDirection_X.Bottom:
                        r1.y = rect.yMin + _ScaleLineOffset;
                        r2.y = rect.yMin + _ScaleLineHeight + _ScaleLineOffset;
                        r3.y = rect.yMin + _ScaleLineHeight + _ScaleLineOffset;
                        r4.y = rect.yMin + _ScaleLineOffset;
                        break;
                    default:
                        break;
                }

                r1.x = rect.xMin + disNum - _ScaleLineWight * .5f;
                r2.x = rect.xMin + disNum - _ScaleLineWight * .5f;
                r3.x = rect.xMin + disNum + _ScaleLineWight * .5f;
                r4.x = rect.xMin + disNum + _ScaleLineWight * .5f;

                vector2s.Add(new Vector2[] { r1, r2, r3, r4 });
            }

            return vector2s;
        }
        public override void ShowScaleText(Rect rect)
        {

        }
    }
}
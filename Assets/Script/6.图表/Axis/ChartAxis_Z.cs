using System;
using System.Collections.Generic;
using UnityEngine;

namespace M_Chart
{

    [Serializable]
    public class ChartAxis_Z : ChartAxis
    {
        public override Vector2[] GetAxisPoint(Rect rect)
        {
            return null;
        }

        public override List<Vector2[]> GetScaleLinePoint(Rect rect)
        {
            return null;
        }
        public override void ShowScaleText(Rect rect)
        {

        }
    }
}
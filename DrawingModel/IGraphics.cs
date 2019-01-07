using System.Collections.Generic;

namespace DrawingModel
{
    public interface IGraphics
    {
        //清空畫面
        void ClearAll();
        //畫線
        void DrawLine(List<double> point1, List<double> point2, bool isChosen);
        //畫菱形
        void DrawDiamond(List<double> point1, List<double> point2, bool isChosen);
        //畫橢圓
        void DrawEllipse(List<double> point1, List<double> point2, bool isChosen);
    }
}
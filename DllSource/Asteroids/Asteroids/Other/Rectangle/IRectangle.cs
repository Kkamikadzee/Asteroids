using KMK.Models.Base;

namespace KMK.Models.Other.Rectangle
{
    public interface IRectangle
    {
        float Width { get; }
        float Height { get; }
        
        Vector3 LeftBottomPoint { get; }
        Vector3 LeftTopPoint { get; }
        Vector3 RightBottomPoint { get; }
        Vector3 RightTopPoint { get; }

        bool InRectangle(Vector3 point);
        bool InRectangle(Transform transform);
    }
}
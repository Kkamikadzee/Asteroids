using KMK.Model.Other.Rectangle;
using UnityEngine;
using Vector3 = KMK.Model.Base.Vector3;

namespace Other
{
    public static class RandomTransform
    {
        public static Vector3 RandomPositionInRectangle2D(Rectangle rectangle, float rectangleMargin)
        {
            return new Vector3(
                Random.Range(rectangle.LeftBottomPoint.X + rectangleMargin, rectangle.RightTopPoint.X - rectangleMargin),
                Random.Range(rectangle.LeftBottomPoint.Y + rectangleMargin, rectangle.RightTopPoint.Y - rectangleMargin),
                0);
        }

        public static Vector3 RandomRotate2D()
        {
            return new Vector3(
                0,
                0,
                Random.Range(0f, 360f));
        }
    }
}
﻿namespace KMK.Model.Other.Rectangle
{
    public interface IScalableRectangle
    {
        float Width { set; }
        float Height { set; }

        void SetScale(float widht, float height);
    }
}
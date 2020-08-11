﻿using KMK.Models.Base;

namespace KMK.Models.Other.Bounce
{
    public interface IBounce
    {
        void Bounce(Vector3 inNormal);
        void Bounce(float x, float y, float z);
    }
}
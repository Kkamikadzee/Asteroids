using KMK.Model.Base;

namespace KMK.Model.Move
{
    public interface IDirectionMover
    {
        Vector3 DirectionMove { get; set; }
    }
}
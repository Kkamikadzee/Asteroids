using KMK.Models.Base;

namespace KMK.Models.Move
{
    public interface IDirectionMover
    {
        Vector3 DirectionMove { get; set; }
    }
}
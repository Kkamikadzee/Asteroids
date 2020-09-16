namespace Controller.UI
{
    public interface IAsteroidsUiControllersStoragePlayerInfo
    {
        IUiViewController ReloadLaser { get; }
        IUiViewController LaserAmmo { get; }
    }
}
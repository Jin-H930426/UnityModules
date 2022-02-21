namespace JHModule
{
    [System.Flags, System.Serializable]
    public enum InputMask : int
    {
        Player = 0x0001,
        UI = 0x0002,
    }
    public enum RaycastType
    {
        ObjectRay,
        CameraRay
    }

    public struct MouseEvent
    {
        public bool ClickStatus;
        public UnityEngine.Ray MouseRay;
        
    }
}

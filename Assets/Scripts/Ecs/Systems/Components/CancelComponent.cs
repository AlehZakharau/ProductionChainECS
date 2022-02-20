

namespace Ecs.Systems.Components
{
    public enum ECancelMessage
    {
        SenderNull,
        Cancel,
        Wrong,
        Busy
    }
    public struct CancelComponent
    {
        public ECancelMessage Message;
    }
}
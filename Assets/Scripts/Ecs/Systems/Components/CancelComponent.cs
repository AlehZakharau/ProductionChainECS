

namespace Ecs.Systems.Components
{
    public enum ECancelMessage
    {
        Cancel,
        Wrong,
        Busy
    }
    public struct CancelComponent
    {
        public ECancelMessage Message;
    }
}
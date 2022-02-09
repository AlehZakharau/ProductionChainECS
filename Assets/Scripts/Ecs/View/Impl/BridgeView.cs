using UnityEngine;

namespace Ecs.View.Impl
{
    public class BridgeView : LinkView
    {
        [SerializeField] private GameObject connection;
        
        public void SetConnection(Vector3 senderPosition ,Vector3 receiverPosition)
        {
            var target = receiverPosition - senderPosition;
            connection.transform.position = senderPosition + 0.5f * (target);
            //target.Normalize();
            //var targetAngle = Mathf.Atan2(ReceiverPosition.y, ReceiverPosition.x) * Mathf.Rad2Deg;
            //connection.transform.Rotate(Vector3.forward, targetAngle);
            connection.transform.LookAt(receiverPosition);
            var distance = Vector3.Distance(senderPosition, receiverPosition);
            connection.transform.localScale = new Vector3(0.3f, 0.3f, distance);
        }
    }
}
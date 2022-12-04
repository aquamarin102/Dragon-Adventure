using UnityEngine.Playables;

namespace Tool.PushNotifications
{
    internal interface INotificationScheduler
    {
        void ScheduleNotification(NotificationData notificationData);
    }
}
using ImGuiNET;
using System.Numerics;

namespace Stalker2Control.Render
{
    public class NotificationRenderer
    {
        private string _notificationMessage = string.Empty;
        private NotificationType _notificationType;
        private DateTime _notificationStartTime;
        private const float AutoCloseSeconds = 5f;
        private const float AnimationDuration = 0.3f;

        public void RenderNotification()
        {
            if (string.IsNullOrEmpty(_notificationMessage)) return;

            // Auto-close mechanism
            if ((DateTime.Now - _notificationStartTime).TotalSeconds > AutoCloseSeconds)
            {
                _notificationMessage = string.Empty;
                return;
            }

            // Calculate animation progress
            float animationProgress = Math.Min(1f, (float)(DateTime.Now - _notificationStartTime).TotalSeconds / AnimationDuration);

            // Smooth animation
            Vector2 windowPos = new Vector2(10, 10);
            float slideOffset = 100f * (1f - animationProgress);
            ImGui.SetNextWindowPos(new Vector2(windowPos.X, windowPos.Y + slideOffset), ImGuiCond.Always);

            // Dynamic sizing and styling
            ImGui.SetNextWindowSize(new Vector2(400, 80));
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, animationProgress);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 10f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 1f);

            ImGui.PushStyleColor(ImGuiCol.WindowBg, GetNotificationColor());
            ImGui.PushStyleColor(ImGuiCol.Border, GetBorderColor());

            // Push button and separator colors
            ImGui.PushStyleColor(ImGuiCol.Button, GetButtonColor());
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, GetButtonHoverColor());
            ImGui.PushStyleColor(ImGuiCol.Separator, GetSeparatorColor());

            ImGui.Begin("Notification", ImGuiWindowFlags.NoTitleBar |
                                        ImGuiWindowFlags.NoResize |
                                        ImGuiWindowFlags.NoMove |
                                        ImGuiWindowFlags.NoScrollbar);

            // Icon and message layout
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + 10);
            ImGui.AlignTextToFramePadding();

            RenderNotificationIcon();

            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + 10);
            ImGui.TextWrapped(_notificationMessage);

            // Close buttons
            ImGui.SetCursorPosY(ImGui.GetWindowHeight() - 35);
            ImGui.Separator();

            ImGui.SetCursorPosX(ImGui.GetWindowWidth() - 100);
            if (ImGui.Button("OK", new Vector2(90, 25)))
            {
                _notificationMessage = string.Empty;
            }

            ImGui.End();

            // Cleanup style modifications
            ImGui.PopStyleColor(5);
            ImGui.PopStyleVar(3);
        }

        private void RenderNotificationIcon()
        {
            switch (_notificationType)
            {
                case NotificationType.Error:
                    ImGui.Button("[Error]");
                    break;
                case NotificationType.Info:
                    ImGui.Button("[Info]");
                    break;
                case NotificationType.Success:
                    ImGui.Button("[Success]");
                    break;
            }
        }

        private uint GetNotificationColor()
        {
            return _notificationType switch
            {
                NotificationType.Error => ImGui.ColorConvertFloat4ToU32(new Vector4(0.7f, 0.2f, 0.2f, 0.9f)),
                NotificationType.Info => ImGui.ColorConvertFloat4ToU32(new Vector4(0.2f, 0.4f, 0.8f, 0.9f)),
                NotificationType.Success => ImGui.ColorConvertFloat4ToU32(new Vector4(0.2f, 0.7f, 0.3f, 0.9f)),
                _ => ImGui.ColorConvertFloat4ToU32(new Vector4(0.5f, 0.5f, 0.5f, 0.9f)),
            };
        }

        private uint GetBorderColor()
        {
            return _notificationType switch
            {
                NotificationType.Error => ImGui.ColorConvertFloat4ToU32(new Vector4(1f, 0.3f, 0.3f, 1f)),
                NotificationType.Info => ImGui.ColorConvertFloat4ToU32(new Vector4(0.3f, 0.5f, 0.9f, 1f)),
                NotificationType.Success => ImGui.ColorConvertFloat4ToU32(new Vector4(0.3f, 0.8f, 0.4f, 1f)),
                _ => ImGui.ColorConvertFloat4ToU32(new Vector4(0.6f, 0.6f, 0.6f, 1f)),
            };
        }

        private uint GetButtonColor()
        {
            return _notificationType switch
            {
                NotificationType.Error => ImGui.ColorConvertFloat4ToU32(new Vector4(0.9f, 0.3f, 0.3f, 1f)),
                NotificationType.Info => ImGui.ColorConvertFloat4ToU32(new Vector4(0.3f, 0.5f, 0.9f, 1f)),
                NotificationType.Success => ImGui.ColorConvertFloat4ToU32(new Vector4(0.3f, 0.8f, 0.4f, 1f)),
                _ => ImGui.ColorConvertFloat4ToU32(new Vector4(0.6f, 0.6f, 0.6f, 1f)),
            };
        }

        private uint GetButtonHoverColor()
        {
            return _notificationType switch
            {
                NotificationType.Error => ImGui.ColorConvertFloat4ToU32(new Vector4(1f, 0.4f, 0.4f, 1f)),
                NotificationType.Info => ImGui.ColorConvertFloat4ToU32(new Vector4(0.4f, 0.6f, 1f, 1f)),
                NotificationType.Success => ImGui.ColorConvertFloat4ToU32(new Vector4(0.4f, 0.9f, 0.5f, 1f)),
                _ => ImGui.ColorConvertFloat4ToU32(new Vector4(0.7f, 0.7f, 0.7f, 1f)),
            };
        }

        private uint GetSeparatorColor()
        {
            return _notificationType switch
            {
                NotificationType.Error => ImGui.ColorConvertFloat4ToU32(new Vector4(1f, 0.3f, 0.3f, 0.7f)),
                NotificationType.Info => ImGui.ColorConvertFloat4ToU32(new Vector4(0.3f, 0.5f, 0.9f, 0.7f)),
                NotificationType.Success => ImGui.ColorConvertFloat4ToU32(new Vector4(0.3f, 0.8f, 0.4f, 0.7f)),
                _ => ImGui.ColorConvertFloat4ToU32(new Vector4(0.6f, 0.6f, 0.6f, 0.7f)),
            };
        }


        public void ShowNotification(string message, NotificationType type)
        {
            _notificationMessage = message;
            _notificationType = type;
            _notificationStartTime = DateTime.Now;
        }

        public enum NotificationType
        {
            Error,
            Info,
            Success
        }
    }
}
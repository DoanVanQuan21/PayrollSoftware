using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace InnoSoft.Core.Models.TaskManagement
{
    public partial class ActivityLog : BindableBase
    {
        private long activityLogId;
        private string? action;
        private string? fromStatus;
        private string? toStatus;
        private DateTime? updatedDate;
        private long taskId;
        private int userId;

        public long ActivityLogId { get => activityLogId; set => SetProperty(ref activityLogId,value); }
        public string? Action { get => action; set => SetProperty(ref action, value); }
        public string? FromStatus { get => fromStatus; set => SetProperty(ref fromStatus, value); }
        public string? ToStatus { get => toStatus; set => SetProperty(ref toStatus, value); }
        public DateTime? UpdatedDate { get => updatedDate; set => SetProperty(ref updatedDate, value); }
        public long TaskId { get => taskId; set => SetProperty(ref taskId, value); }
        public int UserId { get => userId; set => SetProperty(ref userId, value); }

        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

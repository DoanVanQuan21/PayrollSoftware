using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class Comment : BindableBase
    {
        private long commentId;
        private long? commentCode;
        private string? commentContent;
        private DateTime? createdDate;
        private int userId;
        private long taskId;
        private int projectId;

        public long CommentId { get => commentId; set => SetProperty(ref commentId,value); }
        public long? CommentCode { get => commentCode; set => SetProperty(ref commentCode, value); }
        public string? CommentContent { get => commentContent; set => SetProperty(ref commentContent, value); }
        public DateTime? CreatedDate { get => createdDate; set =>   SetProperty(ref createdDate, value); }
        public int UserId { get => userId; set => SetProperty(ref userId, value); }
        public long TaskId { get => taskId; set => SetProperty(ref taskId, value); }
        public int ProjectId { get => projectId; set => SetProperty(ref projectId, value); }

        public virtual Project Project { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

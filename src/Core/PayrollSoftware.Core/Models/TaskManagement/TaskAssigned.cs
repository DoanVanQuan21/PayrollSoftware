using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class TaskAssigned : BindableBase
    {
        private int userId;
        private long taskId;
        private DateTime? createdDate;
        private DateTime? startDate;
        private DateTime? completionDate;
        private DateTime? status;
        private string? rate;
        private string? comment;
        private long? taskParent;

        public int UserId { get => userId; set => SetProperty(ref userId,value); }
        public long TaskId { get => taskId; set => SetProperty(ref taskId,value); }
        public DateTime? CreatedDate { get => createdDate; set => SetProperty(ref createdDate, value); }
        public DateTime? StartDate { get => startDate; set => SetProperty(ref startDate, value); }
        public DateTime? CompletionDate { get => completionDate; set => SetProperty(ref completionDate, value); }
        public DateTime? Status { get => status; set => SetProperty(ref status, value); }
        public string? Rate { get => rate; set =>   SetProperty(ref rate, value); }
        public string? Comment { get => comment; set => SetProperty(ref comment, value); }
        public long? TaskParent { get => taskParent; set => SetProperty(ref taskParent, value); }
    }
}

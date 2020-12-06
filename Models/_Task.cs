using System;

namespace Task_Manager.Models
{
    public class _Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Description  { get; set; }
        public DateTime  CreatedOn  { get; set; }
        public DateTime CompletedOn  { get; set; }
        public DateTime RejectedOn  { get; set; }
        public string RejectedReason  { get; set; }
        public string AssignedToUser  { get; set; }
        public _TaskStatus Status { get; set; }



    }
}
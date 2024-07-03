namespace Management.Core.Models.Common
{
    public class Gender
    {
        public string? Title { get; set; }
        public bool Value { get; set; }
        public Gender(string title,bool value)
        {
           Title = title;
           Value = value;
        }
    }
}
namespace TaskManager.BL.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public uint NumberOfUnresolvedTasks { get; set; }
    }
}

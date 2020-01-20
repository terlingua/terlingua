namespace API.BL
{
    public class ItemApiModel
    {
        public ItemApiModel() { }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectManager { get; set; }
        public string ProjectManagerNote { get; set; }
    }
}
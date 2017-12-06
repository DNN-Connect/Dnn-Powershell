namespace Connect.DNN.Powershell.Core.Models
{
   public class PageModelBase
    {
        public int TabId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public string Skin { get; set; }
        public string Path { get; set; }
        public bool IncludeInMenu { get; set; }
        public bool IsDeleted { get; set; }
    }
}

namespace Connect.DNN.Powershell.Core.Models
{
    public class ModuleInstanceModel
    {
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Pane { get; set; }
        public string ModuleName { get; set; }
        public string FriendlyName { get; set; }
        public int ModuleDefId { get; set; }
        public int TabModuleId { get; set; }
        public bool IsDeleted { get; set; }
        public int TabId { get; set; }
    }
}

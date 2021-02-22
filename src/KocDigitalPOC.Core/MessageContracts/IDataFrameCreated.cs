namespace KocDigitalPOC.Core.MessageContracts
{
    public interface IDataFrameCreated
    {
        public string LocationId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
namespace C02_ASPNet.Controllers.Services
{
    public class GetGuidService : IGetGuid
    {
        private string _myId; 
        public string MyId { get { return _myId; } }

        public GetGuidService()
        {
            _myId = Guid.NewGuid().ToString();
        }
        public string GetMyId()
        {
            return _myId;
        }
    }
}

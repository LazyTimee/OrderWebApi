using OrderWebApi.Etities;

namespace OrderWebApi.Services
{
    public interface iServiceProc
    {
        public void Process(string orderDetail, AppContext context);

    }
}

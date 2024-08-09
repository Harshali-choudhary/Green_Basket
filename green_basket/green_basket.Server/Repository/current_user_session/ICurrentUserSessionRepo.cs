using green_basket.Server.Entities;

namespace green_basket.Server.Repository.current_user_session
{
    public interface ICurrentUserSessionRepo
    {
        Task<List<Current_User_Session>> getAll();
        Task<bool> Insert(Current_User_Session session);
        Task<bool> Update(Current_User_Session session);
        Task<bool> Delete(int Cid);

    }
}

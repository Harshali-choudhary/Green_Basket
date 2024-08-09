using green_basket.Server.Entities;
using green_basket.Server.Repository.current_user_session;

namespace green_basket.Server.Service.CurrentUserSessionService
{
    public class CurrentUserSessionService : ICurrentUserSession
    {
        private readonly ICurrentUserSessionRepo repo;

        public CurrentUserSessionService(ICurrentUserSessionRepo _repo)
        {
            repo = _repo;
        }

        public async Task<List<Current_User_Session>> getAll() => await repo.getAll();

        public async Task<bool> Insert(Current_User_Session user_Session) => await repo.Insert(user_Session);

        public async Task<bool> Update(Current_User_Session user_Session) => await repo.Update(user_Session);

        public async Task<bool> Delete(int Cid) => await repo.Delete(Cid); 
    }
}

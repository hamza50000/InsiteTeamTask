using InsiteTeamTask.Data.Models;
using System.Collections.Generic;

namespace InsiteTeamTask.Data.Providers
{
    public interface IDataProvider
    {
        IEnumerable<Game> GetGames();

        IEnumerable<Member> GetMembers();

        IEnumerable<Product> GetProducts();

        IEnumerable<Season> GetSeasons();

        IEnumerable<Ticket> GetTickets();
    }
}

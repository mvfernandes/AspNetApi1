using System;
using System.Collections.Generic;
using Aula.Api.Models;

namespace Aula.Api.Repositories
{
    public interface IFundoCapitalRepository
    {
        void AddFundo(FundoCapital fundo);
        void UpdateFundo(FundoCapital fundo);
        IEnumerable<FundoCapital> ListarFundos();
        FundoCapital GetById(Guid id);
        void DelFundo(FundoCapital fundo);
    }
}
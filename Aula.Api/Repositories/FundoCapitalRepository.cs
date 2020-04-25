using System;
using System.Collections.Generic;
using System.Linq;
using Aula.Api.Models;

namespace Aula.Api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void AddFundo(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void DelFundo(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }

        public FundoCapital GetById(Guid id)
        {
            return _storage.FirstOrDefault(repo => repo.Id == id);
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _storage;
        }

        public void UpdateFundo(FundoCapital fundo)
        {
            var index = _storage.FindIndex(0, 1, repo => repo.Id == fundo.Id);
            _storage[index] = fundo;
        }
    }
}
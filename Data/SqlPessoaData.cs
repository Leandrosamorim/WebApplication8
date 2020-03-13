using System.Collections.Generic;
using WebApplication8.Models;
using System.Linq;

namespace WebApplication8.Data
{
    public class SqlPessoaData : IPessoaData
    {
        private readonly WebApplication8DbContext db;

        public SqlPessoaData(WebApplication8DbContext db)
        {
            this.db = db;
        }
        public Pessoa Add(Pessoa novaPessoa)
        {
            db.Add(novaPessoa);
            Commit();
            return novaPessoa;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Pessoa Delete(int id)
        {
            var pessoa = GetById(id);
            if (pessoa != null)
            {
                db.Pessoas.Remove(pessoa);
                Commit();
            }
            return pessoa;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Pessoa GetById(int id)
        {
            return db.Pessoas.Find(id);
        }

        public int GetCountPple()
        {
            return db.Pessoas.Count();
        }

        public IEnumerable<Pessoa> GetPessoaByName(string SearchTerm)
        {
            var query = from p in db.Pessoas
                        where p.Nome.StartsWith(SearchTerm) || string.IsNullOrEmpty(SearchTerm)
                        orderby p.Nome
                        select p;
            return query;
        }

        public Pessoa Update(Pessoa pessoaUpdated)
        {
            var entity = db.Pessoas.Attach(pessoaUpdated);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Commit();
            return pessoaUpdated;
        }
    }


}


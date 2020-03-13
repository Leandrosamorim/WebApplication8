using System.Collections.Generic;
using System.Text;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public interface IPessoaData
    {
        IEnumerable<Pessoa> GetAll();
        IEnumerable<Pessoa> GetPessoaByName(string SearchTerm);
        Pessoa GetById(int id);
        Pessoa Update(Pessoa pessoaUpdated);
        Pessoa Add(Pessoa novaPessoa);
        Pessoa Delete(int id);
        int Commit();
        int GetCountPple();
    }


    }


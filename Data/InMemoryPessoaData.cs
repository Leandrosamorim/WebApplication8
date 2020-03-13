using System;
using System.Collections.Generic;
using WebApplication8.Models;
using System.Linq;

namespace WebApplication8.Data
{
    public class InMemoryPessoaData : IPessoaData
    {
        readonly List<Pessoa> pessoas;
        public InMemoryPessoaData()
        {
            pessoas = new List<Pessoa>()
            {
                new Pessoa{Id = 1, Nome = "Leandro", Sobrenome = "Amorim", Aniversario = Convert.ToDateTime("15/01/1990")},
                new Pessoa{Id = 2, Nome = "AA", Sobrenome = "SS", Aniversario = Convert.ToDateTime("15/01/1990")}
            };
    }
        public Pessoa GetById(int id)
        {
            return pessoas.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return from p in pessoas
                   orderby p.Nome
                   select p;
        }

        public IEnumerable<Pessoa> GetPessoaByName(string nome = null)
        {
            return from p in pessoas
                   where string.IsNullOrEmpty(nome) || p.Nome.StartsWith(nome)
                   orderby p.Nome
                   select p;
        }

        public Pessoa Update(Pessoa pessoaUpdated)
        {
            var pessoa = pessoas.SingleOrDefault(x => x.Id == pessoaUpdated.Id);
            if (pessoa != null)
            {
                pessoa.Nome = pessoaUpdated.Nome;
                pessoa.Sobrenome = pessoaUpdated.Sobrenome;
                pessoa.Aniversario = pessoaUpdated.Aniversario;
            }
            else
            {
                pessoa.Id = 3;
                pessoa.Nome = pessoaUpdated.Nome;
                pessoa.Sobrenome = pessoaUpdated.Sobrenome;
                pessoa.Aniversario = pessoaUpdated.Aniversario;
            }
            return pessoa;
        }

        public Pessoa Add(Pessoa novaPessoa)
        {
            pessoas.Add(novaPessoa);
            novaPessoa.Id = pessoas.Max(r => r.Id) + 1;
            return novaPessoa;
        }

        public Pessoa Delete(int id)
        {
            var pessoa = pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa != null)
            {
                pessoas.Remove(pessoa);
            }
            return pessoa;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public int GetCountPple()
        {
            return pessoas.Count();
        }
    }
        
    }


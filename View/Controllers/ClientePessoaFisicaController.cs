using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ClientePessoaFisicaController : Controller
    {
        // GET: ClientePessoaFisica
        public ActionResult Index(string pesquisa)
        {
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            List<ClientePessoaFisica> clientesPessoaFisica = repository.ObterTodos(pesquisa);
            ViewBag.ClientesPessoaFisica = clientesPessoaFisica;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, string cpf, DateTime dataNascimento, string rg, string sexo)
        {
            ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
            clientePessoaFisica.Nome = nome;
            clientePessoaFisica.CPF = cpf;
            clientePessoaFisica.DataNascimento = dataNascimento;
            clientePessoaFisica.RG = rg;
            clientePessoaFisica.Sexo = sexo;
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            repository.Inserir(clientePessoaFisica);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            ClientePessoaFisica clientePessoaFisica = repository.ObterPeloId(id);
            ViewBag.ClientePessoaFisica = clientePessoaFisica;
            return View();
        }

        public ActionResult Update(int id, string nome, string cpf, DateTime dataNascimento, string rg, string sexo)
        {
            ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
            clientePessoaFisica.Id = id;
            clientePessoaFisica.Nome = nome;
            clientePessoaFisica.CPF = cpf;
            clientePessoaFisica.DataNascimento = dataNascimento;
            clientePessoaFisica.RG = rg;
            clientePessoaFisica.Sexo = sexo;
            ClientePessoaFisicaRepository repository = new ClientePessoaFisicaRepository();
            repository.Update(clientePessoaFisica);
            return RedirectToAction("Index");
        }
    }
}
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ClientePessoaJuridicaController : Controller
    {
        // GET: ClientePessoaJuridica
        public ActionResult Index(string pesquisa)
        {
            ClientePessoaJuridicaRepository repository = new ClientePessoaJuridicaRepository();
            List<ClientePessoaJuridica> clientesPessoaJuridica = repository.ObterTodos(pesquisa);
            ViewBag.ClientesPessoaJuridica = clientesPessoaJuridica;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string cnpj, string razaoSocial, string inscricaoEstadual)
        {
            ClientePessoaJuridica clientePessoaJuridica = new ClientePessoaJuridica();
            clientePessoaJuridica.CNPJ = cnpj;
            clientePessoaJuridica.RazaoSocial = razaoSocial;
            clientePessoaJuridica.InscricaoEstadual = inscricaoEstadual;
            ClientePessoaJuridicaRepository repository = new ClientePessoaJuridicaRepository();
            repository.Inserir(clientePessoaJuridica);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ClientePessoaJuridicaRepository repository = new ClientePessoaJuridicaRepository();
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ClientePessoaJuridicaRepository repository = new ClientePessoaJuridicaRepository();
            ClientePessoaJuridica clientePessoaJuridica = repository.ObterPeloId(id);
            ViewBag.ClientePessoaJuridica = clientePessoaJuridica;
            return View();
        }

        public ActionResult Update(int id, string cnpj, string razaoSocial, string inscricaoEstadual)
        {
            ClientePessoaJuridica clientePessoaJuridica = new ClientePessoaJuridica();
            clientePessoaJuridica.Id = id;
            clientePessoaJuridica.CNPJ = cnpj;
            clientePessoaJuridica.RazaoSocial = razaoSocial;
            clientePessoaJuridica.InscricaoEstadual = inscricaoEstadual;
            ClientePessoaJuridicaRepository repository = new ClientePessoaJuridicaRepository();
            repository.Update(clientePessoaJuridica);
            return RedirectToAction("Index");
        }
    }
}
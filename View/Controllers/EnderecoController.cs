using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco
        public ActionResult Index(string pesquisa)
        {
            EnderecoRepository repository = new EnderecoRepository();
            List<Endereco> enderecos = repository.ObterTodos(pesquisa);
            ViewBag.Enderecos = enderecos;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string unidadeFederativa, string cidade, string lougradouro, string cep, int numero, string complemento)
        {
            Endereco endereco = new Endereco();
            endereco.UnidadeFederativa = unidadeFederativa;
            endereco.Cidade = cidade;
            endereco.Logradouro = lougradouro;
            endereco.CEP = cep;
            endereco.Numero = numero;
            endereco.Complemento = complemento;
            EnderecoRepository repository = new EnderecoRepository();
            repository.Inserir(endereco);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            EnderecoRepository repository = new EnderecoRepository();
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            EnderecoRepository repository = new EnderecoRepository();
            Endereco endereco = repository.ObterPeloId(id);
            ViewBag.Endereco = endereco;
            return View();
            
        }

        public ActionResult Update(int id, string unidadeFederativa, string cidade, string lougradouro, string cep, int numero, string complemento)
        {
            Endereco endereco = new Endereco();
            endereco.Id = id;
            endereco.UnidadeFederativa = unidadeFederativa;
            endereco.Cidade = cidade;
            endereco.Logradouro = lougradouro;
            endereco.CEP = cep;
            endereco.Numero = numero;
            endereco.Complemento = complemento;
            EnderecoRepository repository = new EnderecoRepository();
            repository.Update(endereco);
            return RedirectToAction("Index");
        }
    }
}
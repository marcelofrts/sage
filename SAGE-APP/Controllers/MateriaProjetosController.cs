using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAGE_APP.Models;

namespace SAGE_APP.Controllers
{
    public class MateriaProjetosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MateriaProjetos
        //public ActionResult Index()
        //{
        //    return View(db.Materias.ToList());
        //}

        // GET: MateriaProjetos
        public ActionResult Index(string nomeProjeto)
        {
            string userName = null;
            int userId = 0;
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
                var usuariosLogado = db.Usuarios.Single(u => u.UserEmail.Equals(userName));
                userId = usuariosLogado.UserId;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Projeto = nomeProjeto;
            var mat = db.MateriasProjetos.Select(m => m.MateriaId).ToList();
            var matPro = db.Materias.Select(mm => mm.Descricao).ToList();
            try
            {
                var listMP = new List<Tuple<int, string>>();
                var id = db.Projetos.Single(p => p.Descricao.Equals(nomeProjeto) && p.UserId == userId);
                ViewBag.ProjetoId = id.ProjetoId;
                var projetos = db.MateriasProjetos.Where(p => p.ProjetoId.Equals(id.ProjetoId)).ToArray();
                List<String> materiasProjeto = new List<string>();
                foreach (var item in projetos)
                {
                    var materiaDesc = db.Materias.Where(m => m.UserId == userId && m.MateriaId == item.MateriaId).Select(s => s.Descricao).ToList();
                    var materiaId = db.Materias.Where(m => m.UserId == userId && m.MateriaId == item.MateriaId).Select(s => s.MateriaId).ToList();
                    materiasProjeto.Add(materiaDesc[0]);
                    listMP.Add(Tuple.Create(materiaId[0], materiaDesc[0]));
                }
                //ViewBag.MateriasProjetos = materiasProjeto;
                ViewBag.MateriasProjetos = listMP;
            }
            catch (Exception)
            {
                //ViewBag.MateriasProjetos = new List<string>();
                ViewBag.MateriasProjetos = new List<Tuple<int, string>>();
            }

            //IList<SelectListItem> items = new List<SelectListItem>();
            //foreach (var item in matPro)
            //{
            //    items.Add(new SelectListItem { Text = item });
            //}
            ViewBag.Materias = new SelectList(db.Materias, "MateriaId", "Descricao"); ;
            //matPro = matPro.Contains(mat);
            return View(db.MateriasProjetos.ToList());
        }


        // GET: MateriaProjetos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaProjeto materiaProjeto = db.MateriasProjetos.Find(id);
            if (materiaProjeto == null)
            {
                return HttpNotFound();
            }
            return View(materiaProjeto);
        }

        // GET: MateriaProjetos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriaProjetos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MateriaProjetoId,ProjetoId,MateriaId")] MateriaProjeto materiaProjeto)
        {
            if (ModelState.IsValid)
            {
                db.MateriasProjetos.Add(materiaProjeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materiaProjeto);
        }

        // GET: MateriaProjetos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaProjeto materiaProjeto = db.MateriasProjetos.Find(id);
            if (materiaProjeto == null)
            {
                return HttpNotFound();
            }
            return View(materiaProjeto);
        }

        // POST: MateriaProjetos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MateriaProjetoId,ProjetoId,MateriaId")] MateriaProjeto materiaProjeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiaProjeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materiaProjeto);
        }

        // GET: MateriaProjetos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var materiaProjeto = db.MateriasProjetos.Single(m => m.MateriaId == id);
            if (materiaProjeto == null)
            {
                return HttpNotFound();
            }
            return View(materiaProjeto);
        }

        // POST: MateriaProjetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            MateriaProjeto materiaProjeto = db.MateriasProjetos.Single(m => m.MateriaId == id);
            db.MateriasProjetos.Remove(materiaProjeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddMateria(int materia, int projeto)
        {
            if (ModelState.IsValid)
            {
                MateriaProjeto materiaProjeto = new MateriaProjeto
                {
                    MateriaId = materia,
                    ProjetoId = projeto
                };
                db.MateriasProjetos.Add(materiaProjeto);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

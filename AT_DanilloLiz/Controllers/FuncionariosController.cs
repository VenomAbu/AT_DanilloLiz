using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT_DanilloLiz.DAL;
using AT_DanilloLiz.Models;
using Microsoft.AspNetCore.Authorization;

namespace AT_DanilloLiz.Controllers
{
    [Authorize]
    public class FuncionariosController : Controller
    {
        private readonly InfnetDbContext _context;

        public FuncionariosController(InfnetDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios

        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var funcionarios = from m in _context.Funcionarios.Include(f => f.Departamento).Include(f => f.Endereco) select m;


            if (!String.IsNullOrEmpty(searchString))
            {
                funcionarios = funcionarios.Where(s => s.Nome!.Contains(searchString));
            }

            return View(await funcionarios.ToListAsync());
            // return View(await contexto.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Departamento)
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Local");
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Cidade");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Telefone,Email,DataDeNascimento,EnderecoId,DepartamentoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Local", funcionario.DepartamentoId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Cidade", funcionario.EnderecoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Local", funcionario.DepartamentoId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Cidade", funcionario.EnderecoId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Telefone,Email,DataDeNascimento,EnderecoId,DepartamentoId")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Local", funcionario.DepartamentoId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Cidade", funcionario.EnderecoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Departamento)
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioId == id);
        }
    }
}

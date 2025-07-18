using FirstMvc.Data;
using FirstMvc.Models;
using FirstMvc.Models.DTOs.Todo;
using FirstMvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers;

public class TodoController(AppDbContext context) : Controller
{
    public IActionResult Index(int? id) => View(new TodoViewModel
    {
        TodoId = id,
        Todos = context.Todos.ToList()
    });
    
    [HttpPost]
    public IActionResult Index(TodoAddDto model)
    {
        // mvc kullanıyorsanız validasyonu elle yapcaksınız
        // if (!ModelState.IsValid)
        // {
        //     TempData["ErrorMsg"] = "Eksik veya hatalı giriş yaptınız.";
        //     // eğer sayfam index olmasaydı mutlaka redirect yapcaktım
        //     // ama sayfam index olduğu için aslında burada verileri basıp devam edebilirim
        //     return RedirectToAction(nameof(Index));
        // }

        if (ModelState.IsValid)
        {
            var newTodo = new Todo { Task = model.Task };
            context.Todos.Add(newTodo);
            context.SaveChanges();
        }
        else
        {
            TempData["ErrorMsg"] = "Eksik veya hatalı giriş yaptınız.";
        }
        
        return View(new TodoViewModel{ Todos = context.Todos.ToList() });
    }

    public IActionResult Remove(int id)
    {
        if (context.Todos.Find(id) is Todo todo)
        {
            context.Todos.Remove(todo);
            context.SaveChanges();
        }
        else
        {
            TempData["ErrorMsg"] = "Bu todo yok ki";
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult MarkComplete(int id)
    {
        if (context.Todos.Find(id) is Todo todo)
        {
            todo.Completed = true;
            context.SaveChanges();
        }
        else
        {
            TempData["ErrorMsg"] = "Bu todo yok ki";
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult MarkIncomplete(int id)
    {
        if (context.Todos.Find(id) is Todo todo)
        {
            todo.Completed = false;
            context.SaveChanges();
        }
        else
        {
            TempData["ErrorMsg"] = "Bu todo yok ki";
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Update(int id, TodoAddDto model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Msg"] = "Eksik bilgi var.";
            return View("Error");
        }
        
        if (context.Todos.Find(id) is not Todo todo)
        {
            ViewData["Msg"] = "Bu todo bulunamadı.";
            return View("Error");
        }
        
        todo.Task = model.Task;
        context.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}
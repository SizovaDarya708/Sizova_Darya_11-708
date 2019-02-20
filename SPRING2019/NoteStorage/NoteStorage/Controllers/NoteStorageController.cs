using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NoteStorage.Controllers
{
    public class NoteStorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SavedNote(string name, string text)
        {
            ViewData["Name"] = name;
            ViewData["Text"] = text;
            string time = DateTime.Now.ToLongTimeString();
            time = time.Replace(":", ".");
            using (FileStream fstream = new FileStream($@"C:\DB\{name + " " + time}.txt", FileMode.OpenOrCreate))
            {
                try
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                }
                catch
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("Файл пуст или был сохранен с ошибкой");
                    fstream.Write(array, 0, array.Length);
                }
            }
            return View();
        }

        public IActionResult GetNotes()
        {
            // вывод всех заметок 
            string[] notes = Directory.GetFiles(@"C:\DB", "*.txt"); // список всех txt файлов в директории C:\DB
            string[] notesName = Directory.GetFiles(@"C:\DB", "*.txt");
            for (int i = 0; i < notes.Length; i++)
            {
                notesName[i] = notesName[i].Remove(0, 6).Remove(notesName[i].Length - 10);
            }
            ViewBag.TotalNotes = notesName;
            ViewBag.path = notes;
            if (notes == null) ViewBag.TotalNotes = "У вас еще нет заметок";
            return View();
        }
        public IActionResult EditNote(string fileName)
        {
            string text;
            string time = DateTime.Now.ToLongTimeString();
            using (StreamReader sr = new StreamReader($@"C:\DB\{fileName}.txt", System.Text.Encoding.Default))
            {
                fileName = fileName.Remove(fileName.Length - 9);
                text = sr.ReadToEnd();
                //fileName += time; 
            }
            ViewData["Text"] = text;
            ViewData["Name"] = fileName;
            return View();
        }

    }
}
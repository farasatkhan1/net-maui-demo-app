using NetMAUIDemoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace NetMAUIDemoApp.Services
{
    public static class NoteService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Note>();
        }

        public static async Task AddNote(string description)
        {
            await Init();
            var note = new Note
            {
                Description = description
            };

            await db.InsertAsync(note);
        }

        public static async Task RemoveNote(int id)
        {
            await Init();
            await db.DeleteAsync<Note>(id);
        }

        public static async Task<IEnumerable<Note>> GetNote()
        {
            await Init();
            var notes = await db.Table<Note>().ToListAsync();

            foreach (var note in notes)
            {
                Console.WriteLine($"Note Id: {note.Id}, Description: {note.Description}");
            }

            return notes;
        }
    }
}

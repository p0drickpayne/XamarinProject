using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinProject.models;

namespace XamarinProject.helpers
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinproject-da3f8.firebaseio.com/");
        
        public async Task<List<Note>> GetAllNotes()  
        {  
  
            return (await firebase  
                .Child("Notes")  
                .OnceAsync<Note>()).Select(item => new Note  
            {  
                TheNote = item.Object.TheNote 
                 
            }).ToList();  
        }
        public async Task AddNote(string note)
        {

            await firebase
                .Child("Notes")
                .PostAsync(new Note() { TheNote = note });
        }
    }
}
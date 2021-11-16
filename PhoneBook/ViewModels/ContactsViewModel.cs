using PhoneBook.Models;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PhoneBook.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged   
    {
        public string SearchText { get; set; }
        //création d'une propriété qui contient la liste, je n'oublie pas get, set.
        public IEnumerable<string> Results { get; set; }
        //dans cette propriété, il y a bertrand maintenant
        private readonly RepositoryService _repositoryService;
        //création du constructeur

        public event PropertyChangedEventHandler PropertyChanged;
        public ContactsViewModel(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
            //à l'intérieur du constructeur, j'instancie cette liste
            //Results = new List<string>() { "Bonjour", "comment", "ça", "va" };
            //sans cette ligne le serachtext est null
            SearchText = "";
        }

        //Je crée une fonction ExecuteLIst() qui appelle la liste du RepositoryService
        public void ExecuteList()
        {
            // c'est pour ça que j'appelle la méthode de Bertrand à la ligne 28. Je dois indiquer le type
            IEnumerable<Entity> results = _repositoryService.List();
            // Comme je récupère une liste d'entity de Bertrand, je dois la convertir en string. 
            Results = results.Select(x => x.ToString());
            PropertyChanged(this, new PropertyChangedEventArgs("Results"));
        }

        public void ExecuteSearch()
        {
            IEnumerable<Entity> results = _repositoryService.Search(SearchText);
            Results = results.Select(x => x.ToString());
            PropertyChanged(this, new PropertyChangedEventArgs("Results"));
           //j'injecte dans la propriété un
            SearchText = "";
            PropertyChanged(this, new PropertyChangedEventArgs("SearchText"));
        }
        
    }
}

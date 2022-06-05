using EF_test_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.ViewModels
{
    public class IsSpeakingViewModel
    {
        //public IsSpeakingViewModel()
        //{
        //    PersLang = new GenericList<int>();
        //}
        //public string Message { get; set; }
        //public GenericList<int> PersLang { get; set; }

        public List<PersonSpeaks> KnownLangueges = new List<PersonSpeaks>();

        //public class GenericList<T>
        //{
        //    public void Add(T input) { }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduConnect.Domain.Entities.Categ;

namespace EduConnect.BusinessLogic.CategBL
{
    public class CategBL
    {
        public List<Categ> GetAllCategs()
        {
            return new List<Categ>
            {
                new Categ {
                    Id = 1, Name = "Literatură",
                    Description = "Atât română cât și cea universală"
                },
                new Categ {
                    Id = 2, Name = "Matematică",
                    Description = "Elemente teoretice împreună cu probleme rezolvate și explicate pe înțelesul tuturor"
                },
                new Categ {
                    Id = 3, Name = "Chimie",
                    Description = "Sfaturi pentru reacții chimice, formule, exerciții și experimente demonstrative"
                },
                new Categ {
                    Id = 4, Name = "Fizică",
                    Description = "Învățare prin experimente, concepte teoretice și aplicații practice discutate detaliat"
                },
                new Categ {
                    Id = 5, Name = "Programare",
                    Description = "Tutoriale pas cu pas, discuții despre erori și recomandări de proiecte practice"
                },
                new Categ {
                    Id = 6, Name = "Istorie",
                    Description = "Analiza evenimentelor istorice, interpretări multiple și resurse pentru aprofundare"
                }
            };
        }
    }
}

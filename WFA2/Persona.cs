using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    //Definición de la clase
    //Clase base
    public class Persona
    {
        private int id;
        private string name;
        protected string lastname;
        protected int size;

        protected struct person
        {
            public int id;
            public string name;
            public string lastname;
            public string address;
        }

        protected static person[] people;

        //constructor
        public Persona()
        {
            id = 0;
            name = "";
            lastname = "";
        }

        //constructor con parametros
        public Persona(int i, string n, string ln)
        {
            id = i;
            name = n;
            lastname = ln;
        }

        //propiedades 
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Address
        {
            get { return lastname; }
            set { lastname = value; }
        }
        
        //funciones 
        protected string CompleteName()
        {
            return name + " " + lastname;
        }

        public void SetSize(int Size)
        {
            size = Size;
            people = new person[Size];
        }

        public void Initdata()
        {
            int i;
            for (i = 0; i < people.Length - 1; i++)
            {
                people[i].id = 0;
                people[i].name = "";
                people[i].lastname = "";
            }
        }

        public bool NewData(Persona person)
        {
            int i;
            for (i = 0; i < people.Length; i++)
            {
                if (people[i].id == 0)
                {
                    break;
                }
            }

            if (i < people.Length)
            {
                people[i].id = person.id;
                people[i].name = person.name;
                people[i].lastname = person.lastname;
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool SeekData(int record)
        {
            int i;
            for (i = 0; i < people.Length; i++)
            {
                if (people[i].id == record)
                {
                    break;
                }
            }

            if (i < people.Length)
            {
                id = people[i].id;
                name  = people[i].name;
                lastname = people[i].lastname;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModifyData(Persona person, int record)
        {
            int i;
            for (i = 0; i < people.Length; i++)
            {
                if (people[i].id == record)
                {
                    break;
                }
            }

            if (i < people.Length)
            {
                people[i].id = person.id;
                people[i].name = person.name;
                people[i].lastname = person.lastname;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int record)
        {
            int i;
            for (i = 0; i < people.Length; i++)
            {
                if (people[i].id == record)
                {
                    break;
                }
            }

            if (i < people.Length)
            {
                people[i].id = 0;
                people[i].name = "";
                people[i].lastname = "";
                return true;
            }
            else
            {
                return false;
            }
        }

        //Destructor
        ~Persona()
        {
            //limpieza
        }
    }

    // Clase con simulacion de Amiga.
    public class PersonaAmiga
    {
        internal string CompleteName()
        {
            return "Soy, Fabio Ruiz";
        }      

    }

    //Clase deribada
    public class PersonaHeredada : Persona
    {
        public string direccion = "";

        internal string CompleteName()
        {
            return "Aquí, Enrique " + lastname;
        }

        public bool DeleteData(int record)
        {
            int i;
            for (i = 0; i < people.Length; i++)
            {
                if (people[i].id == record)
                {
                    break;
                }
            }

            if (i < people.Length)
            {
                people[i].id = 0;
                people[i].name = "";
                people[i].lastname = "";
                return true;
            }
            else
            {
                return false;
            }
        }




    }



}

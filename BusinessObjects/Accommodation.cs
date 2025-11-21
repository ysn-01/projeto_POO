using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreatProblems;
using Validations;

namespace BusinessObjects
{
    /// <summary>
    /// Representa um alojamento genérico com propriedades comuns a diferentes tipos de alojamento.
    /// Classe abstrata que serve como base para outros tipos de alojamento.
    /// </summary>
    [Serializable]
    public abstract class Accommodation
    {
        private int id;
        private static int idCount = 1;
        private string name;
        private string location;
        private double pricePerNight;
        private bool available;

        /// <summary>
        /// Construtor padrão da classe <c>Accommodation</c>.
        /// </summary>
        public Accommodation()
        {
        }

        /// <summary>
        /// Construtor que inicializa um alojamento com os atributos especificados.
        /// </summary>
        /// <param name="name">Nome do alojamento.</param>
        /// <param name="location">Localização do alojamento.</param>
        /// <param name="pricePerNight">Preço por noite do alojamento.</param>
        public Accommodation(string name, string location, double pricePerNight)
        {
            Id = IdCount++;
            Name = name;
            Location = location;
            PricePerNight = pricePerNight;
            Available = true;
        }

        /// <summary>
        /// Obtém ou define o ID único do alojamento.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Obtém ou define o contador estático de IDs únicos.
        /// Este contador é incrementado automaticamente ao criar um novo alojamento.
        /// </summary>
        public static int IdCount
        {
            get { return idCount; }
            set { idCount = value; }
        }

        /// <summary>
        /// Obtém ou define o nome do alojamento.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Obtém ou define a localização do alojamento.
        /// </summary>
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Obtém ou define o preço por noite do alojamento.
        /// </summary>
        public double PricePerNight
        {
            get { return pricePerNight; }
            set { pricePerNight = value; }
        }

        /// <summary>
        /// Obtém ou define a disponibilidade do alojamento.
        /// </summary>
        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
    }
}

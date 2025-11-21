using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using TreatProblems;
using Validations;

namespace BusinessObjects
{
    /// <summary>
    /// Representa uma versão simplificada de uma casa, com atributos básicos.
    /// </summary>
    public class HouseLight
    {
        private int id;
        private string name;
        private string location;
        private double pricePerNight;

        /// <summary>
        /// Construtor padrão da classe <c>HouseLight</c>.
        /// </summary>
        public HouseLight()
        {

        }

        /// <summary>
        /// Construtor que inicializa uma casa simples com os atributos especificados.
        /// </summary>
        /// <param name="name">Nome da casa.</param>
        /// <param name="location">Localização da casa.</param>
        /// <param name="pricePerNight">Preço por noite da casa.</param>
        public HouseLight(string name, string location, double pricePerNight)
        {
            Name = name;
            Location = location;
            PricePerNight = pricePerNight;
        }

        /// <summary>
        /// Obtém ou define o ID único da casa simples.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Obtém ou define o nome da casa simples.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Obtém ou define a localização da casa simples.
        /// </summary>
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Obtém ou define o preço por noite da casa simples.
        /// </summary>
        public double PricePerNight
        {
            get { return pricePerNight; }
            set { pricePerNight = value; }
        }

        /// <summary>
        /// Cria uma instância de <see cref="HouseLight"/> a partir de uma instância de <see cref="House"/>.
        /// </summary>
        /// <param name="house">Instância de <see cref="House"/> a ser convertida.</param>
        /// <returns>Uma nova instância de <see cref="HouseLight"/>.</returns>
        /// <exception cref="HouseExceptions">Lançada se a criação da casa simples falhar.</exception>
        public static HouseLight CreateHouseLight(House house)
        {
            if (ValidateHouse.ValidateHouseAttributes(house))
            {
                HouseLight houseLight = new HouseLight(house.Name, house.Location, house.PricePerNight);
                houseLight.Id = house.Id;
                return houseLight;
            }
            throw new HouseExceptions(100); // Casa inválida
        }

        /// <summary>
        /// Retorna uma representação textual dos atributos da casa simples usada somente para debug
        /// </summary>
        /// <returns>String com informações detalhadas da casa simples.</returns>
        public override string ToString()
        {
            return Name + " [ID: " + Id + "]\n\nLocalização:\t" + Location + "\nPreço p/noite:\t" + PricePerNight + "\n";
        }
    }
}

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
    /// Representa uma casa com atributos e métodos associados.
    /// </summary>
    [Serializable]
    public class House : Accommodation, IComparable<House>
    {
        private int roomCount;
        private int capacity;
        private bool hasPool;
        private bool hasGarage;

        /// <summary>
        /// Construtor padrão da classe <c>House</c>.
        /// </summary>
        public House()
        {
        }

        /// <summary>
        /// Construtor que inicializa uma casa com os atributos especificados.
        /// </summary>
        /// <param name="name">Nome da casa.</param>
        /// <param name="location">Localização da casa.</param>
        /// <param name="pricePerNight">Preço por noite.</param>
        /// <param name="roomCount">Número de quartos.</param>
        /// <param name="capacity">Capacidade máxima da casa.</param>
        /// <param name="hasGarage">Indica se a casa tem garagem.</param>
        /// <param name="hasPool">Indica se a casa tem piscina.</param>
        public House(string name, string location, double pricePerNight, int roomCount, int capacity, bool hasGarage, bool hasPool)
        {
            base.Id = Accommodation.IdCount++;
            base.Name = name;
            base.Location = location;
            base.PricePerNight = pricePerNight;
            base.Available = true;
            RoomCount = roomCount;
            Capacity = capacity;
            HasPool = hasPool;
            HasGarage = hasGarage;
        }

        /// <summary>
        /// Obtém ou define o número de quartos da casa.
        /// </summary>
        public int RoomCount
        {
            get { return roomCount; }
            set { roomCount = value; }
        }

        /// <summary>
        /// Obtém ou define a capacidade máxima da casa.
        /// </summary>
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        /// <summary>
        /// Obtém ou define se a casa possui piscina.
        /// </summary>
        public bool HasPool
        {
            get { return hasPool; }
            set { hasPool = value; }
        }

        /// <summary>
        /// Obtém ou define se a casa possui garagem.
        /// </summary>
        public bool HasGarage
        {
            get { return hasGarage; }
            set { hasGarage = value; }
        }

        /// <summary>
        /// Cria uma nova instância de casa com os atributos especificados.
        /// </summary>
        /// <param name="name">Nome da casa.</param>
        /// <param name="location">Localização da casa.</param>
        /// <param name="pricePerNight">Preço por noite.</param>
        /// <param name="roomCount">Número de quartos.</param>
        /// <param name="capacity">Capacidade máxima da casa.</param>
        /// <param name="hasGarage">Indica se a casa tem garagem.</param>
        /// <param name="hasPool">Indica se a casa tem piscina.</param>
        /// <returns>Uma nova instância de <see cref="House"/>.</returns>
        /// <exception cref="HouseExceptions">Lançada se a criação da casa falhar.</exception>
        public static House CreateHouse(string name, string location, double pricePerNight, int roomCount, int capacity, bool hasGarage, bool hasPool)
        {
            House house = new House(name, location, pricePerNight, roomCount, capacity, hasGarage, hasPool);
            if (ValidateHouse.ValidateHouseAttributes(house))
            {
                return house;
            }
            throw new HouseExceptions(100); // Casa inválida
        }

        /// <summary>
        /// Compara o preço por noite de uma casa com outra casa.
        /// </summary>
        /// <param name="house">A casa a comparar.</param>
        /// <returns>Um número negativo, zero ou positivo, conforme esta casa tenha preço inferior, igual ou superior.</returns>
        public int CompareTo(House house)
        {
            return PricePerNight.CompareTo(house.PricePerNight);
        }

        /// <summary>
        /// Retorna uma representação textual detalhada dos atributos da casa usada somente para debug.
        /// </summary>
        /// <returns>Uma string que contém os detalhes da casa.</returns>
        public override string ToString()
        {
            return Name + " [ID: " + Id + "]\n\nLocalização:\t" + Location + "\nCapacidade:\t" + Capacity + " pessoas\nPreço p/noite:\t" + PricePerNight + " euros\nNº de quartos:\t" + RoomCount + "\nPiscina:\t" + (HasPool ? "Sim" : "Não") + "\nGaragem:\t" + (HasGarage ? "Sim" : "Não") + "\nDisponível:\t" + (Available ? "Sim" : "Não") + "\n";
        }
    }
}

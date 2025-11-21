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
    /// Representa uma reserva associada a um alojamento.
    /// </summary>
    [Serializable]
    public class Reservation : IComparable<Reservation>
    {
        private int id;
        private static int idCount = 1;
        private DateTime startDate;
        private DateTime endDate;
        private double cost;
        private House house;
        private bool isCancelled;

        /// <summary>
        /// Construtor padrão para a classe <see cref="Reservation"/>.
        /// </summary>
        public Reservation()
        {
        }

        /// <summary>
        /// Construtor que inicializa uma nova reserva com os atributos especificados.
        /// </summary>
        /// <param name="house">Casa associada à reserva.</param>
        /// <param name="startDate">Data de início da reserva.</param>
        /// <param name="endDate">Data de fim da reserva.</param>
        public Reservation(House house, DateTime startDate, DateTime endDate)
        {
            Id = IdCount++;
            House = house;
            StartDate = startDate;
            EndDate = endDate;
            Cost = 0.00;
            IsCancelled = false;
        }

        /// <summary>
        /// Obtém ou define o ID da reserva.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Obtém ou define o contador estático de IDs.
        /// </summary>
        public static int IdCount
        {
            get { return idCount; }
            set { idCount = value; }
        }

        /// <summary>
        /// Obtém ou define a data de início da reserva.
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        /// <summary>
        /// Obtém ou define a data de fim da reserva.
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        /// <summary>
        /// Obtém ou define o custo total da reserva.
        /// </summary>
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        /// <summary>
        /// Obtém ou define a casa associada à reserva.
        /// </summary>
        public House House
        {
            get { return house; }
            set { house = value; }
        }

        /// <summary>
        /// Obtém ou define o estado de cancelamento da reserva.
        /// </summary>
        public bool IsCancelled
        {
            get { return isCancelled; }
            set { isCancelled = value; }
        }

        /// <summary>
        /// Cria uma nova instância de reserva.
        /// </summary>
        /// <param name="house">Casa associada à reserva.</param>
        /// <param name="startDate">Data de início da reserva.</param>
        /// <param name="endDate">Data de fim da reserva.</param>
        /// <returns>Uma nova instância de <see cref="Reservation"/>.</returns>
        /// <exception cref="ReservationExceptions">Lançada se a criação da reserva falhar.</exception>
        public static Reservation CreateReservation(House house, DateTime startDate, DateTime endDate)
        {
            Reservation reservation = new Reservation(house, startDate, endDate);
            if (ValidateReservation.ValidateReservationAttributes(reservation))
            {
                return reservation;
            }
            throw new ReservationExceptions(115); // Reserva inválida
        }

        /// <summary>
        /// Compara a data de início de duas reservas.
        /// </summary>
        /// <param name="reservation">A reserva a ser comparada.</param>
        /// <returns>Valor negativo, zero ou positivo se a data de início da reserva for anterior, igual ou posterior à da reserva comparada.</returns>
        public int CompareTo(Reservation reservation)
        {
            return startDate.CompareTo(reservation.startDate);
        }

        /// <summary>
        /// Retorna uma representação textual dos atributos da reserva usada somente para debug
        /// </summary>
        /// <returns>Uma string contendo as informações detalhadas da reserva.</returns>
        public override string ToString()
        {
            if (!IsCancelled)
            {
                return "RESERVA [ID: " + Id + "] -> " + House.Name + " [ID: " + House.Id + "]\n\nData de início:\t" + StartDate + "\nData de fim:\t" + EndDate + "\nCusto:\t\t" + Cost + " euros\n";
            }
            return "RESERVA CANCELADA [ID: " + Id + "] -> " + House.Name + " [ID: " + House.Id + "]\n\nData de início:\t" + StartDate + "\nData de fim:\t" + EndDate + "\nCusto:\t\t" + Cost + " euros\n";
        }
    }
}

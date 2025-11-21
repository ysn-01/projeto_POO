using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;
using TreatProblems;
using Validations;

namespace Data
{
    /// <summary>
    /// Classe responsável por gerir reservas e realizar operações relacionadas.
    /// </summary>
    [Serializable]
    public class Reservations
    {
        /// <summary>
        /// Lista estática que armazena todas as reservas.
        /// </summary>
        private static List<Reservation> reservationList = new List<Reservation>();

        /// <summary>
        /// Adiciona uma reserva à lista.
        /// </summary>
        /// <param name="reservation">Objeto da reserva a ser adicionada.</param>
        /// <returns>Verdadeiro se a reserva for adicionada com sucesso.</returns>
        /// <exception cref="ReservationExceptions">Lançada se a reserva já existir na lista.</exception>
        public static bool AddReservation(Reservation reservation)
        {
            if (!reservationList.Contains(reservation))
            {
                reservationList.Add(reservation);
                return true;
            }
            throw new ReservationExceptions(119); // A reserva já existe na lista de reservas
        }

        /// <summary>
        /// Obtém uma reserva da lista com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único da reserva.</param>
        /// <returns>Objeto da reserva correspondente.</returns>
        /// <exception cref="ReservationExceptions">Lançada se a reserva não for encontrada.</exception>
        public static Reservation GetReservation(int id)
        {
            foreach (Reservation reservation in reservationList)
            {
                if (reservation.Id == id)
                {
                    return reservation;
                }
            }
            throw new ReservationExceptions(120); // Reserva não encontrada
        }

        /// <summary>
        /// Atualiza as datas de uma reserva existente.
        /// </summary>
        /// <param name="id">ID único da reserva a ser atualizada.</param>
        /// <param name="startDate">Nova data de início da reserva.</param>
        /// <param name="endDate">Nova data de término da reserva.</param>
        /// <returns>Verdadeiro se a atualização for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se não for possível atualizar os dados da reserva</exception>
        public static bool UpdateReservation(int id, DateTime startDate, DateTime endDate)
        {
            Reservation reservation = GetReservation(id);
            if (ValidateReservation.ValidateReservationAttributes(reservation))
            {
                reservation.Id = id;
                reservation.StartDate = startDate;
                reservation.EndDate = endDate;
                return true;
            }
            throw new ReservationExceptions(122); // Não foi possível atualizar os dados da reserva
        }

        /// <summary>
        /// Remove uma reserva da lista com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único da reserva a ser removida.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se não for possível remover a reserva</exception>
        public static bool RemoveReservation(int id)
        {
            Reservation reservation = GetReservation(id);
            if (reservationList.Contains(reservation))
            {
                reservationList.Remove(reservation);
                return true;
            }
            throw new ReservationExceptions(123); // Não foi possível remover a reserva
        }

        /// <summary>
        /// Calcula o custo de uma reserva com base no ID da reserva e na casa associada.
        /// </summary>
        /// <param name="id">ID único da reserva.</param>
        /// <param name="houseId">ID único da casa associada à reserva.</param>
        /// <returns>Verdadeiro se o custo for calculado com sucesso.</returns>
        /// <exception cref="ReservationExceptions">Lançada se a reserva não for de pelo menos uma noite ou se não for possível obter o custo da reserva</exception>
        public static bool GetReservationCost(int id)
        {
            Reservation reservation = GetReservation(id);
            HouseLight houseLight = Houses.GetHouse(reservation.House.Id);
            if (ValidateReservation.ValidateReservationAttributes(reservation) && ValidateHouseLight.ValidateHouseLightAttributes(houseLight))
            {
                int nightCount = (reservation.EndDate - reservation.StartDate).Days;
                if (nightCount > 0)
                {
                    double cost = houseLight.PricePerNight * nightCount;
                    reservation.Cost = cost;
                    return true;
                }
                throw new ReservationExceptions(124); // A reserva tem que ser de pelo menos uma noite
            }
            throw new ReservationExceptions(125); // Não foi possível obter o custo da reserva
        }

        /// <summary>
        /// Cancela uma reserva existente.
        /// </summary>
        /// <param name="id">ID único da reserva a ser cancelada.</param>
        /// <returns>Verdadeiro se o cancelamento for bem-sucedido.</returns>
        /// <exception cref="ReservationExceptions">Lançada se a reserva já foi cancelada ou não for encontrada</exception>
        public static bool CancelReservation(int id)
        {
            Reservation reservation = GetReservation(id);
            if (ValidateReservation.ValidateReservationAttributes(reservation))
            {
                if (!reservation.IsCancelled)
                {
                    reservation.IsCancelled = true;
                    reservation.Id = -1;
                    return true;
                }
                throw new ReservationExceptions(126); // A reserva já foi cancelada
            }
            throw new ReservationExceptions(121); // Reserva inválida
        }

        /// <summary>
        /// Organiza a lista de reservas em ordem crescente de data.
        /// </summary>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        public static bool OrderByDateASC()
        {
            reservationList.Sort();
            return true;
        }

        /// <summary>
        /// Guarda a lista de reservas num ficheiro binário.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o nome do ficheiro for inválido.</exception>
        public static bool SaveReservationsFile(string fileName)
        {
            if (fileName != null)
            {
                using (FileStream s = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, reservationList); // Serializa a lista estática
                }
                return true;
            }
            throw new ReservationExceptions(127); // Nome do ficheiro inválido
        }

        /// <summary>
        /// Lê a lista de reservas de um ficheiro binário.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o ficheiro não existir ou se o nome do ficheiro for inválido</exception>
        public static bool ReadReservationsFile(string fileName)
        {
            if (fileName != null)
            {
                if (!File.Exists(fileName))
                {
                    throw new ReservationExceptions(128); // O ficheiro não existe
                }

                using (FileStream s = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    reservationList = (List<Reservation>)formatter.Deserialize(s);
                }
                return true;

            }
            throw new ReservationExceptions(126); // Nome do ficheiro inválido
        }
    }
}

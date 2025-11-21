using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;
using TreatProblems;
using Validations;
using Data;

namespace Rules
{
    /// <summary>
    /// Classe responsável por implementar as regras de negócio relacionadas com as reservas.
    /// </summary>
    [Serializable]
    public static class ReservationRules
    {
        /// <summary>
        /// Tenta criar uma nova reserva.
        /// </summary>
        /// <param name="house">Objeto da casa onde a reserva será realizada.</param>
        /// <param name="startDate">Data de início da reserva.</param>
        /// <param name="endDate">Data de fim da reserva.</param>
        /// <returns>Objeto da reserva criada.</returns>
        /// <exception cref="ReservationExceptions">Lançada se a reserva for inválida ou a casa não estiver disponível.</exception>
        public static Reservation TryMakeReservation(PERMS perms, House house, DateTime startDate, DateTime endDate)
        {
            if (Houses.GetHouseAvailability(house.Id))
            {
                if (perms == PERMS.USER || perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                {
                    Reservation reservation = Reservation.CreateReservation(house, startDate, endDate);
                    Reservations.AddReservation(reservation);
                    Reservations.GetReservationCost(reservation.Id);
                    house.Available = false;
                    return reservation;
                }
                throw new ReservationExceptions(116); // Não tem permissões
            }
            throw new ReservationExceptions(117); // A casa não está disponível para reserva
        }

        /// <summary>
        /// Tenta atualizar os dados de uma reserva existente.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da reserva a ser atualizada.</param>
        /// <param name="startDate">Nova data de início da reserva.</param>
        /// <param name="endDate">Nova data de fim da reserva.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o utilizador não tiver permissões ou se a reserva for inválida.</exception>
        public static bool TryUpdateReservation(PERMS perms, int id, DateTime startDate, DateTime endDate)
        {
            if (id > 0)
            {
                if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                {
                    Reservations.UpdateReservation(id, startDate, endDate);
                    return true;
                }
                throw new ReservationExceptions(116); // Não tem permissões
            }
            throw new ReservationExceptions(118); // ID inválido
        }

        /// <summary>
        /// Tenta remover uma reserva existente.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da reserva a ser removida.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryRemoveReservation(PERMS perms, int id)
        {
            if (id > 0)
            {
                if (perms == PERMS.ADMIN)
                {
                    Reservations.RemoveReservation(id);
                    return true;
                }
                throw new ReservationExceptions(116); // Não tem permissões
            }
            throw new ReservationExceptions(118); // ID inválido
        }

        /// <summary>
        /// Tenta cancelar uma reserva existente.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da reserva a ser cancelada.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryCancelReservation(PERMS perms, int id)
        {
            if (id > 0)
            {
                if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                {
                    Reservations.CancelReservation(id);
                    return true;
                }
                throw new ReservationExceptions(116); // Não tem permissões
            }
            throw new ReservationExceptions(118); // ID inválido
        }

        /// <summary>
        /// Tenta organizar as reservas por data (da mais antiga para a mais recente).
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryOrderByDateASC(PERMS perms)
        {
            if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
            {
                Reservations.OrderByDateASC();
                return true;
            }
            throw new ReservationExceptions(116); // Não tem permissões
        }

        /// <summary>
        /// Tenta guardar os dados das reservas num ficheiro binário.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TrySaveReservationsFile(PERMS perms, string fileName)
        {
            if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
            {
                Reservations.SaveReservationsFile(fileName);
                return true;
            }
            throw new ReservationExceptions(116); // Não tem permissões
        }

        /// <summary>
        /// Tenta ler os dados das reservas de um ficheiro binário.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="ReservationExceptions">Lançada se o utilizador não tiver permissões de administrador.</exception>
        public static bool TryReadReservationsFile(PERMS perms, string fileName)
        {
            if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
            {
                Reservations.ReadReservationsFile(fileName);
                return true;
            }
            throw new ReservationExceptions(116); // Não tem permissões
        }
    }
}

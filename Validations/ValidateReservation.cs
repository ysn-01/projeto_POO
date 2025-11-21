using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;
using TreatProblems;

namespace Validations
{
    /// <summary>
    /// Classe responsável pela validação dos atributos de uma reserva.
    /// </summary>
    public class ValidateReservation
    {
        /// <summary>
        /// Construtor padrão da classe <c>ValidateReservation</c>.
        /// </summary>
        public ValidateReservation()
        {

        }

        /// <summary>
        /// Valida os principais atributos de uma reserva.
        /// </summary>
        /// <param name="reservation">Objeto <c>Reservation</c> a ser validado.</param>
        /// <returns><c>true</c> se todos os atributos forem válidos; caso contrário, lança uma exceção.</returns>
        public static bool ValidateReservationAttributes(Reservation reservation)
        {
            if (!(ValidateHouse.ValidateHouseId(reservation.House.Id)))
            {
                return false;
            }

            if (!ValidateStartDate(reservation.StartDate))
            {
                return false;
            }

            if (!ValidateEndDate(reservation.EndDate, reservation.StartDate))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida a data de início da reserva.
        /// </summary>
        /// <param name="startDate">Data de início da reserva.</param>
        /// <returns><c>true</c> se a data de início for válida; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateReservationExceptions">Lançada se a data de início for inválida.</exception>
        public static bool ValidateStartDate(DateTime startDate)
        {
            if (startDate > DateTime.Now)
            {
                return true;
            }
            throw new ValidateReservationExceptions(137); // Data de início inválida
        }

        /// <summary>
        /// Valida a data de fim da reserva.
        /// </summary>
        /// <param name="endDate">Data de fim da reserva.</param>
        /// <returns><c>true</c> se a data de fim for válida; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateReservationExceptions">Lançada se a data de fim for inválida.</exception>
        public static bool ValidateEndDate(DateTime endDate, DateTime startDate)
        {
            if (endDate > DateTime.Now && endDate > startDate)
            {
                return true;
            }
            throw new ValidateReservationExceptions(138); // Data de fim inválida
        }
    }
}

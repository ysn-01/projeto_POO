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
    /// Classe responsável pela validação dos atributos de uma casa.
    /// </summary>
    public class ValidateHouse
    {
        /// <summary>
        /// Construtor padrão da classe <c>ValidateHouse</c>.
        /// </summary>
        public ValidateHouse()
        {

        }

        /// <summary>
        /// Valida todos os atributos de uma casa.
        /// </summary>
        /// <param name="house">Objeto <c>House</c> a ser validado.</param>
        /// <returns><c>true</c> se todos os atributos forem válidos; caso contrário, lança uma exceção.</returns>
        public static bool ValidateHouseAttributes(House house)
        {
            if (!ValidateHouseId(house.Id))
            {
                return false;
            }

            if (!ValidateHouseName(house.Name))
            {
                return false;
            }

            if (!ValidateHouseLocation(house.Location))
            {
                return false;
            }

            if (!ValidateHousePPN(house.PricePerNight))
            {
                return false;
            }

            if (!ValidateRoomCount(house.RoomCount))
            {
                return false;
            }

            if (!ValidateCapacity(house.Capacity))
            {
                return false;
            }

            if (!ValidateHasGarage(house.HasGarage))
            {
                return false;
            }

            if (!ValidateHasPool(house.HasPool))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida o ID da casa.
        /// </summary>
        /// <param name="id">ID da casa.</param>
        /// <returns><c>true</c> se o ID for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o ID for inválido.</exception>
        public static bool ValidateHouseId(int id)
        {
            if (id > 0)
            {
                return true;
            }
            throw new ValidateHouseExceptions(129); // ID inválido
        }

        /// <summary>
        /// Valida o nome da casa.
        /// </summary>
        /// <param name="name">Nome da casa.</param>
        /// <returns><c>true</c> se o nome for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o nome for inválido.</exception>
        public static bool ValidateHouseName(string name)
        {
            if (name != null)
            {
                return true;
            }
            throw new ValidateHouseExceptions(130); // Nome inválido
        }

        /// <summary>
        /// Valida a localização da casa.
        /// </summary>
        /// <param name="location">Localização da casa.</param>
        /// <returns><c>true</c> se a localização for válida; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se a localização for inválida.</exception>
        public static bool ValidateHouseLocation(string location)
        {
            if (location != null)
            {
                return true;
            }
            throw new ValidateHouseExceptions(131); // Localização inválida
        }

        /// <summary>
        /// Valida o preço por noite da casa.
        /// </summary>
        /// <param name="pricePerNight">Preço por noite.</param>
        /// <returns><c>true</c> se o preço por noite for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o preço for inválido.</exception>
        public static bool ValidateHousePPN(double pricePerNight)
        {
            if (pricePerNight > 0)
            {
                return true;
            }
            throw new ValidateHouseExceptions(132); // Preço por noite inválido
        }

        /// <summary>
        /// Valida o número de quartos da casa.
        /// </summary>
        /// <param name="roomCount">Número de quartos.</param>
        /// <returns><c>true</c> se o número de quartos for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o número de quartos for inválido.</exception>
        public static bool ValidateRoomCount(int roomCount)
        {
            if (roomCount > 0)
            {
                return true;
            }
            throw new ValidateHouseExceptions(133); // Número de quartos inválido
        }

        /// <summary>
        /// Valida a capacidade de pessoas na casa.
        /// </summary>
        /// <param name="capacity">Capacidade de pessoas.</param>
        /// <returns><c>true</c> se a capacidade for válida; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se a capacidade for inválida.</exception>
        public static bool ValidateCapacity(int capacity)
        {
            if (capacity > 0)
            {
                return true;
            }
            throw new ValidateHouseExceptions(134); // Capacidade de pessoas inválida
        }

        /// <summary>
        /// Valida a existência de uma garagem na casa.
        /// </summary>
        /// <param name="hasGarage">Indica se a casa tem garagem.</param>
        /// <returns><c>true</c> se o valor for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o valor for inválido.</exception>
        public static bool ValidateHasGarage(bool hasGarage)
        {
            if (hasGarage == true || hasGarage == false)
            {
                return true;
            }
            throw new ValidateHouseExceptions(135); // Existência de garagem inválida
        }

        /// <summary>
        /// Valida a existência de uma piscina na casa.
        /// </summary>
        /// <param name="hasPool">Indica se a casa tem piscina.</param>
        /// <returns><c>true</c> se o valor for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o valor for inválido.</exception>
        public static bool ValidateHasPool(bool hasPool)
        {
            if (hasPool == true || hasPool == false)
            {
                return true;
            }
            throw new ValidateHouseExceptions(136); // Existência de piscina inválida
        }
    }
}

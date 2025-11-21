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
    /// Classe responsável pela validação dos atributos de uma casa simplificada (<c>HouseLight</c>).
    /// </summary>
    public class ValidateHouseLight
    {
        /// <summary>
        /// Construtor padrão da classe <c>ValidateHouseLight</c>.
        /// </summary>
        public ValidateHouseLight()
        {

        }

        /// <summary>
        /// Valida os atributos principais de uma casa simplificada.
        /// </summary>
        /// <param name="houseLight">Objeto <c>HouseLight</c> a ser validado.</param>
        /// <returns><c>true</c> se todos os atributos principais forem válidos; caso contrário, lança uma exceção.</returns>
        public static bool ValidateHouseLightAttributes(HouseLight houseLight)
        {
            if (!ValidateHouseId(houseLight.Id))
            {
                return false;
            }

            if (!ValidateHouseName(houseLight.Name))
            {
                return false;
            }

            if (!ValidateHouseLocation(houseLight.Location))
            {
                return false;
            }

            if (!ValidateHousePPN(houseLight.PricePerNight))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida o ID da casa simplificada.
        /// </summary>
        /// <param name="id">ID da casa simplificada.</param>
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
        /// Valida o nome da casa simplificada.
        /// </summary>
        /// <param name="name">Nome da casa simplificada.</param>
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
        /// Valida a localização da casa simplificada.
        /// </summary>
        /// <param name="location">Localização da casa simplificada.</param>
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
        /// Valida o preço por noite da casa simplificada.
        /// </summary>
        /// <param name="pricePerNight">Preço por noite da casa simplificada.</param>
        /// <returns><c>true</c> se o preço por noite for válido; caso contrário, lança uma exceção.</returns>
        /// <exception cref="ValidateHouseExceptions">Lançada se o preço por noite for inválido.</exception>
        public static bool ValidateHousePPN(double pricePerNight)
        {
            if (pricePerNight > 0)
            {
                return true;
            }
            throw new ValidateHouseExceptions(132); // Preço por noite inválido
        }
    }
}

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
    /// Classe estática que implementa as regras de negócio relacionadas com as casas.
    /// </summary>
    public static class HouseRules
    {
        /// <summary>
        /// Tenta criar uma nova casa.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="name">Nome da casa.</param>
        /// <param name="location">Localização da casa.</param>
        /// <param name="pricePerNight">Preço por noite.</param>
        /// <param name="roomCount">Número de quartos.</param>
        /// <param name="capacity">Capacidade da casa.</param>
        /// <param name="hasPool">Indica se a casa tem piscina.</param>
        /// <param name="hasGarage">Indica se a casa tem garagem.</param>
        /// <returns>Objeto da casa criada.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões ou se a casa for inválida.</exception>
        public static House TryCreateHouse(PERMS perms, string name, string location, double pricePerNight, int roomCount, int capacity, bool hasGarage, bool hasPool)
        {
            if (perms == PERMS.ADMIN)
            {
                House house = House.CreateHouse(name, location, pricePerNight, roomCount, capacity, hasGarage, hasPool);
                return house;
            }
            throw new HouseExceptions(101); // Não tem permissões
        }

        /// <summary>
        /// Tenta adicionar uma casa à lista de casas.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="house">Objeto da casa a ser adicionada.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryAddHouse(PERMS perms, House house)
        {
            if (ValidateHouse.ValidateHouseAttributes(house))
            {
                if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                {
                    Houses.AddHouse(house);
                    return true;
                }
                throw new HouseExceptions(101); // Não tem permissões
            }
            throw new HouseExceptions(102); // Casa inválida
        }

        /// <summary>
        /// Tenta atualizar os dados de uma casa existente.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da casa.</param>
        /// <param name="name">Nome da casa.</param>
        /// <param name="location">Localização da casa.</param>
        /// <param name="pricePerNight">Preço por noite.</param>
        /// <param name="roomCount">Número de quartos.</param>
        /// <param name="capacity">Capacidade da casa.</param>
        /// <param name="hasPool">Indica se a casa tem piscina.</param>
        /// <param name="hasGarage">Indica se a casa tem garagem.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões ou se a casa for inválida.</exception>
        public static bool TryUpdateHouseData(PERMS perms, int id, string name, string location, double pricePerNight, int roomCount, int capacity, bool hasGarage, bool hasPool)
        {
            if (id > 0)
            {
                if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                {
                    Houses.UpdateHouseData(id, name, location, pricePerNight, roomCount, capacity, hasGarage, hasPool);
                    return true;
                }
                throw new HouseExceptions(101); // Não tem permissões
            }
            throw new HouseExceptions(103); // ID inválido
        }

        /// <summary>
        /// Tenta atualizar todos os dados de uma casa existente.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da casa.</param>
        /// <param name="newHouse">Nova informação da casa.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões ou se a casa for inválida.</exception>
        public static bool TryUpdateFullHouse(PERMS perms, int id, House newData)
        {
            if (id > 0)
            {
                if (newData != null)
                {
                    if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                    {
                        Houses.UpdateFullHouse(id, newData);
                        return true;
                    }
                    throw new HouseExceptions(104); // Dados inválidos
                }
                throw new HouseExceptions(101); // Não tem permissões
            }
            throw new HouseExceptions(103); // ID inválido
        }

        /// <summary>
        /// Tenta remover uma casa existente.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da casa.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryRemoveHouse(PERMS perms, int id)
        {
            if (id > 0)
            {
                if (perms == PERMS.ADMIN)
                {
                    Houses.RemoveHouse(id);
                    return true;
                }
                throw new HouseExceptions(101); // Não tem permissões
            }
            throw new HouseExceptions(103); // ID inválido
        }

        /// <summary>
        /// Tenta verificar a disponibilidade de uma casa.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="id">ID da casa.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryGetHouseAvailability(PERMS perms, int id)
        {
            if (id > 0)
            {
                if (perms == PERMS.USER || perms == PERMS.MANAGER || perms == PERMS.ADMIN)
                {
                    Houses.GetHouseAvailability(id);
                    return true;
                }
                throw new HouseExceptions(101); // Não tem permissões
            }
            throw new HouseExceptions(103); // ID inválido
        }

        /// <summary>
        /// Tenta organizar as casas por preço (do menor para o maior).
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TryOrderByPriceASC(PERMS perms)
        {
            if (perms == PERMS.USER || perms == PERMS.MANAGER || perms == PERMS.ADMIN)
            {
                Houses.OrderByPriceASC();
                return true;
            }
            throw new HouseExceptions(101); // Não tem permissões
        }

        /// <summary>
        /// Tenta guardar os dados das casas num ficheiro binário.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>True se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões.</exception>
        public static bool TrySaveHousesFile(PERMS perms, string fileName)
        {
            if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
            {
                Houses.SaveHousesFile(fileName);
                return true;
            }
            throw new HouseExceptions(101); // Não tem permissões
        }

        /// <summary>
        /// Tenta ler os dados das casas de um ficheiro binário.
        /// </summary>
        /// <param name="perms">Nível de permissões do utilizador.</param>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>True se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o utilizador não tiver permissões de administrador.</exception>
        public static bool TryReadHousesFile(PERMS perms, string fileName)
        {
            if (perms == PERMS.MANAGER || perms == PERMS.ADMIN)
            {
                Houses.ReadHousesFile(fileName);
                return true;
            }
            throw new HouseExceptions(101); // Não tem permissões
        }
    }
}

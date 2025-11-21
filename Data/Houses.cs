using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;
using TreatProblems;
using Validations;

namespace Data
{
    /// <summary>
    /// Classe para manipular a lista de casas e suas operações associadas.
    /// </summary>
    [Serializable]
    public class Houses
    {
        /// <summary>
        /// Lista estática para armazenar todas as casas.
        /// </summary>
        private static List<House> houseList = new List<House>();

        /// <summary>
        /// Adiciona uma casa à lista, caso não esteja duplicada.
        /// </summary>
        /// <param name="house">Objeto da casa a ser adicionada.</param>
        /// <returns>Verdadeiro se a casa for adicionada com sucesso.</returns>
        /// <exception cref="HouseExceptions">Lançada se a casa já existir na lista.</exception>
        public static bool AddHouse(House house)
        {
            if (!houseList.Contains(house))
            {
                houseList.Add(house);
                return true;
            }
            throw new HouseExceptions(105); // A casa já existe na lista de casas
        }

        /// <summary>
        /// Encontra uma casa na lista com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único da casa.</param>
        /// <returns>Objeto da casa correspondente.</returns>
        /// <exception cref="HouseExceptions">Lançada se a casa não for encontrada.</exception>
        private static House FindHouse(int id)
        {
            foreach (House house in houseList)
            {
                if (house.Id == id)
                {
                    return house;
                }
            }
            throw new HouseExceptions(106); // Casa não encontrada
        }

        /// <summary>
        /// Obtém uma versão simplificada de uma casa da lista com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único da casa.</param>
        /// <returns>Objeto de uma casa simples, com nome, localização e preço por noite.</returns>
        /// <exception cref="HouseExceptions">Lançada se a casa for inválida.</exception>
        public static HouseLight GetHouse(int id)
        {
            House house = FindHouse(id);
            HouseLight houseLight = HouseLight.CreateHouseLight(house);
            if (ValidateHouseLight.ValidateHouseLightAttributes(houseLight))
            {
                houseLight.Id = house.Id;
                return houseLight;
            }
            throw new HouseExceptions(107); // Casa inválida
        }

        /// <summary>
        /// Atualiza os dados de uma casa existente.
        /// </summary>
        /// <param name="id">ID único da casa a ser atualizada.</param>
        /// <param name="name">Novo nome da casa.</param>
        /// <param name="location">Nova localização da casa.</param>
        /// <param name="pricePerNight">Novo preço por noite.</param>
        /// <param name="roomCount">Novo número de quartos.</param>
        /// <param name="capacity">Nova capacidade da casa.</param>
        /// <param name="hasPool">Indica se a casa tem piscina.</param>
        /// <param name="hasGarage">Indica se a casa tem garagem.</param>
        /// <returns>Verdadeiro se a atualização for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se não for possível atualizar os dados da casa</exception>
        public static bool UpdateHouseData(int id, string name, string location, double pricePerNight, int roomCount, int capacity, bool hasPool, bool hasGarage)
        {
            House house = FindHouse(id);
            if (ValidateHouse.ValidateHouseAttributes(house))
            {
                house.Name = name;
                house.Location = location;
                house.PricePerNight = pricePerNight;
                house.RoomCount = roomCount;
                house.Capacity = capacity;
                house.HasPool = hasPool;
                house.HasGarage = hasGarage;
                return true;
            }
            throw new HouseExceptions(108); // Não foi possível atualizar os dados da casa
        }

        /// <summary>
        /// Atualiza todos os dados de uma casa existente.
        /// </summary>
        /// <param name="id">ID único da casa a ser atualizada.</param>
        /// <param name="newData">Objeto com os novos dados da casa.</param>
        /// <returns>Verdadeiro se a atualização for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se não for possível atualizar a casa</exception>
        public static bool UpdateFullHouse(int id, House newData)
        {
            House house = FindHouse(id);
            if (ValidateHouse.ValidateHouseAttributes(house))
            {
                house.Id = newData.Id;
                house.Name = newData.Name;
                house.Location = newData.Location;
                house.PricePerNight = newData.PricePerNight;
                house.RoomCount = newData.RoomCount;
                house.Capacity = newData.Capacity;
                house.HasGarage = newData.HasGarage;
                house.HasPool = newData.HasPool;
                return true;
            }
            throw new HouseExceptions(109); // Não foi possível atualizar a casa
        }

        /// <summary>
        /// Remove uma casa da lista com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único da casa a ser removida.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se não for possível remover a casa</exception>
        public static bool RemoveHouse(int id)
        {
            House house = FindHouse(id);
            if (houseList.Contains(house))
            {
                houseList.Remove(house);
                return true;
            }
            throw new HouseExceptions(110); // Não foi possível remover a casa
        }

        /// <summary>
        /// Verifica se uma casa está disponível para reserva.
        /// </summary>
        /// <param name="id">ID único da casa.</param>
        /// <returns>Verdadeiro se a casa estiver disponível.</returns>
        /// <exception cref="HouseExceptions">Lançada se a casa não tiver disponível ou se não for possível ver a disponibilidade da mesma</exception>
        public static bool GetHouseAvailability(int id)
        {
            House house = FindHouse(id);
            if (ValidateHouse.ValidateHouseAttributes(house))
            {
                if (house.Available == true)
                {
                    return true;
                }
                throw new HouseExceptions(111); // A casa não está disponível
            }
            throw new HouseExceptions(112); // Não foi possível ver a disponibilidade da casa
        }

        /// <summary>
        /// Organiza a lista de casas em ordem crescente de preço por noite.
        /// </summary>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        public static bool OrderByPriceASC()
        {
            houseList.Sort();
            return true;
        }

        /// <summary>
        /// Guarda a lista de casas num ficheiro binário.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro onde os dados serão guardados.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o nome do ficheiro for inválido.</exception>
        public static bool SaveHousesFile(string fileName)
        {
            if (fileName != null)
            {
                using (FileStream s = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, houseList); // Serializa a lista estática
                }
                return true;
            }
            throw new HouseExceptions(113); // Nome do ficheiro inválido
        }

        /// <summary>
        /// Lê a lista de casas de um ficheiro binário.
        /// </summary>
        /// <param name="fileName">O nome do ficheiro de onde os dados serão lidos.</param>
        /// <returns>Verdadeiro se a operação for bem-sucedida.</returns>
        /// <exception cref="HouseExceptions">Lançada se o ficheiro não existir ou for inválido</exception>
        public static bool ReadHousesFile(string fileName)
        {
            if (fileName != null)
            {
                if (!File.Exists(fileName))
                {
                    throw new HouseExceptions(114); // O ficheiro não existe
                }

                using (FileStream s = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    houseList = (List<House>)formatter.Deserialize(s);
                }
                return true;
            }
            throw new HouseExceptions(113); // Nome do ficheiro inválido
        }
    }
}

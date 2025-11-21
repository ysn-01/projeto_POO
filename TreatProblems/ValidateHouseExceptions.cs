using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatProblems
{
    /// <summary>
    /// Classe que representa uma exceção personalizada para erros relacionados com a classe ValidateHouse.
    /// </summary>
    public class ValidateHouseExceptions : Exception
    {
        private int errorCode;
        private static string currentLanguage = "en";

        /// <summary>
        /// Dicionário que contém mensagens de erro em vários idiomas.
        /// </summary>
        private static readonly Dictionary<string, Dictionary<int, string>> ErrorMessages = new Dictionary<string, Dictionary<int, string>>()
        {
            { "pt", new Dictionary<int, string> // Português
                {
                    { 129, "ID inválido" },
                    { 130, "Nome inválido" },
                    { 131, "Localização inválida" },
                    { 132, "Preço por noite inválido" },
                    { 133, "Número de quartos inválido" },
                    { 134, "Capacidade de pessoas inválida" },
                    { 135, "Existência de garagem inválida" },
                    { 136, "Existência de piscina inválida" }
                }
            },
            { "en", new Dictionary<int, string> // Inglês
                {
                    { 129, "Invalid ID" },
                    { 130, "Invalid name" },
                    { 131, "Invalid location" },
                    { 132, "Invalid price per night" },
                    { 133, "Invalid number of rooms" },
                    { 134, "Invalid capacity of people" },
                    { 135, "Invalid garage existence" },
                    { 136, "Invalid pool existence" }
                }
            },
            { "es", new Dictionary<int, string> // Espanhol
                {
                    { 129, "ID inválido" },
                    { 130, "Nombre inválido" },
                    { 131, "Ubicación inválida" },
                    { 132, "Precio por noche inválido" },
                    { 133, "Número de habitaciones inválido" },
                    { 134, "Capacidad de personas inválida" },
                    { 135, "Existencia de garaje inválida" },
                    { 136, "Existencia de piscina inválida" }
                }
            },
            { "zh", new Dictionary<int, string> // Mandarim (Chinês Simplificado)
                {
                    { 129, "无效的ID" },
                    { 130, "无效的名称" },
                    { 131, "无效的位置" },
                    { 132, "无效的每晚价格" },
                    { 133, "无效的房间数量" },
                    { 134, "无效的人数容量" },
                    { 135, "无效的车库存在" },
                    { 136, "无效的泳池存在" }
                }
            },
            { "hi", new Dictionary<int, string> // Hindi
                {
                    { 129, "अमान्य आईडी" },
                    { 130, "अमान्य नाम" },
                    { 131, "अमान्य स्थान" },
                    { 132, "अमान्य प्रति रात की कीमत" },
                    { 133, "अमान्य कमरे की संख्या" },
                    { 134, "अमान्य लोगों की क्षमता" },
                    { 135, "अमान्य गैराज अस्तित्व" },
                    { 136, "अमान्य पूल अस्तित्व" }
                }
            },
            { "ar", new Dictionary<int, string> // Árabe
                {
                    { 129, "معرف غير صالح" },
                    { 130, "اسم غير صالح" },
                    { 131, "موقع غير صالح" },
                    { 132, "سعر غير صالح لكل ليلة" },
                    { 133, "عدد الغرف غير صالح" },
                    { 134, "سعة الأشخاص غير صالحة" },
                    { 135, "وجود مرآب غير صالح" },
                    { 136, "وجود مسبح غير صالح" }
                }
            },
            { "fr", new Dictionary<int, string> // Francês
                {
                    { 129, "ID invalide" },
                    { 130, "Nom invalide" },
                    { 131, "Emplacement invalide" },
                    { 132, "Prix par nuit invalide" },
                    { 133, "Nombre de chambres invalide" },
                    { 134, "Capacité de personnes invalide" },
                    { 135, "Existence de garage invalide" },
                    { 136, "Existence de piscine invalide" }
                }
            },
            { "de", new Dictionary<int, string> // Alemão
                {
                    { 129, "Ungültige ID" },
                    { 130, "Ungültiger Name" },
                    { 131, "Ungültiger Standort" },
                    { 132, "Ungültiger Preis pro Nacht" },
                    { 133, "Ungültige Anzahl der Zimmer" },
                    { 134, "Ungültige Personenkapazität" },
                    { 135, "Ungültige Garagenexistenz" },
                    { 136, "Ungültige Poolexistenz" }
                }
            },
            { "ja", new Dictionary<int, string> // Japonês
                {
                    { 129, "無効なID" },
                    { 130, "無効な名前" },
                    { 131, "無効な場所" },
                    { 132, "無効な1泊の料金" },
                    { 133, "無効な部屋数" },
                    { 134, "無効な人数収容能力" },
                    { 135, "無効なガレージの存在" },
                    { 136, "無効なプールの存在" }
                }
            },
            { "ko", new Dictionary<int, string> // Coreano
                {
                    { 129, "유효하지 않은 ID" },
                    { 130, "유효하지 않은 이름" },
                    { 131, "유효하지 않은 위치" },
                    { 132, "유효하지 않은 1박 가격" },
                    { 133, "유효하지 않은 방 개수" },
                    { 134, "유효하지 않은 인원 수 용량" },
                    { 135, "유효하지 않은 차고 존재" },
                    { 136, "유효하지 않은 수영장 존재" }
                }
            },
            { "ru", new Dictionary<int, string> // Russo
                {
                    { 129, "Недействительный ID" },
                    { 130, "Недействительное имя" },
                    { 131, "Недействительное местоположение" },
                    { 132, "Недействительная цена за ночь" },
                    { 133, "Недействительное количество комнат" },
                    { 134, "Недействительная вместимость людей" },
                    { 135, "Недействительное существование гаража" },
                    { 136, "Недействительное существование бассейна" }
                }
            },
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado à exceção.</param>
        public ValidateHouseExceptions(int error) : base(ErrorMessages.ContainsKey(currentLanguage) && ErrorMessages[currentLanguage].ContainsKey(error) ? ErrorMessages[currentLanguage][error] : "0x80004005")
        {
            ErrorCode = error;
            Console.WriteLine("\n" + ErrorCode + " : " + Message);
        }

        /// <summary>
        /// Propriedade para obter ou definir o código de erro associado à exceção.
        /// </summary>
        public int ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        /// <summary>
        /// Propriedade para obter ou definir o idioma atualmente selecionado para as mensagens de erro.
        /// </summary>
        public static string CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
    }
}

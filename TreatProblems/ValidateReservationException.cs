using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatProblems
{
    /// <summary>
    /// Classe que representa uma exceção personalizada para erros relacionados com a classe ValidateReservation.
    /// </summary>
    public class ValidateReservationExceptions : Exception
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
                    { 137, "Data de início inválida" },
                    { 138, "Data de fim inválida" }
                }
            },
            { "en", new Dictionary<int, string> // Inglês
                {
                    { 137, "Invalid start date" },
                    { 138, "Invalid end date" }
                }
            },
            { "es", new Dictionary<int, string> // Espanhol
                {
                    { 137, "Fecha de inicio inválida" },
                    { 138, "Fecha de fin inválida" }
                }
            },
            { "zh", new Dictionary<int, string> // Mandarim (Chinês Simplificado)
                {
                    { 137, "无效的开始日期" },
                    { 138, "无效的结束日期" }
                }
            },
            { "hi", new Dictionary<int, string> // Hindi
                {
                    { 137, "अमान्य प्रारंभ तिथि" },
                    { 138, "अमान्य समाप्ति तिथि" }
                }
            },
            { "ar", new Dictionary<int, string> // Árabe
                {
                    { 137, "تاريخ البدء غير صالح" },
                    { 138, "تاريخ الانتهاء غير صالح" }
                }
            },
            { "fr", new Dictionary<int, string> // Francês
                {
                    { 137, "Date de début invalide" },
                    { 138, "Date de fin invalide" }
                }
            },
            { "de", new Dictionary<int, string> // Alemão
                {
                    { 137, "Ungültiges Startdatum" },
                    { 138, "Ungültiges Enddatum" }
                }
            },
            { "ja", new Dictionary<int, string> // Japonês
                {
                    { 137, "無効な開始日" },
                    { 138, "無効な終了日" }
                }
            },
            { "ko", new Dictionary<int, string> // Coreano
                {
                    { 137, "유효하지 않은 시작 날짜" },
                    { 138, "유효하지 않은 종료 날짜" }
                }
            },
            { "ru", new Dictionary<int, string> // Russo
                {
                    { 137, "Недействительная дата начала" },
                    { 138, "Недействительная дата окончания" }
                }
            },
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado à exceção.</param>
        public ValidateReservationExceptions(int error) : base(ErrorMessages.ContainsKey(currentLanguage) && ErrorMessages[currentLanguage].ContainsKey(error) ? ErrorMessages[currentLanguage][error] : "0x80004005")
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreatProblems
{
    /// <summary>
    /// Classe que representa uma exceção personalizada para erros relacionados com a classe House.
    /// </summary>
    public class HouseExceptions : Exception
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
                    { 100, "Casa inválida" },
                    { 101, "Não tem permissões para realizar esta ação" },
                    { 102, "Casa inválida" },
                    { 103, "ID inválido" },
                    { 104, "Dados inválidos" },
                    { 105, "A casa não existe na lista de casas" },
                    { 106, "Casa não encontrada" },
                    { 107, "Casa inválida" },
                    { 108, "Não foi possível atualizar os dados da casa" },
                    { 109, "Não foi possível atualizar a casa" },
                    { 110, "Não foi possível remover a casa" },
                    { 111, "A casa não está disponível" },
                    { 112, "Não foi possível ver a disponibilidade da casa" },
                    { 113, "Nome do ficheiro inválido" },
                    { 114, "O ficheiro não existe" }
                }
            },
            { "en", new Dictionary<int, string> // Inglês
                {
                    { 100, "Invalid house" },
                    { 101, "You do not have permission to perform this action" },
                    { 102, "Invalid house" },
                    { 103, "Invalid ID" },
                    { 104, "Invalid data" },
                    { 105, "The house does not exist in the list of houses" },
                    { 106, "House not found" },
                    { 107, "Invalid house" },
                    { 108, "Unable to update house data" },
                    { 109, "Unable to update the house" },
                    { 110, "Unable to remove the house" },
                    { 111, "The house is not available" },
                    { 112, "Unable to check house availability" },
                    { 113, "Invalid file name" },
                    { 114, "The file does not exist" }
                }
            },
            { "es", new Dictionary<int, string> // Espanhol
                {
                    { 100, "Casa inválida" },
                    { 101, "No tiene permiso para realizar esta acción" },
                    { 102, "Casa inválida" },
                    { 103, "ID inválido" },
                    { 104, "Datos inválidos" },
                    { 105, "La casa no existe en la lista de casas" },
                    { 106, "Casa no encontrada" },
                    { 107, "Casa inválida" },
                    { 108, "No se pudo actualizar los datos de la casa" },
                    { 109, "No se pudo actualizar la casa" },
                    { 110, "No se pudo eliminar la casa" },
                    { 111, "La casa no está disponible" },
                    { 112, "No se pudo verificar la disponibilidad de la casa" },
                    { 113, "Nombre de archivo inválido" },
                    { 114, "El archivo no existe" }
                }
            },
            { "zh", new Dictionary<int, string> // Mandarim (Chinês Simplificado)
                {
                    { 100, "无效的房子" },
                    { 101, "您无权执行此操作" },
                    { 102, "无效的房子" },
                    { 103, "无效的ID" },
                    { 104, "无效的数据" },
                    { 105, "列表中不存在该房子" },
                    { 106, "找不到房子" },
                    { 107, "无效的房子" },
                    { 108, "无法更新房子数据" },
                    { 109, "无法更新房子" },
                    { 110, "无法删除房子" },
                    { 111, "房子不可用" },
                    { 112, "无法检查房子是否可用" },
                    { 113, "无效的文件名" },
                    { 114, "文件不存在" }
                }
            },
            { "hi", new Dictionary<int, string> // Hindi
                {
                    { 100, "अमान्य घर" },
                    { 101, "इस क्रिया को करने की अनुमति नहीं है" },
                    { 102, "अमान्य घर" },
                    { 103, "अमान्य आईडी" },
                    { 104, "अमान्य डेटा" },
                    { 105, "घर सूची में मौजूद नहीं है" },
                    { 106, "घर नहीं मिला" },
                    { 107, "अमान्य घर" },
                    { 108, "घर के डेटा को अपडेट नहीं कर सका" },
                    { 109, "घर को अपडेट नहीं कर सका" },
                    { 110, "घर को हटा नहीं सका" },
                    { 111, "घर उपलब्ध नहीं है" },
                    { 112, "घर की उपलब्धता नहीं देख सका" },
                    { 113, "अमान्य फ़ाइल नाम" },
                    { 114, "फ़ाइल मौजूद नहीं है" }
                }
            },
            { "ar", new Dictionary<int, string> // Árabe
                {
                    { 100, "منزل غير صالح" },
                    { 101, "ليس لديك إذن لتنفيذ هذا الإجراء" },
                    { 102, "منزل غير صالح" },
                    { 103, "معرف غير صالح" },
                    { 104, "بيانات غير صالحة" },
                    { 105, "المنزل غير موجود في قائمة المنازل" },
                    { 106, "المنزل غير موجود" },
                    { 107, "منزل غير صالح" },
                    { 108, "تعذر تحديث بيانات المنزل" },
                    { 109, "تعذر تحديث المنزل" },
                    { 110, "تعذر إزالة المنزل" },
                    { 111, "المنزل غير متوفر" },
                    { 112, "تعذر التحقق من توفر المنزل" },
                    { 113, "اسم ملف غير صالح" },
                    { 114, "الملف غير موجود" }
                }
            },
            { "fr", new Dictionary<int, string> // Francês
                {
                    { 100, "Maison invalide" },
                    { 101, "Vous n'avez pas la permission d'effectuer cette action" },
                    { 102, "Maison invalide" },
                    { 103, "ID invalide" },
                    { 104, "Données invalides" },
                    { 105, "La maison n'existe pas dans la liste des maisons" },
                    { 106, "Maison introuvable" },
                    { 107, "Maison invalide" },
                    { 108, "Impossible de mettre à jour les données de la maison" },
                    { 109, "Impossible de mettre à jour la maison" },
                    { 110, "Impossible de supprimer la maison" },
                    { 111, "La maison n'est pas disponible" },
                    { 112, "Impossible de vérifier la disponibilité de la maison" },
                    { 113, "Nom de fichier invalide" },
                    { 114, "Le fichier n'existe pas" }
                }
            },
            { "de", new Dictionary<int, string> // Alemão
                {
                    { 100, "Ungültiges Haus" },
                    { 101, "Sie haben keine Berechtigung, diese Aktion auszuführen" },
                    { 102, "Ungültiges Haus" },
                    { 103, "Ungültige ID" },
                    { 104, "Ungültige Daten" },
                    { 105, "Das Haus existiert nicht in der Liste der Häuser" },
                    { 106, "Haus nicht gefunden" },
                    { 107, "Ungültiges Haus" },
                    { 108, "Daten des Hauses konnten nicht aktualisiert werden" },
                    { 109, "Das Haus konnte nicht aktualisiert werden" },
                    { 110, "Das Haus konnte nicht entfernt werden" },
                    { 111, "Das Haus ist nicht verfügbar" },
                    { 112, "Die Verfügbarkeit des Hauses konnte nicht überprüft werden" },
                    { 113, "Ungültiger Dateiname" },
                    { 114, "Die Datei existiert nicht" }
                }
            },
            { "ja", new Dictionary<int, string> // Japonês
                {
                    { 100, "無効な家" },
                    { 101, "この操作を実行する権限がありません" },
                    { 102, "無効な家" },
                    { 103, "無効なID" },
                    { 104, "無効なデータ" },
                    { 105, "リストに家が存在しません" },
                    { 106, "家が見つかりません" },
                    { 107, "無効な家" },
                    { 108, "家のデータを更新できませんでした" },
                    { 109, "家を更新できませんでした" },
                    { 110, "家を削除できませんでした" },
                    { 111, "家は利用できません" },
                    { 112, "家の利用状況を確認できませんでした" },
                    { 113, "無効なファイル名" },
                    { 114, "ファイルが存在しません" }
                }
            },
            { "ko", new Dictionary<int, string> // Coreano
                {
                    { 100, "유효하지 않은 집" },
                    { 101, "이 작업을 수행할 권한이 없습니다" },
                    { 102, "유효하지 않은 집" },
                    { 103, "유효하지 않은 ID" },
                    { 104, "유효하지 않은 데이터" },
                    { 105, "목록에 집이 존재하지 않습니다" },
                    { 106, "집을 찾을 수 없습니다" },
                    { 107, "유효하지 않은 집" },
                    { 108, "집 데이터를 업데이트할 수 없습니다" },
                    { 109, "집을 업데이트할 수 없습니다" },
                    { 110, "집을 삭제할 수 없습니다" },
                    { 111, "집을 사용할 수 없습니다" },
                    { 112, "집의 가용성을 확인할 수 없습니다" },
                    { 113, "유효하지 않은 파일 이름" },
                    { 114, "파일이 존재하지 않습니다" }
                }
            },
            { "ru", new Dictionary<int, string> // Russo
                {
                    { 100, "Недействительный дом" },
                    { 101, "У вас нет разрешения на выполнение этого действия" },
                    { 102, "Недействительный дом" },
                    { 103, "Недействительный ID" },
                    { 104, "Недействительные данные" },
                    { 105, "Дом отсутствует в списке домов" },
                    { 106, "Дом не найден" },
                    { 107, "Недействительный дом" },
                    { 108, "Не удалось обновить данные дома" },
                    { 109, "Не удалось обновить дом" },
                    { 110, "Не удалось удалить дом" },
                    { 111, "Дом недоступен" },
                    { 112, "Не удалось проверить доступность дома" },
                    { 113, "Недопустимое имя файла" },
                    { 114, "Файл не существует" }
                }
            },

        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado à exceção.</param>
        public HouseExceptions(int error) : base(ErrorMessages.ContainsKey(currentLanguage) && ErrorMessages[currentLanguage].ContainsKey(error) ? ErrorMessages[currentLanguage][error] : "0x80004005")
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatProblems
{
    /// <summary>
    /// Classe que representa uma exceção personalizada para erros relacionados com a classe Reservation.
    /// </summary>
    public class ReservationExceptions : Exception
    {
        private int errorCode;
        private static string currentLanguage = "en";

        /// <summary>
        /// Dicionário que contém as mensagens de erro em vários idiomas.
        /// </summary>
        private static readonly Dictionary<string, Dictionary<int, string>> ErrorMessages = new Dictionary<string, Dictionary<int, string>>()
        {
            { "pt", new Dictionary<int, string> // Português
                {
                    { 115, "Reserva inválida" },
                    { 116, "Não tem permissões" },
                    { 117, "A casa não está disponível para reserva" },
                    { 118, "ID inválido" },
                    { 119, "A reserva já existe na lista de reservas" },
                    { 120, "Reserva não encontrada" },
                    { 121, "Reserva inválida" },
                    { 122, "Não foi possível atualizar os dados da reserva" },
                    { 123, "Não foi possível remover a reserva" },
                    { 124, "A reserva tem que ser de pelo menos uma noite" },
                    { 125, "Não foi possível obter o custo da reserva" },
                    { 126, "A reserva já foi cancelada" },
                    { 127, "Nome do ficheiro inválido" },
                    { 128, "O ficheiro não existe" }
                }
            },
            { "en", new Dictionary<int, string> // Inglês
                {
                    { 115, "Invalid booking" },
                    { 116, "You do not have permissions" },
                    { 117, "The house is not available for booking" },
                    { 118, "Invalid ID" },
                    { 119, "The booking already exists in the booking list" },
                    { 120, "Booking not found" },
                    { 121, "Invalid booking" },
                    { 122, "Unable to update booking details" },
                    { 123, "Unable to remove the booking" },
                    { 124, "The booking must be for at least one night" },
                    { 125, "Unable to retrieve booking cost" },
                    { 126, "The booking has already been canceled" },
                    { 127, "Invalid file name" },
                    { 128, "The file does not exist" }
                }
            },
            { "es", new Dictionary<int, string> // Espanhol
                {
                    { 115, "Reserva inválida" },
                    { 116, "No tiene permisos" },
                    { 117, "La casa no está disponible para reserva" },
                    { 118, "ID inválido" },
                    { 119, "La reserva ya existe en la lista de reservas" },
                    { 120, "Reserva no encontrada" },
                    { 121, "Reserva inválida" },
                    { 122, "No se pudo actualizar los datos de la reserva" },
                    { 123, "No se pudo eliminar la reserva" },
                    { 124, "La reserva debe ser de al menos una noche" },
                    { 125, "No se pudo obtener el costo de la reserva" },
                    { 126, "La reserva ya ha sido cancelada" },
                    { 127, "Nombre de archivo inválido" },
                    { 128, "El archivo no existe" }
                }
            },
            { "zh", new Dictionary<int, string> // Mandarim (Chinês Simplificado)
                {
                    { 115, "无效的预订" },
                    { 116, "您没有权限" },
                    { 117, "房屋无法预订" },
                    { 118, "无效的ID" },
                    { 119, "预订已存在于预订列表中" },
                    { 120, "未找到预订" },
                    { 121, "无效的预订" },
                    { 122, "无法更新预订信息" },
                    { 123, "无法删除预订" },
                    { 124, "预订至少应为一晚" },
                    { 125, "无法获取预订费用" },
                    { 126, "预订已被取消" },
                    { 127, "无效的文件名" },
                    { 128, "文件不存在" }
                }
            },
            { "hi", new Dictionary<int, string> // Hindi
                {
                    { 115, "अमान्य बुकिंग" },
                    { 116, "आपके पास अनुमतियाँ नहीं हैं" },
                    { 117, "घर बुकिंग के लिए उपलब्ध नहीं है" },
                    { 118, "अमान्य आईडी" },
                    { 119, "बुकिंग पहले से ही बुकिंग सूची में मौजूद है" },
                    { 120, "बुकिंग नहीं मिली" },
                    { 121, "अमान्य बुकिंग" },
                    { 122, "बुकिंग विवरण अपडेट नहीं कर सका" },
                    { 123, "बुकिंग हटाई नहीं जा सकी" },
                    { 124, "बुकिंग कम से कम एक रात के लिए होनी चाहिए" },
                    { 125, "बुकिंग की लागत प्राप्त नहीं कर सका" },
                    { 126, "बुकिंग पहले ही रद्द कर दी गई है" },
                    { 127, "अमान्य फ़ाइल नाम" },
                    { 128, "फ़ाइल मौजूद नहीं है" }
                }
            },
            { "ar", new Dictionary<int, string> // Árabe
                {
                    { 115, "الحجز غير صالح" },
                    { 116, "ليس لديك الأذونات" },
                    { 117, "المنزل غير متاح للحجز" },
                    { 118, "معرف غير صالح" },
                    { 119, "الحجز موجود بالفعل في قائمة الحجوزات" },
                    { 120, "الحجز غير موجود" },
                    { 121, "الحجز غير صالح" },
                    { 122, "تعذر تحديث تفاصيل الحجز" },
                    { 123, "تعذر إزالة الحجز" },
                    { 124, "يجب أن يكون الحجز على الأقل لليلة واحدة" },
                    { 125, "تعذر الحصول على تكلفة الحجز" },
                    { 126, "تم إلغاء الحجز بالفعل" },
                    { 127, "اسم ملف غير صالح" },
                    { 128, "الملف غير موجود" }
                }
            },
            { "fr", new Dictionary<int, string> // Francês
                {
                    { 115, "Réservation invalide" },
                    { 116, "Vous n'avez pas les permissions" },
                    { 117, "La maison n'est pas disponible à la réservation" },
                    { 118, "ID invalide" },
                    { 119, "La réservation existe déjà dans la liste des réservations" },
                    { 120, "Réservation introuvable" },
                    { 121, "Réservation invalide" },
                    { 122, "Impossible de mettre à jour les détails de la réservation" },
                    { 123, "Impossible de supprimer la réservation" },
                    { 124, "La réservation doit être d'au moins une nuit" },
                    { 125, "Impossible d'obtenir le coût de la réservation" },
                    { 126, "La réservation a déjà été annulée" },
                    { 127, "Nom de fichier invalide" },
                    { 128, "Le fichier n'existe pas" }
                }
            },
            { "de", new Dictionary<int, string> // Alemão
                {
                    { 115, "Ungültige Buchung" },
                    { 116, "Sie haben keine Berechtigungen" },
                    { 117, "Das Haus ist nicht buchbar" },
                    { 118, "Ungültige ID" },
                    { 119, "Die Buchung existiert bereits in der Buchungsliste" },
                    { 120, "Buchung nicht gefunden" },
                    { 121, "Ungültige Buchung" },
                    { 122, "Buchungsdetails konnten nicht aktualisiert werden" },
                    { 123, "Die Buchung konnte nicht entfernt werden" },
                    { 124, "Die Buchung muss mindestens eine Nacht umfassen" },
                    { 125, "Buchungskosten konnten nicht abgerufen werden" },
                    { 126, "Die Buchung wurde bereits storniert" },
                    { 127, "Ungültiger Dateiname" },
                    { 128, "Die Datei existiert nicht" }
                }
            },
            { "ja", new Dictionary<int, string> // Japonês
                {
                    { 115, "無効な予約" },
                    { 116, "権限がありません" },
                    { 117, "家は予約できません" },
                    { 118, "無効なID" },
                    { 119, "予約は既に予約リストに存在します" },
                    { 120, "予約が見つかりません" },
                    { 121, "無効な予約" },
                    { 122, "予約の詳細を更新できませんでした" },
                    { 123, "予約を削除できませんでした" },
                    { 124, "予約は少なくとも1泊必要です" },
                    { 125, "予約費用を取得できませんでした" },
                    { 126, "予約は既にキャンセルされています" },
                    { 127, "無効なファイル名" },
                    { 128, "ファイルが存在しません" }
                }
            },
            { "ko", new Dictionary<int, string> // Coreano
                {
                    { 115, "유효하지 않은 예약" },
                    { 116, "권한이 없습니다" },
                    { 117, "집은 예약할 수 없습니다" },
                    { 118, "유효하지 않은 ID" },
                    { 119, "예약이 이미 예약 목록에 존재합니다" },
                    { 120, "예약을 찾을 수 없습니다" },
                    { 121, "유효하지 않은 예약" },
                    { 122, "예약 세부정보를 업데이트할 수 없습니다" },
                    { 123, "예약을 제거할 수 없습니다" },
                    { 124, "예약은 최소 1박 이상이어야 합니다" },
                    { 125, "예약 비용을 가져올 수 없습니다" },
                    { 126, "예약이 이미 취소되었습니다" },
                    { 127, "유효하지 않은 파일 이름" },
                    { 128, "파일이 존재하지 않습니다" }
                }
            },
            { "ru", new Dictionary<int, string> // Russo
                {
                    { 115, "Недействительное бронирование" },
                    { 116, "У вас нет разрешений" },
                    { 117, "Дом недоступен для бронирования" },
                    { 118, "Недействительный ID" },
                    { 119, "Бронирование уже существует в списке" },
                    { 120, "Бронирование не найдено" },
                    { 121, "Недействительное бронирование" },
                    { 122, "Не удалось обновить данные бронирования" },
                    { 123, "Не удалось удалить бронирование" },
                    { 124, "Бронирование должно быть не менее одной ночи" },
                    { 125, "Не удалось получить стоимость бронирования" },
                    { 126, "Бронирование уже отменено" },
                    { 127, "Недопустимое имя файла" },
                    { 128, "Файл не существует" }
                }
            },
        };

        /// <summary>
        /// Construtor que inicializa a exceção com um código de erro.
        /// </summary>
        /// <param name="error">Código de erro associado à exceção.</param>
        public ReservationExceptions(int error) : base(ErrorMessages.ContainsKey(currentLanguage) && ErrorMessages[currentLanguage].ContainsKey(error) ? ErrorMessages[currentLanguage][error] : "0x80004005")
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

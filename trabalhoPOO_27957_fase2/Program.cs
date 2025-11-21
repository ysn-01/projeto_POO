using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects;
using TreatProblems;
using Rules;

namespace trabalhoPOO_fase2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Main

            Console.OutputEncoding = Encoding.UTF8;

            //Linguagens disponíveis:
            // - Português (pt)
            // - Inglês (en)
            // - Espanhol (es)
            // - Mandarim (Chinês Simplificado) (zh)
            // - Hindi (hi)
            // - Árabe (ar)
            // - Francês (fr)
            // - Alemão (de)
            // - Japonês (ja)
            // - Coreano (ko)
            // - Russo (ru)

            string language = "pt";

            if (language != null)
            {
                HouseExceptions.CurrentLanguage = language;
                ReservationExceptions.CurrentLanguage = language;
                ValidateHouseExceptions.CurrentLanguage = language;
                ValidateReservationExceptions.CurrentLanguage = language;
            }

            string housesFileName = "Casas";
            string reservationsFileName = "Reservas";

            PERMS user = PERMS.USER;
            PERMS manager = PERMS.MANAGER;
            PERMS admin = PERMS.ADMIN;

            try
            {
                House house1 = HouseRules.TryCreateHouse(admin, "Casa na Árvore", "Av. do Sol, 67", 50.00, 3, 6, true, true);
                House house2 = HouseRules.TryCreateHouse(admin, "Casa na Praia", "Rua das Palmeiras, 42", 25.00, 2, 3, false, true);
                House house3 = HouseRules.TryCreateHouse(admin, "Casa no Campo", "Avenida da Liberdade, 123", 15.00, 5, 5, true, false);
                House newData = HouseRules.TryCreateHouse(admin, "Casa na Montanha", "Avenida da Lua, 690", 30.00, 2, 2, false, false);

                HouseRules.TryAddHouse(admin, house1);
                HouseRules.TryAddHouse(admin, house2);
                HouseRules.TryAddHouse(admin, house3);

                Reservation reservation1 = ReservationRules.TryMakeReservation(user, house1, new DateTime(2025, 12, 22), new DateTime(2025, 12, 27));
                Reservation reservation2 = ReservationRules.TryMakeReservation(user, house2, new DateTime(2025, 12, 23), new DateTime(2025, 12, 25));
                Reservation reservation3 = ReservationRules.TryMakeReservation(user, house3, new DateTime(2025, 12, 24), new DateTime(2025, 12, 29));
                //Reservation reservation4 = ReservationRules.TryMakeReservation(user, house3, new DateTime(2025, 12, 24), new DateTime(2025, 12, 29));

                HouseRules.TryUpdateFullHouse(manager, house1.Id, newData);
                HouseRules.TryUpdateHouseData(manager, house1.Id, "Casa no Lago", "Rua dos Pinheiros, 55", 75.00, 7, 9, true, true);
                ReservationRules.TryCancelReservation(manager, reservation2.Id);
                ReservationRules.TryUpdateReservation(manager, reservation1.Id, new DateTime(2025, 12, 22), new DateTime(2025, 12, 25));
                HouseRules.TryRemoveHouse(admin, house2.Id);
                ReservationRules.TryRemoveReservation(admin, reservation3.Id);
                HouseRules.TryOrderByPriceASC(user);
                ReservationRules.TryOrderByDateASC(manager);
            }
            catch (HouseExceptions)
            {

            }
            catch (ReservationExceptions)
            {

            }
            catch (ValidateHouseExceptions)
            {

            }
            catch (ValidateReservationExceptions)
            {

            }

            HouseRules.TrySaveHousesFile(admin, housesFileName);
            HouseRules.TrySaveHousesFile(admin, reservationsFileName);

            Console.ReadLine();

            #endregion
        }
    }
}

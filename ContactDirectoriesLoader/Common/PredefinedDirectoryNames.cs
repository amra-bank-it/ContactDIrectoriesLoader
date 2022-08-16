using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Common
{
    public static class PredefinedDirectoryNames
    {
        /// <summary>
        /// Справочник "Участники системы CONTACT".
        /// </summary>
        public const string Banks = "BANKS";
        
        /// <summary>
        /// Услуги, оказываемые каждым из участников системы CONTACT.
        /// </summary>
        public const string BankServ = "BANKSERV";

        /// <summary>
        ///  Перечень услуг, которые оказывают участники системы CONTACT.
        ///  Кассовые символы при приеме оплаты и комиссии за услуги.
        /// </summary>
        public const string Serv = "SERV";

        /// <summary>
        /// Города, где расположены участники системы CONTACT.
        /// </summary>
        public const string BnkCity = "BNK_CITY";

        /// <summary>
        /// Текстовое описание особенностей обслуживания клиентов.
        /// </summary>
        public const string FeatTxt = "FEAT_TXT";

        /// <summary>
        /// Участники, имеющие особенности в правилах обслуживания клиентов.
        /// </summary>
        public const string Feature = "FEATURE";

        /// <summary>
        /// Перечень лиц, операции с денежными средствами которых подлежат обязательному
        /// контролю в соответствии с п. 2 ст. 6 Федерального закона от 07/08/2001 № 115-ФЗ
        /// (лица, в отношении которых имеются данные об их причастности к экстремистской
        /// деятельности или терроризму).
        /// </summary>
        public const string KfmInfo = "KFM_INFO";

        /// <summary>
        /// Регионы Российской Федерации, где имеются участники системы CONTACT.
        /// </summary>
        public const string Region = "REGION";

        /// <summary>
        /// Страны мира, с указанием валют, которые можно принимать из страны и отправлять в
        /// страну.
        /// </summary>
        public const string Country = "COUNTRY";

        /// <summary>
        /// Список полей документа к заполнению
        /// </summary>
        public const string AttrList = "ATTRLIST";

        /// <summary>
        /// Логотипы участников
        /// </summary>
        public const string Logo = "LOGO";

        /// <summary>
        /// Ограничения на суммы отправляемых переводов/платежей
        /// </summary>
        public const string MinMax = "MIN_MAX";

        /// <summary>
        /// Таблица содержит список станций метро
        /// </summary>
        public const string Metro = "METRO";

        /// <summary>
        /// Таблица содержит список линий метро в городах
        /// </summary>
        public const string MetroLines = "METRO_LINES";
    }
}

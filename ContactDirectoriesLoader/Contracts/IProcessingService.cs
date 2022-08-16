using ContactDirectoriesLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Contracts
{   
    /// <summary>
    /// Сервис обработки полученного XML со справочником
    /// </summary>
    public interface IProcessingService
    {
        /// <summary>
        /// Разобрать входящий справочник CONTACT.
        /// </summary>
        /// <param name="contactDirectory">Справочники CONTACT</param>
        Task Process(ContactBusinessLevelResponse contactDirectories, DateTime? firstRequestDateTime = null);

        /// <summary>
        /// Разобрать входящий справочник CONTACT.
        /// </summary>
        /// <param name="contactDirectories">Справочники CONTACT.</param>
        /// <param name="directoryVersion">Версия справочника</param>
        /// <param name="currentDirectoryPart">Текущая загружаемая часть.</param>
        /// <param name="totalDirectoryParts">Всего частей.</param>
        Task Process(ContactBusinessLevelResponse contactDirectories, 
                                    int directoryVersion, 
                                    int CurrentDirectoryPart, 
                                    int TotalDirectoryParts, 
                                    DateTime? firstRequestDateTime = null);
    }
}

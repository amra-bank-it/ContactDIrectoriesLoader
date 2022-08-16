using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ContactDirectoriesLoader.Mappers
{
    /// <summary>
    /// Перечень участников, имеющих особенности в правилах  - маппер
    /// обслуживания клиентов
    /// </summary>
    internal class FeatureMapper : IMapper<FeatureModel, Feature>
    {
        public Feature Map(FeatureModel featureModel)
        {
            return new Feature()
            {
                Version = featureModel.Version,
                Erased = (bool)featureModel.TypedErased,
                Id = featureModel.Id,
                SubjectType = (int)featureModel.TypedSubjectType,
                SubjectCode = (int)featureModel.TypedSubjectCode,
                IsPayment = (bool)featureModel.TypedIsPayment,
                Language = (int)featureModel.TypedLanguage,
            };
        }
    }
}

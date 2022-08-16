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
    /// Текстовая информация об особенностях обслуживания в странах, банках и компаниях  - маппер
    /// </summary>
    internal class FeatureCaptionMapper : IMapper<FeatureCaptionModel, FeatureCaption>
    {
        public FeatureCaption Map(FeatureCaptionModel featureCaptionModel)
        {
            return new FeatureCaption()
            {
                Version = featureCaptionModel.Version,
                Erased = (bool)featureCaptionModel.TypedErased,
                Id = featureCaptionModel.Id,
                FeatureId = (int)featureCaptionModel.TypedFeatureId,
                LineNumber = (int)featureCaptionModel.TypedLineNumber,
                LineText = featureCaptionModel.LineText,
            };
        }
    }
}

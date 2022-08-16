using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System.Xml.Serialization;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Contracts;

namespace ContactDirectoriesLoader.Mappers
{
    /// <summary>
    /// Описание шагов сценариев  - маппер.
    /// </summary>
    internal class ScenarioItemMapper : IMapper<ScenarioItemModel, ScenarioItem>
    {
        public ScenarioItem Map(ScenarioItemModel scenarioItemModel)
        {
            return new ScenarioItem()
            {
                Version = scenarioItemModel.Version,
                Erased = (bool)scenarioItemModel.TypedErased,
                Id = scenarioItemModel.Id,
                ScenaioId = (int)scenarioItemModel.TypedScenaioId,
                Step = (int)scenarioItemModel.TypedStep,
                AttributeGroups = scenarioItemModel.AttributeGroups,
                ObjectClass = scenarioItemModel.ObjectClass,
                ObjectAction = scenarioItemModel.ObjectAction,
                ListSources = scenarioItemModel.ListSources,
            };
        }
    }
}

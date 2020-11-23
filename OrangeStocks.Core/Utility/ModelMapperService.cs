using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OrangeStocks.Core.Utility {

    public class ModelMapperService {

        /// <summary>
        /// Maps The "SourceType" Data Into "DestinationType" Data
        /// </summary>
        /// <typeparam name="SourceType">Data Type Of "source"</typeparam>
        /// <typeparam name="DestinationType">Data Type In Which You Want To Map "source"</typeparam>
        /// <param name="source">"source" Of "SourceType"</param>
        /// <returns>Returns 'source" Data Into "DestinationType" Object</returns>
        public static DestinationType AutoMap<SourceType, DestinationType>(SourceType source) {

            return (DestinationType)Convert
                    .ChangeType(
                        new MapperConfiguration(
                            config => {
                                config.CreateMap<SourceType, DestinationType>();
                            })
                    .CreateMapper()
                    .Map<SourceType, DestinationType>(
                            source != null
                            ? source : Activator.CreateInstance<SourceType>()),
                        typeof(DestinationType));

        }

        /// <summary>
        /// Maps The "SourceType" Data Into "DestinationType" Data
        /// </summary>
        /// <typeparam name="SourceType">Data Type Of "source"</typeparam>
        /// <typeparam name="DestinationType">Data Type In Which You Want To Map "source"</typeparam>
        /// <param name="source">"source" Of "SourceType"</param>
        /// <returns>Returns 'source" Data Into "DestinationType" Object</returns>
        public static DestinationType ManualMap<SourceType, DestinationType>(SourceType source) {
            DestinationType destinationType = Activator.CreateInstance<DestinationType>();
            source.GetType()
                .GetProperties()
                .ToList()
                .ForEach(delegate (PropertyInfo property) {
                    if (destinationType
                        .GetType()
                        .GetProperty(property.Name) != null)
                            destinationType
                                .GetType()
                                .GetProperty(property.Name)
                                .SetValue(
                                    destinationType,
                                    property
                                        .GetValue(source, null));
                });

            return destinationType;
        }

        //Under Development for nested complex objects
        //if (property.GetType().GetProperties().Count() > 0) {
        //                    destinationType
        //                        .GetType()
        //                        .GetProperty(property.Name)
        //                        .SetValue(Activator.CreateInstance(
        //                            destinationType
        //                            .GetType()
        //                            .GetProperty(property.Name)
        //                            .GetType()),
        //                            ModelMapperService.ManualMap<dynamic, dynamic>(property
        //                            .GetValue(Activator
        //                            .CreateInstance(
        //                                property
        //                                .GetType())
        //                            , null))
        //                            , null);

    }

}